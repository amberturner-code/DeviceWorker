using DeviceWorker.Domain.Models;

namespace DeviceWorker.Messaging.Sender
{
    public interface IDeviceMessageSender
    {
        void SendMessage(Device device);
    }
}
