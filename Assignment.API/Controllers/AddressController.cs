using Assignment.Application.Domain;
using Assignment.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAll()
        {
            var addresss = await _addressService.GetAllAsync();
            return Ok(addresss);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetById(int id)
        {
            var address = await _addressService.GetByIdAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            return Ok(address);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Address>> Add(Address address)
        {
            var newAddress = await _addressService.AddAsync(address);
            return CreatedAtAction(nameof(GetById), new { id = newAddress.Id }, newAddress);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Address>> Update(int id, Address address)
        {
            if (id != address.Id)
            {
                return BadRequest();
            }

            var updatedAddress = await _addressService.UpdateAsync(address);

            return updatedAddress;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Delete(int id)
        {
            await _addressService.DeleteAsync(id);
            return NoContent();
        }
    }
}
