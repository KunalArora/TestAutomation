using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Domain.Models;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Installer;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Agreement
{
	public class MpsInstallerAgreementStepActions: StepActionBase
	{
		private const string EXPECTED_SOFTWARE_DOWNLOAD_LINK = "/mps/web-installation/download-tools";

		private readonly IWebDriver _installerWebDriver;
		private readonly IContextData _contextData;
		private readonly MpsSignInStepActions _mpsSignIn;
		private readonly IDeviceSimulatorService _deviceSimulatorService;
		private readonly IAgreementHelper _agreementHelper;
		private readonly IMpsWebToolsService _mpsWebToolsService;
		private readonly IRunCommandService _runCommandService;

		public MpsInstallerAgreementStepActions(IWebDriverFactory webDriverFactory,
			IContextData contextData,
			IPageService pageService,
			ScenarioContext context,
			IUrlResolver urlResolver,
			IRuntimeSettings runtimeSettings,
			MpsSignInStepActions mpsSignIn,
			IDeviceSimulatorService deviceSimulatorService,
			ILoggingService loggingService,
			IAgreementHelper agreementHelper,
			IMpsWebToolsService mpsWebToolsService,
			IRunCommandService runCommandService)
			: base(webDriverFactory, contextData, pageService, context, urlResolver, loggingService, runtimeSettings)
		{
			_installerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Installer);
			_contextData = contextData;
			_mpsSignIn = mpsSignIn;
			_deviceSimulatorService = deviceSimulatorService;
			_agreementHelper = agreementHelper;
			_mpsWebToolsService = mpsWebToolsService;
			_runCommandService = runCommandService;
		}

		public void InstallDevicesOneByOneForCloudBor()
		{
			LoggingService.WriteLogOnMethodEntry();

			foreach(var device in _contextData.AdditionalDeviceProperties)
			{
				SingleDeviceInstallationForCloudBor(device);
			}
		}

		public InstallationCloudToolPage BulkInstallDevicesForCloudBor()
		{
			LoggingService.WriteLogOnMethodEntry();
			// Navigate to Select method page & verify device details
			var installationSelectMethodPage = NavigateToSelectMethodPageForBulk();
			
			// Select installation method as BOR & Navigate to installation page
			ClickSafety(
					installationSelectMethodPage.BORInstallationButton(),
					installationSelectMethodPage);
			var installationCloudToolPage = PageService.GetPageObject<InstallationCloudToolPage>(
				RuntimeSettings.DefaultPageObjectTimeout, _installerWebDriver);

			// Verify that Software download link is correct
			installationCloudToolPage.VerifySoftwareDownloadLink(EXPECTED_SOFTWARE_DOWNLOAD_LINK);

			// Register devices on BOC
			ClickSafety(installationCloudToolPage.GetPinButtonElement, installationCloudToolPage);
			string pin = installationCloudToolPage.GetPin();

			string bocDeviceId, serialNumber;
			foreach(var device in _contextData.AdditionalDeviceProperties)
			{
				// Already Registered on BOC?
				if (!device.IsRegisteredOnBoc)
				{
					RegisterDeviceOnBOC(device.Model, pin, out bocDeviceId, out serialNumber);
					device.IsRegisteredOnBoc = true;

					// Save device details to Context Data
					device.BocDeviceId = bocDeviceId;
					device.SerialNumber = serialNumber;
				}
			}

			return SelectSerialNumberAndRefreshForCloudTool(installationCloudToolPage);
		}

		public InstallationCloudWebPage BulkInstallDevicesForCloudWeb()
		{
			LoggingService.WriteLogOnMethodEntry();
			string bocDeviceId, serialNumber;

			// 1. Register devices on BOC
			foreach (var device in _contextData.AdditionalDeviceProperties)
			{
				// Already Registered on BOC?
				if (!device.IsRegisteredOnBoc)
				{
					RegisterDeviceOnBOC(device.Model, device.RegistrationPin, out bocDeviceId, out serialNumber);
					device.IsRegisteredOnBoc = true;

					// Save details to context data
					device.BocDeviceId = bocDeviceId;
					device.SerialNumber = serialNumber;
				}
			}

			// 2. Navigate to Select method page & verify device details
			var installationSelectMethodPage = NavigateToSelectMethodPageForBulk();

			// 3. Select installation method as Web & Navigate to installation page
			ClickSafety(
					installationSelectMethodPage.WebInstallationButton(),
					installationSelectMethodPage);
			var installationCloudWebPage = PageService.GetPageObject<InstallationCloudWebPage>(
				RuntimeSettings.DefaultPageObjectTimeout, _installerWebDriver);


			// 4. Fill device information & hit connect
			foreach(var device in _contextData.AdditionalDeviceProperties)
			{              
				installationCloudWebPage.FillDeviceDetailsAndClickConnect(
					device, _contextData.WindowHandles[UserType.Installer]);
			}

			// 5. Hit Refresh until all devices are connected
			installationCloudWebPage = RefreshUntilConnectedForCloudWeb(installationCloudWebPage);
			
			return installationCloudWebPage;
		}
		
		public void SingleDeviceInstallationForCloudUsb(AdditionalDeviceProperties device)
		{
			LoggingService.WriteLogOnMethodEntry(device);
			string bocDeviceId, serialNumber;

			// 1. Navigate to installation URL
			var installationSelectMethodPage = _mpsSignIn.LoadInstallationSelectMethodPageType3(device.InstallationLink);

			// 2. Verify device details on InstallationSelectMethodPage
			installationSelectMethodPage.VerifyDeviceDetails(device.AgreementId, 1, device.Model); // Note: 1 is the number of devices (always 1 in case of one by one installation)

			// 3. Select installation method as "USB"
			ClickSafety(installationSelectMethodPage.MoreInstallationOptionsButtonElement, installationSelectMethodPage);
			ClickSafety(
				installationSelectMethodPage.USBInstallationButton(),
				installationSelectMethodPage);
			var installationCloudUsbPage = PageService.GetPageObject<InstallationCloudUsbPage>(
				RuntimeSettings.DefaultPageObjectTimeout, _installerWebDriver);

			// 4. Register the device on BOC using the Registration PIN
			// Already Registered on BOC?
			if (!device.IsRegisteredOnBoc)
			{
				RegisterDeviceOnBOC(
					device.Model, installationCloudUsbPage.InstallationPinElement.Text, out bocDeviceId, out serialNumber);
				device.IsRegisteredOnBoc = true;

				// Save details to context data
				device.BocDeviceId = bocDeviceId;
				device.SerialNumber = serialNumber;
			}

			// Verify that Software download link is correct
			installationCloudUsbPage.VerifySoftwareDownloadLink(EXPECTED_SOFTWARE_DOWNLOAD_LINK);
			
			// 5. Refresh until device is connected
			RefreshUntilConnectedForCloudUsb(installationCloudUsbPage);
		}

		public void BulkInstallDevicesForCloudUsb()
		{
			LoggingService.WriteLogOnMethodEntry();
			// 1. Navigate to Select method page & verify device details
			var installationSelectMethodPage = NavigateToSelectMethodPageForBulk();

			// 2. Select installation method as USB & Navigate to installation page
			ClickSafety(installationSelectMethodPage.MoreInstallationOptionsButtonElement, installationSelectMethodPage);
			ClickSafety(
				installationSelectMethodPage.USBInstallationButton(),
				installationSelectMethodPage);
			var installationCloudUsbPage = PageService.GetPageObject<InstallationCloudUsbPage>(
				RuntimeSettings.DefaultPageObjectTimeout, _installerWebDriver);

			// Verify that Software download link is correct
			installationCloudUsbPage.VerifySoftwareDownloadLink(EXPECTED_SOFTWARE_DOWNLOAD_LINK);

			// 3. Register devices on BOC
			ClickSafety(installationCloudUsbPage.GetPinButtonElement, installationCloudUsbPage);
			string pin = installationCloudUsbPage.GetPin();

			string bocDeviceId, serialNumber;
			foreach (var device in _contextData.AdditionalDeviceProperties)
			{
				// Already Registered on BOC?
				if(!device.IsRegisteredOnBoc)
				{
					RegisterDeviceOnBOC(device.Model, pin, out bocDeviceId, out serialNumber);

					device.IsRegisteredOnBoc = true;
					// Save device details to Context Data
					device.BocDeviceId = bocDeviceId;
					device.SerialNumber = serialNumber;
				}
			}

			// 4. Refresh until all devices serial numbers are detected
			int retries = 0;
			while (!installationCloudUsbPage.IsSerialNumberForAllDevicesDetected())
			{
				ClickSafety(installationCloudUsbPage.RefreshButtonElement, installationCloudUsbPage);
				installationCloudUsbPage = PageService.GetPageObject<InstallationCloudUsbPage>(
				RuntimeSettings.DefaultPageObjectTimeout, _installerWebDriver);
				retries++;
				if (retries > RuntimeSettings.DefaultRetryCount)
				{
					throw new Exception(
						string.Format("Number of retries exceeded the default limit during device installation for agreement {0}", _contextData.AgreementId));
				}
			}

			// 5. Select serial numbers of devices wherever possible
			foreach (var device in _contextData.AdditionalDeviceProperties)
			{
				var deviceRowElements = installationCloudUsbPage.SeleniumHelper.FindRowElementsWithinTable(
					installationCloudUsbPage.DeviceTableContainerElement);

				foreach (var element in deviceRowElements)
				{
					bool isSuccess = installationCloudUsbPage.SelectSerialNumber(
						element, device.MpsDeviceId, device.SerialNumber);
					if (isSuccess)
					{
						ClickSafety(installationCloudUsbPage.RefreshButtonElement, installationCloudUsbPage);
						installationCloudUsbPage = PageService.GetPageObject<InstallationCloudUsbPage>(
							RuntimeSettings.DefaultPageObjectTimeout, _installerWebDriver);
						break;
					}
				}
			}

			// 6. Refresh until all devices are connected
			RefreshUntilConnectedForCloudUsb(installationCloudUsbPage);
		}

		public void ResetAndReinstallDevices(InstallationCloudWebPage installationCloudWebPage)
		{
			LoggingService.WriteLogOnMethodEntry(installationCloudWebPage);
			string bocDeviceId, serialNumber;
			foreach(var device in _contextData.AdditionalDeviceProperties)
			{
				if(device.ResetDevice.ToLower().Equals("yes"))
				{
					installationCloudWebPage.ClickReset(device.MpsDeviceId);
					
					installationCloudWebPage = PageService.GetPageObject<InstallationCloudWebPage>(RuntimeSettings.DefaultPageObjectTimeout, _installerWebDriver);
					installationCloudWebPage.VerifyNotConnectedStatus(device.MpsDeviceId);
					installationCloudWebPage.VerifyDeviceDetailsAreNotCleared(device);

					// Register device
					RegisterDeviceOnBOC(device.Model, device.RegistrationPin, out bocDeviceId, out serialNumber);

					// Save details to context data
					device.BocDeviceId = bocDeviceId;
					device.SerialNumber = serialNumber;

					installationCloudWebPage.FillDeviceDetailsAndClickConnect(
					device, _contextData.WindowHandles[UserType.Installer]);
				}
			}

			// Check if all devices are connected
			RefreshUntilConnectedForCloudWeb(installationCloudWebPage);
		}

		public void ResetAndReinstallDevices(InstallationCloudToolPage installationCloudToolPage)
		{
			LoggingService.WriteLogOnMethodEntry(installationCloudToolPage);

			string bocDeviceId, serialNumber;

			string pin = installationCloudToolPage.GetPin();

			// Reset & Verify status
			foreach (var device in _contextData.AdditionalDeviceProperties)
			{
				if (device.ResetDevice.ToLower().Equals("yes"))
				{
					installationCloudToolPage.ClickReset(device.MpsDeviceId);

					installationCloudToolPage = PageService.GetPageObject<InstallationCloudToolPage>(RuntimeSettings.DefaultPageObjectTimeout, _installerWebDriver);
					installationCloudToolPage.VerifyNotConnectedStatus(device.MpsDeviceId);
					installationCloudToolPage.VerifyDeviceDetailsAreNotCleared(device);

					device.IsRegisteredOnBoc = false;
				}
			}

			// Register devices on BOC
			foreach(var device in _contextData.AdditionalDeviceProperties)
			{
				if(!device.IsRegisteredOnBoc)
				{
					// Register device
					RegisterDeviceOnBOC(device.Model, pin, out bocDeviceId, out serialNumber);

					// Save details to context data
					device.BocDeviceId = bocDeviceId;
					device.SerialNumber = serialNumber;
				}
			}

			SelectSerialNumberAndRefreshForCloudTool(installationCloudToolPage);
		}

		public void SwapDeviceForCloudBor(AdditionalDeviceProperties oldDevice)
		{
			LoggingService.WriteLogOnMethodEntry(oldDevice);
			
			_runCommandService.RunSendSwapRequestCommand();
			SwapRequestDetail swapInformation = _mpsWebToolsService.GetSwapRequestDetail(Int32.Parse(oldDevice.MpsDeviceId));
			
			foreach(var newDevice in _contextData.AdditionalDeviceProperties)
			{
				if(oldDevice.SwappedDeviceID.Equals(newDevice.MpsDeviceId))
				{

					string bocDeviceId, serialNumber;
					if (swapInformation.InstallationPin != null)
					{
						RegisterDeviceOnBOC(
						newDevice.Model, swapInformation.InstallationPin, out bocDeviceId, out serialNumber);

						// Save details to contextData
						newDevice.BocDeviceId = bocDeviceId;
						newDevice.SerialNumber = serialNumber;

						// Save other information of old device (swapped out) to new device (swapped in)
						CopyOldDeviceInformationToNewDevice(oldDevice, newDevice);
					}
					else
					{
						TestCheck.AssertFailTest(string.Format("No installation pin generated for SWAP installation for old device: {0}, new device: {1} ", oldDevice.MpsDeviceId, newDevice.MpsDeviceId));
					}

					if (swapInformation.InstallationUrl != null)
					{
						var installationSelectMethodPage = _mpsSignIn.LoadInstallationSelectMethodPageType3(
							swapInformation.InstallationUrl);

						// Select installation method as "BOR"
						ClickSafety(
							installationSelectMethodPage.BORInstallationButton(),
							installationSelectMethodPage);
						var installationCloudToolPage = PageService.GetPageObject<InstallationCloudToolPage>(
							RuntimeSettings.DefaultPageObjectTimeout, _installerWebDriver);

						// Verify that Software download link is correct
						installationCloudToolPage.VerifySoftwareDownloadLink(EXPECTED_SOFTWARE_DOWNLOAD_LINK);

						// Refresh until device is connected
						installationCloudToolPage = RefreshUntilConnectedForCloudBor(installationCloudToolPage);

						// Verify old device & new device information, input print counts & complete installation
						installationCloudToolPage.CompleteSwapInstallation(oldDevice, newDevice);
					}
					else
					{
						TestCheck.AssertFailTest(string.Format("No installation URL generated for SWAP installation for old device: {0}, new device: {1} ", oldDevice.MpsDeviceId, newDevice.MpsDeviceId));
					}

					return;
			  }					 
			}				
		}

		public void ReInstallDevicesForCloudBor()
		{
			LoggingService.WriteLogOnMethodEntry();

			foreach (var device in _contextData.AdditionalDeviceProperties)
			{
				if (device.ReInstallDevice.ToLower().Equals("yes"))
				{
					SingleDeviceInstallationForCloudBor(device);
				}			
			}
		}

		#region private methods

		private void RegisterDeviceOnBOC(string deviceModel, string installationPin, out string deviceId, out string serialNumber)
		{
			LoggingService.WriteLogOnMethodEntry(deviceModel, installationPin);
			// 1. Create new device
			serialNumber = _agreementHelper.GenerateSerialNumber(_contextData.UsableDeviceIndex++);
			deviceId = _deviceSimulatorService.CreateNewDevice(deviceModel, serialNumber);

			// 2. Enter Pin & register
			_deviceSimulatorService.RegisterNewDevice(deviceId, installationPin);

			// 3. Subscribe device & change status to online
			_deviceSimulatorService.ChangeDeviceStatus(deviceId, true, true);

			// 4. Notify BOC of the changes
			_deviceSimulatorService.NotifyBocOfDeviceChanges(deviceId);
		}

		private InstallationSelectMethodPage NavigateToSelectMethodPageForBulk()
		{
			LoggingService.WriteLogOnMethodEntry();

			// Navigate to advanced installation URL
			var installationManageInstallationsPage = _mpsSignIn.LoadInstallationManageInstallationsPageType3(
				_contextData.AdditionalDeviceProperties[0].AdvancedInstallationLink);
			int deviceCount = installationManageInstallationsPage.NumberOfDevices();

			// Bulk Select all devices & Navigate to Select method Page
			ClickSafety(
				installationManageInstallationsPage.BulkSelectAllDevicesCheckboxElement, installationManageInstallationsPage);
			ClickSafety(
				installationManageInstallationsPage.BulkInstallDevicesButton, installationManageInstallationsPage);
			var installationSelectMethodPage = PageService.GetPageObject<InstallationSelectMethodPage>(
					RuntimeSettings.DefaultPageObjectTimeout, _installerWebDriver);

			// Verify Agreement Reference & Device Count
			installationSelectMethodPage.VerifyDeviceDetails(_contextData.AgreementId.ToString(), deviceCount);

			return installationSelectMethodPage;
		}

		private InstallationCloudToolPage SelectSerialNumbersHelper(InstallationCloudToolPage installationCloudToolPage)
		{
			LoggingService.WriteLogOnMethodEntry(installationCloudToolPage);
			foreach (var device in _contextData.AdditionalDeviceProperties)
			{
				var deviceRowElements = installationCloudToolPage.SeleniumHelper.FindRowElementsWithinTable(
					installationCloudToolPage.DeviceTableContainerElement);

				foreach (var element in deviceRowElements)
				{
					bool isSuccess = installationCloudToolPage.SelectSerialNumber(
						element, device.MpsDeviceId, device.SerialNumber);
					if (isSuccess)
					{
						ClickSafety(installationCloudToolPage.RefreshButtonElement, installationCloudToolPage);
						installationCloudToolPage = PageService.GetPageObject<InstallationCloudToolPage>(
							RuntimeSettings.DefaultPageObjectTimeout, _installerWebDriver);
						break;
					}
				}
			}

			return installationCloudToolPage;
		}

		private InstallationCloudToolPage RefreshUntilConnectedForCloudBor(InstallationCloudToolPage installationCloudToolPage)
		{
			LoggingService.WriteLogOnMethodEntry(installationCloudToolPage);

			int retries = 0;
			while (!installationCloudToolPage.AreAllDevicesConnected())
			{
				ClickSafety(installationCloudToolPage.RefreshButtonElement, installationCloudToolPage);
				installationCloudToolPage = PageService.GetPageObject<InstallationCloudToolPage>(
				RuntimeSettings.DefaultPageObjectTimeout, _installerWebDriver);
				retries++;
				if (retries > RuntimeSettings.DefaultRetryCount)
				{
					TestCheck.AssertFailTest(
						"Number of retries exceeded the default limit during device installation for agreement:" + _contextData.AgreementId);
				}
			}

			return installationCloudToolPage;
		}

		private void RefreshUntilConnectedForCloudUsb(InstallationCloudUsbPage installationCloudUsbPage)
		{
			LoggingService.WriteLogOnMethodEntry(installationCloudUsbPage);

			int retries = 0;
			while (!installationCloudUsbPage.AreAllDevicesConnected())
			{
				ClickSafety(installationCloudUsbPage.RefreshButtonElement, installationCloudUsbPage);
				installationCloudUsbPage = PageService.GetPageObject<InstallationCloudUsbPage>(
				RuntimeSettings.DefaultPageObjectTimeout, _installerWebDriver);
				retries++;
				if (retries > RuntimeSettings.DefaultRetryCount)
				{
					TestCheck.AssertFailTest(
						"Number of retries exceeded the default limit during device installation for agreement:" + _contextData.AgreementId);
				}
			}
		}

		private InstallationCloudWebPage RefreshUntilConnectedForCloudWeb(InstallationCloudWebPage installationCloudWebPage)
		{
			LoggingService.WriteLogOnMethodEntry(installationCloudWebPage);
			int retries = 0;
			while (!installationCloudWebPage.AreAllDevicesConnected())
			{
				ClickSafety(installationCloudWebPage.RefreshButtonElement, installationCloudWebPage);
				installationCloudWebPage = PageService.GetPageObject<InstallationCloudWebPage>(
				RuntimeSettings.DefaultPageObjectTimeout, _installerWebDriver);
				retries++;
				if (retries > RuntimeSettings.DefaultRetryCount)
				{
					TestCheck.AssertFailTest(
						"Number of retries exceeded the default limit during device installation for agreement:" + _contextData.AgreementId);
				}
			}
			return installationCloudWebPage;
		}

		private InstallationCloudToolPage SelectSerialNumberAndRefreshForCloudTool(InstallationCloudToolPage installationCloudToolPage)
		{
			LoggingService.WriteLogOnMethodEntry(installationCloudToolPage);

			// Refresh until all devices serial numbers are detected
			int retries = 0;
			while (!installationCloudToolPage.IsSerialNumberForAllDevicesDetected())
			{
				ClickSafety(installationCloudToolPage.RefreshButtonElement, installationCloudToolPage);
				installationCloudToolPage = PageService.GetPageObject<InstallationCloudToolPage>(
				RuntimeSettings.DefaultPageObjectTimeout, _installerWebDriver);
				retries++;
				if (retries > RuntimeSettings.DefaultRetryCount)
				{
					TestCheck.AssertFailTest(
						"Number of retries exceeded the default limit during device installation for agreement:" + _contextData.AgreementId);
				}
			}

			// Select serial numbers of devices wherever possible
			installationCloudToolPage = SelectSerialNumbersHelper(installationCloudToolPage);

			// Refresh until all devices are connected
			return RefreshUntilConnectedForCloudBor(installationCloudToolPage);
		}

		private void CopyOldDeviceInformationToNewDevice(AdditionalDeviceProperties oldDevice, AdditionalDeviceProperties newDevice)
		{
			newDevice.AgreementId = oldDevice.AgreementId;
			newDevice.CustomerName = oldDevice.CustomerName;
			newDevice.ContactFirstName = oldDevice.ContactFirstName;
			newDevice.ContactLastName = oldDevice.ContactLastName;
			newDevice.Telephone = oldDevice.Telephone;
			newDevice.Email = oldDevice.Email;
			newDevice.AddressNumber = oldDevice.AddressNumber;
			newDevice.AddressStreet = oldDevice.AddressStreet;
			newDevice.AddressArea = oldDevice.AddressArea;
			newDevice.AddressTown = oldDevice.AddressTown;
			newDevice.AddressPostCode = oldDevice.AddressPostCode;
			newDevice.DeviceLocation = oldDevice.DeviceLocation;
			newDevice.CostCentre = oldDevice.CostCentre;
			newDevice.Reference1 = oldDevice.Reference1;
			newDevice.Reference2 = oldDevice.Reference2;
			newDevice.Reference3 = oldDevice.Reference3;
			newDevice.InstallationNotes = oldDevice.InstallationNotes;
			newDevice.MonoClickPrice = oldDevice.MonoClickPrice;
			newDevice.ColourClickPrice = oldDevice.ColourClickPrice;
			newDevice.VolumeMono = oldDevice.VolumeMono;
			newDevice.VolumeColour = oldDevice.VolumeColour;
			newDevice.ServicePack = oldDevice.ServicePack;
			newDevice.InstallationPack = oldDevice.InstallationPack;
			newDevice.ServicePackPrice = oldDevice.ServicePackPrice;
			newDevice.InstallationPackPrice = oldDevice.InstallationPackPrice;
		}
		
		private void SingleDeviceInstallationForCloudBor(AdditionalDeviceProperties device)
		{
			LoggingService.WriteLogOnMethodEntry(device);

			string deviceId, serialNumber;

			// Register the device on BOC using the Registration PIN
			// Already Registered on BOC?
			if (!device.IsRegisteredOnBoc)
			{
				RegisterDeviceOnBOC(
					device.Model, device.RegistrationPin, out deviceId, out serialNumber);
				device.IsRegisteredOnBoc = true;

				// Save details to contextData
				device.BocDeviceId = deviceId;
				device.SerialNumber = serialNumber;
			}

			// Navigate to installation URL
			var installationSelectMethodPage = _mpsSignIn.LoadInstallationSelectMethodPageType3(device.InstallationLink);

			// Verify device details on InstallationSelectMethodPage
			installationSelectMethodPage.VerifyDeviceDetails(device.AgreementId, 1, device.Model); // Note: 1 is the number of devices (always 1 in case of one by one installation)

			// Select installation method as "BOR"
			ClickSafety(
				installationSelectMethodPage.BORInstallationButton(),
				installationSelectMethodPage);
			var installationCloudToolPage = PageService.GetPageObject<InstallationCloudToolPage>(
				RuntimeSettings.DefaultPageObjectTimeout, _installerWebDriver);

			// Verify that Software download link is correct
			installationCloudToolPage.VerifySoftwareDownloadLink(EXPECTED_SOFTWARE_DOWNLOAD_LINK);

			// Refresh until device is connected
			installationCloudToolPage = RefreshUntilConnectedForCloudBor(installationCloudToolPage);
		}

		private void ClickSafety(IWebElement element, IPageObject pageObject)
		{
			LoggingService.WriteLogOnMethodEntry(element, pageObject);
			pageObject.SeleniumHelper.ClickSafety(element);
		}

		#endregion
	}
}
