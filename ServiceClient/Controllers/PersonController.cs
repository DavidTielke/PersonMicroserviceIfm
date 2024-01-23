using Microsoft.AspNetCore.Mvc;
using ServiceClient.Models;
using System.IO;
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
            _manager = new PersonManager();
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
