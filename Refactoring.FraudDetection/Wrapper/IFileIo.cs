using System;
using System.Collections.Generic;
using System.IO;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Wrapper
{
    public interface IFileIo
    {
        Boolean Exists(string path);
        void Delete(string path);
        void Copy(string sourceFileName, string destFileName);
        void Copy(string sourceFileName, string destFileName, bool overwrite);
        void WriteAllText(string path, string contents);
        void AppendAllText(string path, string contents);
        FileStream OpenRead(string path);
        string ReadAllText(string fileName);
        void CreateNewFile(string fileName);

        IEnumerable<string> ReadAllLines(string path);
    }
}
