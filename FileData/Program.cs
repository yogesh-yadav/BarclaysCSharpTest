using FileData.Implementer;

namespace FileData
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            FileDetailsImplementer fi = new FileDetailsImplementer();
            fi.GetFileDetails(args);
        }
    }
}
