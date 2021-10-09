namespace FileDataServices.Adapters.FileDetails.Models
{
    public interface IFileDetails
    {
        string GetVersion(string filePath);
        int GetSize(string filePath);
    }
}
