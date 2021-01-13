using DeviceWorker.Domain.Models;
using System.Threading.Tasks;

namespace DeviceWorker.Services
{
    public interface IAssignDeviceService
    {
        Task AssignAsync(Device device);        
    }
}
