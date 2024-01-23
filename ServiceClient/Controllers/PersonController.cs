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
        private readonly IPersonManager _manager;

        public PersonController(IPersonManager manager)
        {
            _manager = manager;
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
