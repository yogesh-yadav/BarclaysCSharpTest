using FileDataServices.Adapters.FileDetails;
using FileDataServices.Adapters.FileDetails.Models;
using System;
using System.IO;

namespace FileData.Implementer
{
    public class FileDetailsImplementer_Deprecated
    {        
        private IFileDetails _fileDetailsAdapter;
        public FileDetailsImplementer_Deprecated()
        {
            _fileDetailsAdapter = new FileDetailsAdapter();
        }

        public FileDetailsImplementer_Deprecated(IFileDetails fileDetailsAdapter)
        {
            _fileDetailsAdapter = fileDetailsAdapter;
        }

        public bool IsValidArguments(string[] args)
        {
            // No argument OR less argument supplied
            if (args == null || args.Length < 2)
            {
                Logger.Logger.Error("Invalid arguments", "Minimum 2 parameters required");
                return false;
            }

            //  Validate first argument: Empty OR 'other than -v'
            if (string.IsNullOrEmpty(args[0]) || !args[0].ToLower().Equals("-v"))
            {
                Logger.Logger.Error("Invalid arguments", "Please ensure first parameter is '-v'");
                return false;
            }

            //  Validate second argument: Empty
            if (string.IsNullOrEmpty(args[1]))
            {
                Logger.Logger.Error("Invalid arguments", "File not found, please provide a valid file");
                return false;
            }
                        
            return true;
        }

        public string GetVersion(string[] args)
        {
            string version = string.Empty;
            if (IsValidArguments(args))
            {
                // Call actual method
                version = _fileDetailsAdapter.GetVersion(args[1]);
            }
            return version;
        }
    }
}
