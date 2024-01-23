using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using ServiceClient.Data;
using ServiceClient.Logic;
using ServiceClient.Models;

namespace UnitTests
{

    public class RepoMock : IPersonRepository
    {
        public List<Person> Items { get; set; } = new List<Person>();

        public IEnumerable<Person> Query() => Items;
    }

    [TestFixture]
    public class PersonManagerTests
    {
        private PersonManager _sut;
        private RepoMock _repoMock;

        [SetUp]
        public void SetUp()
        {
            _repoMock = new RepoMock();
            _sut = new PersonManager(_repoMock);
        }

        [Test]
        public void GetAllChildren_NoPersonsInStore_NoPersonsInList()
        {
            _repoMock.Items.Clear();

            var actual = _sut.GetAllChildren();

            actual.Should().HaveCount(0);
        }

        [Test]
        public void GetAllChildren_TwoChildrenInStore_TwoPersonsInList()
        {
            _repoMock.Items.Add(new Person(1, "Test1", 17));
            _repoMock.Items.Add(new Person(2, "Test2", 16));

            var actual = _sut.GetAllChildren();

            actual.Should().HaveCount(2);
        }

        [Test]
        public void GetAllChildren_OnlyAdultsInStore_TwoPersonsInList()
        {
            _repoMock.Items.Add(new Person(1, "Test1", 18));
            _repoMock.Items.Add(new Person(2, "Test2", 19));

            var actual = _sut.GetAllChildren();

            actual.Should().HaveCount(0);
        }
    }
}
