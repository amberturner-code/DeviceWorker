using DeviceWorker.Domain.Models;
using DeviceWorker.Logging;
using DeviceWorker.Messaging.Sender;
using System;
using System.Threading.Tasks;

namespace DeviceWorker.Services
{
    public class AssignDeviceService : IAssignDeviceService
    {
        private readonly IDeviceMessageSender _deviceMessageSender;
        private readonly ILoggerService _logger;

        public AssignDeviceService(IDeviceMessageSender deviceMessageSender, ILoggerService logger) 
        {
            _logger = logger;
            _deviceMessageSender = deviceMessageSender;
        }

        public async Task AssignAsync(Device device)
        {
            try
            {
                device.Status = "Assigned";

                // do some other, maybe long-running, operations 
                _logger.LogInfo(string.Format("Assigning Device Id {0}", device.Id));

                _deviceMessageSender.SendMessage(device);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Error Assigning Device Id {0}. Message: {1}", device.Id, ex.Message));
            }
        }        
    }
}
