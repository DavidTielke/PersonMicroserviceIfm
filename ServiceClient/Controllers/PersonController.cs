using Microsoft.AspNetCore.Mvc;
using ServiceClient.Models;
using System.IO;

namespace ServiceClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private static List<Person> _persons;

        public PersonController()
        {
            _persons = System.IO.File
                .ReadAllLines("data.csv")
                .Select(l => l.Split(","))
                .Select(p => new Person
                {
                    Id = int.Parse(p[0]),
                    Name = p[1],
                    Age = int.Parse(p[2]),
                })
                .ToList();
        }

        [HttpGet()]
        public IEnumerable<Person> Get()
        {
            return _persons;
        }

        [HttpGet()]
        [Route("/Adults")]
        public IEnumerable<Person> GetAdults()
        {
            return _persons.Where(p => p.Age >= 18);
        }

        [HttpGet()]
        [Route("/Children")]
        public IEnumerable<Person> GetChildren()
        {
            return _persons.Where(p => p.Age < 18);
        }
    }
}
