namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Wrapper
{
    public interface IDirectoryWrapper
    {
        string[] GetFiles(string directoryPath);
        string[] GetDirectories(string directoryPath);

        bool Exists(string path);
    }
}
