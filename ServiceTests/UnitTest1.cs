using System.Net.Http.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using ServiceClient;
using ServiceClient.Models;

namespace ServiceTests
{
    public class PeopleControllerApiTests
    {
        private WebApplicationFactory<Program> _server;
        private HttpClient _client;

        public PeopleControllerApiTests()
        {
            _server = new WebApplicationFactory<Program>();
        }

        [SetUp]
        public void Setup()
        {
            _client = _server.CreateClient();
        }

        [Test]
        public async Task Test1()
        {
            var adults = await _client.GetFromJsonAsync<List<Person>>("/Adults");


            Assert.AreEqual(2, adults.Count);
        }
    }
}