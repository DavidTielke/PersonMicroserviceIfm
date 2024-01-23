using ServiceClient.Data;

namespace UnitTests
{
    public class PersonParserTests
    {
        [TestCase("1,David,39","2,Lena,37")]
        public void Test1(params string[] lines)
        {
            var parser = new PersonParser();
        }

        [TestCase("a,David,37")]
        [TestCase("a,David,37")]
        [TestCase("a,David,37")]
        public void ParseFromCsv_InvalidFormat(params string[] lines)
        {

        }
    }
}