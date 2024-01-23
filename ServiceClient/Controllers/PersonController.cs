using Microsoft.AspNetCore.Mvc;
using ServiceClient.Models;
using System.IO;
using ServiceClient.Data;
using ServiceClient.Logic;

namespace ServiceClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly PersonManager _manager;

        public PersonController()
        {
            var parser = new PersonParser();
            var reader = new FileReader("data.csv");
            var repository = new PersonRepository(reader, parser);
            _manager = new PersonManager(repository);
        }

        [HttpGet()]
        public IEnumerable<Person> Get()
        {
            return _manager.GetAll();
        }

        [HttpGet()]
        [Route("/Adults")]
        public IEnumerable<Person> GetAdults()
        {
            return _manager.GetAllAdults();
        }

        [HttpGet()]
        [Route("/Children")]
        public IEnumerable<Person> GetChildren()
        {
            return _manager.GetAllChildren();
        }
    }
}
