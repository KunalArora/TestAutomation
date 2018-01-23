using Brother.Tests.Common.ContextData;
using Brother.Tests.Specs.Services;

namespace Brother.Tests.Specs.StepActions.Common
{
    public class MpsApiCallStepActions
    {
        private readonly IContextData _contextData;
        private readonly IDeviceSimulatorService _deviceSimulatorService;

        public MpsApiCallStepActions(IContextData contextData, IDeviceSimulatorService deviceSimulatorService)
        {
            _contextData = contextData;
            _deviceSimulatorService = deviceSimulatorService;
        }

        public void UpdateAndNotifyBOCForPrintCounts() // For Type 3
        {
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
    }
}