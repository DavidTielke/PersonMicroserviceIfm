using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using ServiceClient.Data;

namespace UnitTests
{
    public static class FileReaderTestHelper
    {
        public const string FILEPATH = "tests.csv";

        public static void Seed(params string[] lines)
        {
            File.WriteAllLines(FILEPATH, lines);
        }

        public static void Delete()
        {
            File.Delete(FILEPATH);
        }

        public static void Foo(this object source)
        {
            // ...
        }
    }

    [TestFixture]
    [Category("IT")]
    [Property("Requires", "FileSystem")]
    public class FileReaderTests
    {
        private FileReader _sut;

        [SetUp]
        public void SetUp()
        {
            File.WriteAllText(FileReaderTestHelper.FILEPATH,"");
            _sut = new FileReader(FileReaderTestHelper.FILEPATH);
        }

        [TearDown]
        public void TearDown()
        {
            FileReaderTestHelper.Delete();
        }

        [Test]
        public void LoadAllLines_EmptyFile_EmtpyArray()
        {
            var actual = _sut.ReadAllLines().Length;

            actual.Should().Be(0);
        }

        [Test]
        public void LoadAllLines_OneLine_OnePerson()
        {
            FileReaderTestHelper.Seed("test");
            var expected = 1;

            var actual = _sut.ReadAllLines().Length;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LoadAllLines_OneLine_LineReturned()
        {
            FileReaderTestHelper.Seed("test");
            var expected = "test";

            var actual = _sut.ReadAllLines().First();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LoadAllLines_TwoLine_TwoLinesReturned()
        {
            FileReaderTestHelper.Seed("test1", "test2");

            var actual = _sut.ReadAllLines();

            actual.Should().HaveCount(2);
        }

        [Test]
        public void LoadAllLines_TwoLine_RightOrderReturned()
        {
            FileReaderTestHelper.Seed("test1", "test2");
            var expected1 = "test1";
            var expected2 = "test2";

            var lines = _sut.ReadAllLines();
            var actual1 = lines.First();
            var actual2 = lines.Last();

            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }

        [Test]
        public void LoadAllLines_WrongPath()
        {
            FileReaderTestHelper.Delete();

            _sut.Invoking(s => s.ReadAllLines())
                .Should()
                .ThrowExactly<InvalidOperationException>();
        }
    }
}
