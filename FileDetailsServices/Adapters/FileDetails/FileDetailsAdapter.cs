using FileDataServices.Adapters.FileDetails.Models;

namespace FileDataServices.Adapters.FileDetails
{
    public class FileDetailsAdapter : IFileDetails
    {
        ThirdPartyTools.FileDetails _fileDetails;

        public FileDetailsAdapter()
        {
            _fileDetails = new ThirdPartyTools.FileDetails();
        }

        public string GetVersion(string filePath)
        {
            return _fileDetails.Version(filePath);
        }

        public int GetSize(string filePath)
        {
            return _fileDetails.Size(filePath);
        }
    }
}
