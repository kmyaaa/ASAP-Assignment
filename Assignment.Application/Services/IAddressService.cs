using Assignment.Application.Domain;

namespace Assignment.Application.Services
{
    public interface IAddressService
    {
        Task<Address> GetByIdAsync(int id);
        Task<List<Address>> GetAllAsync();
        Task<Address> AddAsync(Address address);
        Task<Address> UpdateAsync(Address address);
        Task DeleteAsync(int id);
    }
}
