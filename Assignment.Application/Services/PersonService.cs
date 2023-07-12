using Assignment.Application.Domain;

namespace Assignment.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Person> AddAsync(Person person)
        {
            var result = await _unitOfWork.People.AddAsync(person);
            _unitOfWork.Complete();

            return result;
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.People.Delete(id);
        }

        public async Task<List<Person>> FilterAsync(string name, int? age)
        {
            var query = await _unitOfWork.People.GetAllAsync();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }

            if (age.HasValue)
            {
                query = query.Where(p => p.Age == age.Value);
            }

            return query.ToList();
        }

        public async Task<List<Person>> GetAllAsync()
        {
            var result = await _unitOfWork.People.GetAllAsync();
            return result.ToList();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _unitOfWork.People.GetByIdAsync(id);
        }

        public async Task<Person> UpdateAsync(Person person)
        {
            return _unitOfWork.People.Update(person);
        }
    }
}
