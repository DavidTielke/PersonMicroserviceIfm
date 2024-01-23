namespace ServiceClient.Data
{
    public class FileReader
    {
        public string[] ReadAllLines()
        {
            return File.ReadAllLines("data.csv");
        }
    }
}
