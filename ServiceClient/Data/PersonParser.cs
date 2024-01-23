using ServiceClient.Models;

namespace ServiceClient.Data
{
    public class PersonParser
    {
        public IEnumerable<Person> ParseFromCsv(string[] lines)
        {
            return lines.Select(l => l.Split(","))
                .Select(p => new Person
                {
                    Id = int.Parse(p[0]),
                    Name = p[1],
                    Age = int.Parse(p[2]),
                });
        }
    }
}
