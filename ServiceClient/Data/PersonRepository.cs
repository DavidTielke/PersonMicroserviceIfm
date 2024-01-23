using ServiceClient.Models;

namespace ServiceClient.Data
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IFileReader _reader;
        private readonly IPersonParser _parser;

        public PersonRepository(IFileReader reader, 
            IPersonParser parser)
        {
            _reader = reader;
            _parser = parser;
        }

        public IEnumerable<Person> Query()
        {
            var lines = _reader.ReadAllLines();
            var persons = _parser.ParseFromCsv(lines);
            return persons;
        }
    }

    public interface IPersonRepository
    {
        IEnumerable<Person> Query();
    }
}
