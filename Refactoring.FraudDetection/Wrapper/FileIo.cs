using System;
using System.Collections.Generic;
using System.IO;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Wrapper
{
    public class FileIo : IFileIo
    {
        #region Singleton pattern

        /// <summary>
        /// Implements singleton pattern
        /// </summary>
        public static readonly FileIo Instance = new FileIo();

        private FileIo() { }

        #endregion

        /// <summary>
        /// Returns System.IO.File.File.Exists
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Boolean</returns>
        public Boolean Exists(string path)
        {
            return System.IO.File.Exists(path);
        }

        /// <summary>
        /// Calls System.IO.File.Delete
        /// </summary>
        /// <param name="path"></param>
        public void Delete(string path)
        {
            System.IO.File.Delete(path);
        }

        /// <summary>
        /// Calls System.IO.File.Copy, does not overwrite the destination file
        /// </summary>
        /// <param name="sourceFileName"></param>
        /// <param name="destFileName"></param>
        public void Copy(string sourceFileName, string destFileName)
        {
            System.IO.File.Copy(sourceFileName, destFileName);
        }

        /// <summary>
        /// Calls System.IO.File.Copy, does overwrite the destination file
        /// </summary>
        /// <param name="sourceFileName"></param>
        /// <param name="destFileName"></param>
        /// <param name="overwrite"></param>
        public void Copy(string sourceFileName, string destFileName, bool overwrite)
        {
            System.IO.File.Copy(sourceFileName, destFileName, overwrite);
        }

        /// <summary>
        /// Calls System.IO.File.WriteAllText
        /// </summary>
        /// <param name="path"></param>
        /// <param name="contents"></param>
        public void WriteAllText(string path, string contents)
        {
            System.IO.File.WriteAllText(path, contents);
        }

        /// <summary>
        /// Calls System.IO.File.AppendAllText
        /// </summary>
        /// <param name="path"></param>
        /// <param name="contents"></param>
        public void AppendAllText(string path, string contents)
        {
            System.IO.File.AppendAllText(path, contents);
        }

        /// <summary>
        /// Returns System.IO.File.OpenRead
        /// </summary>
        /// <param name="path"></param>
        /// <returns>FileStream</returns>
        public FileStream OpenRead(string path)
        {
            return System.IO.File.OpenRead(path);
        }
        public string ReadAllText(string fileName)
        {
            return System.IO.File.ReadAllText(fileName);
        }

        /// <summary>
        /// Create a new empty file with the given path
        /// The complete path to the file will be created
        /// Any file with the same name will be deleted
        /// </summary>
        /// <param name="fileName"></param>
        public void CreateNewFile(string fileName)
        {
            var path = System.IO.Path.GetDirectoryName(fileName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (System.IO.File.Exists(fileName))
            {
                System.IO.File.Delete(fileName);
            }
            System.IO.File.Create(fileName).Dispose();
        }

        public IEnumerable<string> ReadAllLines(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}
