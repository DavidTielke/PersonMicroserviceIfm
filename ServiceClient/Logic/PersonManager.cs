using ServiceClient.Data;
using ServiceClient.Models;

namespace ServiceClient.Logic
{
    public class PersonManager
    {
        private readonly PersonRepository _repository;

        public PersonManager()
        {
            _repository = new PersonRepository();
        }

        public IEnumerable<Person> GetAllAdults()
        {
            return _repository.Query().Where(p => p.Age >= 18);
        }
        public IEnumerable<Person> GetAllChildren()
        {
            return _repository.Query().Where(p => p.Age < 18);
        }

        public IEnumerable<Person> GetAll()
        {
            return _repository.Query();
        }
    }
}
