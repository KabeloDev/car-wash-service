using CarWash_Service.Models;

namespace CarWash_Service.Repository
{
    public interface IPackageRepository
    {
        void AddService(int serviceId, int quantity);
        void RemoveService(int serviceId);
        void RemoveAllServicesByUser(string userId);
    }
}
