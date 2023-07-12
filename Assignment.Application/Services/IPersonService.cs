using Assignment.Application.Domain;

namespace Assignment.Application.Services
{
    public interface IPersonService
    {
        Task<Person> GetByIdAsync(int id);
        Task<List<Person>> GetAllAsync();
        Task<Person> AddAsync(Person person);
        Task<Person> UpdateAsync(Person person);
        Task DeleteAsync(int id);
        Task<List<Person>> FilterAsync(string name, int? age);
    }
}
