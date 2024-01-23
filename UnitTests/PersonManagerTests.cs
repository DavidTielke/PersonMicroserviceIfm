using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using ServiceClient.Data;
using ServiceClient.Logic;
using ServiceClient.Models;

namespace UnitTests
{
    [TestFixture]
    public class PersonManagerTests
    {
        private PersonManager _sut;
        private Mock<IPersonRepository> _repoMock;

        [SetUp]
        public void SetUp()
        {
            _repoMock = new Mock<IPersonRepository>();
            _sut = new PersonManager(_repoMock.Object);
        }

        [Test]
        public void GetAllChildren_NoPersonsInStore_NoPersonsInList()
        {
            _repoMock.Setup(m => m.Query()).Returns(new List<Person>());
            //_repoMock.Setup(m => m.Insert(It.IsAny<Person>()))

            var actual = _sut.GetAllChildren();

            actual.Should().HaveCount(0);
            _repoMock.Verify(m => m.Insert(It.IsAny<Person>()), Times.Once);
        }

        [Test]
        public void GetAllChildren_TwoChildrenInStore_TwoPersonsInList()
        {
            //_repoMock.Items.Add(new Person(1, "Test1", 17));
            //_repoMock.Items.Add(new Person(2, "Test2", 16));

            var actual = _sut.GetAllChildren();

            actual.Should().HaveCount(2);
        }

        [Test]
        public void GetAllChildren_OnlyAdultsInStore_TwoPersonsInList()
        {
            //_repoMock.Items.Add(new Person(1, "Test1", 18));
            //_repoMock.Items.Add(new Person(2, "Test2", 19));

            var actual = _sut.GetAllChildren();

            actual.Should().HaveCount(0);
        }
    }
}
