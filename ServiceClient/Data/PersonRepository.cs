using ServiceClient.Models;

namespace ServiceClient.Data
{
    public class PersonRepository
    {
        private readonly FileReader _reader;
        private readonly PersonParser _parser;

        public PersonRepository()
        {
            _reader = new FileReader("data.csv");
            _parser = new PersonParser();
        }



        public IEnumerable<Person> Query()
        {
            var lines = _reader.ReadAllLines();
            var persons = _parser.ParseFromCsv(lines);
            return persons;
        }
    }
}
