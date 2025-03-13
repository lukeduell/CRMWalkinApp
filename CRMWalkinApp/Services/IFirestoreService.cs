using CRMWalkinApp.Models;

namespace CRMWalkinApp.Services
{
    public interface IFirestoreService
    {
        Task AddEntryAsync(CustomerModel entry);
        Task<List<CustomerModel>> GetAllEntriesAsync();
        Task<CustomerModel> GetByIdAsync(string docId);
        Task UpdateEntryAsync(CustomerModel entry);
        Task DeleteEntryAsync(string docId);
    }
}
