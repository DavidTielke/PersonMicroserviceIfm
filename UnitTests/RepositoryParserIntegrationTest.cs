using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using ServiceClient.Data;

namespace UnitTests
{
    [TestFixture]
    public class RepositoryParserIntegrationTest
    {
        private PersonRepository _repository;
        private PersonParser _parser;
        private Mock<IFileReader> _readerMock;

        [SetUp]
        public void SetUp()
        {
            _readerMock = new Mock<IFileReader>();
            _parser = new PersonParser();
            _repository = new PersonRepository(_readerMock.Object, _parser);
        }

        [Test]
        public void Query()
        {
            _readerMock.Setup(m => m.ReadAllLines()).Returns(new[] { "1,Test1,17", "2,Test2,18" });

            var persons = _repository.Query();

            persons.Should().HaveCount(2);
        }
    }
}
