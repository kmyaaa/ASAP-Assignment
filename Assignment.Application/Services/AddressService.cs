using Assignment.Application.Domain;

namespace Assignment.Application.Services
{
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddressService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Address> AddAsync(Address address)
        {
            var result = await _unitOfWork.Addresses.AddAsync(address);
            _unitOfWork.Complete();

            return result;
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Addresses.Delete(id);
        }

        public async Task<List<Address>> GetAllAsync()
        {
            var result = await _unitOfWork.Addresses.GetAllAsync();
            return result.ToList();
        }

        public async Task<Address> GetByIdAsync(int id)
        {
            return await _unitOfWork.Addresses.GetByIdAsync(id);
        }

        public async Task<Address> UpdateAsync(Address address)
        {
            return _unitOfWork.Addresses.Update(address);
        }
    }
}
