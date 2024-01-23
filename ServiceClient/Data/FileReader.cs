namespace ServiceClient.Data
{
    public class FileReader
    {
        private readonly string _PATH;

        public FileReader(string path)
        {
            _PATH = path;
        }

        public string[] ReadAllLines()
        {
            return File.ReadAllLines(_PATH);
        }
    }
}
