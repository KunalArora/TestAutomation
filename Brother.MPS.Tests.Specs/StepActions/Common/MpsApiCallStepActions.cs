using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using System.Linq;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;

namespace Brother.Tests.Specs.StepActions.Common
{
    public class MpsApiCallStepActions : StepActionBase
    {
        private readonly IContextData _contextData;
        private readonly IDeviceSimulatorService _deviceSimulatorService;
        private readonly IContractShiftService _agreementShiftService;
        private readonly IRunCommandService _runCommandService;

        public MpsApiCallStepActions(
            IContractShiftService agreementShiftService,
            IDeviceSimulatorService deviceSimulatorService,
            IRunCommandService runCommandService,
            IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            ILoggingService loggingService,
            IRuntimeSettings runtimeSettings)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, loggingService, runtimeSettings)
        {
            _contextData = contextData;
            _deviceSimulatorService = deviceSimulatorService;
            _agreementShiftService = agreementShiftService;
            _runCommandService = runCommandService;
        }

        public void UpdateAndNotifyBOCForPrintCounts() // For Type 3
        {
            LoggingService.WriteLogOnMethodEntry();
            var products = _contextData.PrintersProperties;
            var devices = _contextData.AdditionalDeviceProperties;

            foreach (var product in products)
            {
                product.TotalPageCount = product.MonoPrintCount + product.ColorPrintCount;
                foreach(var device in devices)
                {
                    if (device.Model.Equals(product.Model))
                    {
                        device.MonoPrintCount = product.MonoPrintCount;
                        device.ColorPrintCount = product.ColorPrintCount;

                        _deviceSimulatorService.SetPrintCounts(device.BocDeviceId, device.MonoPrintCount, device.ColorPrintCount);
                        _deviceSimulatorService.NotifyBocOfDeviceChanges(device.BocDeviceId);
                    }
                }
            }
        }

        public void UpdateAndNotifyBOCForConsumableOrder() // For Type 3
        {
            LoggingService.WriteLogOnMethodEntry();
            var products = _contextData.PrintersProperties;
            var devices = _contextData.AdditionalDeviceProperties; 
            
            foreach (var product in products)
            {
                foreach(var device in devices)
                {
                    if (device.Model.Equals(product.Model))
                    {
                        // Save consumable order status to Additional Device Properties as well for convenience
                        device.TonerInkBlackStatus = product.TonerInkBlackStatus;
                        device.TonerInkCyanStatus = product.TonerInkCyanStatus;
                        device.TonerInkMagentaStatus = product.TonerInkMagentaStatus;
                        device.TonerInkYellowStatus = product.TonerInkYellowStatus;

                        _deviceSimulatorService.RaiseConsumableOrder(
                            device.BocDeviceId, device.TonerInkBlackStatus, device.TonerInkCyanStatus, device.TonerInkMagentaStatus, device.TonerInkYellowStatus);
                        _deviceSimulatorService.NotifyBocOfDeviceChanges(device.BocDeviceId);
                    }
                }
            }
        }

        public void UpdateAndNotifyBOCForConsumableOrderWithReplaceCountAndRemLife()
        {
            LoggingService.WriteLogOnMethodEntry();

            var products = _contextData.PrintersProperties;
            
            foreach (var product in products)
            {
                if(_contextData.ProposalId != 0) // Proposal
                {
                    //Update the consumable order, remaining life and replace count as per specifications
                    _deviceSimulatorService.RaiseConsumableOrder(
                        product.DeviceId, product.TonerInkBlackStatus, product.TonerInkCyanStatus, product.TonerInkMagentaStatus, product.TonerInkYellowStatus);
                    _deviceSimulatorService.SetRemainingLife(
                        product.DeviceId, product.TonerInkBlackRemLife, product.TonerInkCyanRemLife, product.TonerInkMagentaRemLife, product.TonerInkYellowRemLife);
                    _deviceSimulatorService.NotifyBocOfDeviceChanges(product.DeviceId);
                    product.ConsumableCreatedDate = DateTime.Now.ToString(MpsUtil.DATESTRING_INVARIANT);
                }
                else // Agreement
                {
                    var targetDevices = _contextData.AdditionalDeviceProperties.Where(d => d.Model == product.Model);
                    TestCheck.AssertIsNotNull(targetDevices, "Device could not be found in Additional device properties. Printer properties Product model = " + product.Model);

                    foreach(var device in targetDevices)
                    {

                        // Save consumable order status to Additional Device Properties as well for convenience
                        device.TonerInkBlackStatus = product.TonerInkBlackStatus;
                        device.TonerInkCyanStatus = product.TonerInkCyanStatus;
                        device.TonerInkMagentaStatus = product.TonerInkMagentaStatus;
                        device.TonerInkYellowStatus = product.TonerInkYellowStatus;
                        device.TonerInkBlackRemLife = product.TonerInkBlackRemLife;
                        device.TonerInkCyanRemLife = product.TonerInkCyanRemLife;
                        device.TonerInkMagentaRemLife = product.TonerInkMagentaRemLife;
                        device.TonerInkYellowRemLife = product.TonerInkYellowRemLife;
                        device.TonerInkBlackReplaceCount = product.TonerInkBlackReplaceCount;
                        device.TonerInkCyanReplaceCount = product.TonerInkCyanReplaceCount;
                        device.TonerInkMagentaReplaceCount = product.TonerInkMagentaReplaceCount;
                        device.TonerInkYellowReplaceCount = product.TonerInkYellowReplaceCount;
                        device.UpdateConsumableOrderCount();

                        //Update the consumable order, remaining life and replace count as per specifications
                        _deviceSimulatorService.RaiseConsumableOrder(
                            device.BocDeviceId, device.TonerInkBlackStatus, device.TonerInkCyanStatus, device.TonerInkMagentaStatus, device.TonerInkYellowStatus);
                        _deviceSimulatorService.SetRemainingLife(
                            device.BocDeviceId, device.TonerInkBlackRemLife, device.TonerInkCyanRemLife, device.TonerInkMagentaRemLife, device.TonerInkYellowRemLife);
                        _deviceSimulatorService.SetReplaceCount(
                            device.BocDeviceId, device.TonerInkBlackReplaceCount, device.TonerInkCyanReplaceCount, device.TonerInkMagentaReplaceCount, device.TonerInkYellowReplaceCount);
                        _deviceSimulatorService.NotifyBocOfDeviceChanges(device.BocDeviceId);                    
                    }
                }
            }
        }

        public void ShiftAgreementStartDateBy(int agreementShiftDays)
        {
            LoggingService.WriteLogOnMethodEntry(agreementShiftDays);

            _contextData.AgreementStartDate = MpsUtil.SubtractDaysFromDate(_contextData.AgreementStartDate, agreementShiftDays);
            _contextData.AgreementEndDate = MpsUtil.SubtractDaysFromDate(_contextData.AgreementEndDate, agreementShiftDays);

            _agreementShiftService.ContractTimeShiftCommand(_contextData.AgreementId, agreementShiftDays, "d", false, true, "Any");
        }

        public void ShiftAgreementStartDateWithoutGeneratingInvoice(int agreementShiftDays)
        {
            LoggingService.WriteLogOnMethodEntry(agreementShiftDays);

            _contextData.AgreementShiftDays = agreementShiftDays;
            _contextData.AgreementStartDate = MpsUtil.SubtractDaysFromDate(_contextData.AgreementStartDate, agreementShiftDays);
            _contextData.AgreementEndDate = MpsUtil.SubtractDaysFromDate(_contextData.AgreementEndDate, agreementShiftDays);

            _agreementShiftService.ContractTimeShiftCommand(_contextData.AgreementId, agreementShiftDays, "d", false, false, "Any");
        }

        public void UpdateMPSForConsumableOrder()
        {
            LoggingService.WriteLogOnMethodEntry();

            // Sets the agreement status to "Running"
            _runCommandService.RunStartContractCommand();
            _runCommandService.RunMeterReadCloudSyncCommand(
                _contextData.AgreementId == 0 ? _contextData.ProposalId : _contextData.AgreementId, _contextData.Country.CountryIso);
            _runCommandService.RunConsumableOrderRequestsCommand();
            _runCommandService.RunCreateConsumableOrderCommand();           
        }

        public void RunSilentMedioDevicesCommand()
        {
            LoggingService.WriteLogOnMethodEntry();

            _runCommandService.RunCheckForSilentCloudDevicesCommand();
        }
    }
}
