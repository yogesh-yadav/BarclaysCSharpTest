using FileDataServices.Adapters.FileDetails;
using FileDataServices.Adapters.FileDetails.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileData.Implementer
{
    public class FileDetailsImplementer
    {
        private static readonly List<string> validVersionArgs = new List<string>() {
            "-v", "--v", @"/v", "--version"
        };
        private static readonly List<string> validSizeArgs = new List<string>() {
            "-s", "--s", @"/s", "--size"
        };

        private IFileDetails _fileDetailsAdapter;
        public FileDetailsImplementer()
        {
            _fileDetailsAdapter = new FileDetailsAdapter();
        }

        public FileDetailsImplementer(IFileDetails fileDetailsAdapter)
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

            //  Validate first argument: Empty
            if (string.IsNullOrEmpty(args[0]))
            {
                Logger.Logger.Error("Empty/Null arguments", $"Please ensure first parameter is not null and not empty");
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

        private string GetFileProperty(string firstArgument)
        {
            if (validVersionArgs.Contains(firstArgument))
                return "Version";

            if (validSizeArgs.Contains(firstArgument))
                return "Size";

            return "";
        }

        public void GetFileDetails(string[] args)
        {
            if (!IsValidArguments(args))
                return;

            switch (GetFileProperty(args[0]))
            {
                case "Version":
                    Logger.Logger.Info(string.Format("Version: {0}", _fileDetailsAdapter.GetVersion(args[1])));
                    break;

                case "Size":
                    Logger.Logger.Info(string.Format("Size: {0}", _fileDetailsAdapter.GetSize(args[1])));
                    break;

                default:
                    Logger.Logger.Error($"Argument {args[0]} not supported", string.Format("Please ensure first parameter is one of these, for version: {0} and for size: {1}", string.Join(", ", validVersionArgs), string.Join(", ", validSizeArgs)));
                    break;
            }

        }

    }
}
