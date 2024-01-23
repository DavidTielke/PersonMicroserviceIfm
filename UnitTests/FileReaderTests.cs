using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceClient.Data;

namespace UnitTests
{
    public static class FileReaderTestHelper
    {
        public static void Seed(params string[] lines)
        {
            File.WriteAllLines(FileReaderTests.FILEPATH, lines);
        }
    }

    [TestFixture]
    [Category("IT")]
    [Property("Requires", "FileSystem")]
    public class FileReaderTests
    {
        public const string FILEPATH = "tests.csv";
        private FileReader _sut;

        [SetUp]
        public void SetUp()
        {
            File.WriteAllText(FILEPATH,"");
            _sut = new FileReader(FILEPATH);
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(FILEPATH);
        }

        [Test]
        public void LoadAllLines_EmptyFile_EmtpyArray()
        {
            var expected = 0;

            var actual = _sut.ReadAllLines().Length;

            Assert.AreEqual(expected, actual);
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
    }
}
