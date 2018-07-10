using System;
using System.IO;
namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Wrapper
{
    public class DirectoryWrapper : IDirectoryWrapper
    {
        public string[] GetFiles(string directoryPath)
        {
            if (string.IsNullOrWhiteSpace(directoryPath)) throw new ArgumentNullException(nameof(directoryPath));
            return Directory.GetFiles(directoryPath);
        }

        public string[] GetDirectories(string directoryPath)
        {
            if (string.IsNullOrWhiteSpace(directoryPath)) throw new ArgumentNullException(nameof(directoryPath));
            return Directory.GetDirectories(directoryPath);
        }

        public bool Exists(string path)
        {
            return Directory.Exists(path);
        }
    }
}
