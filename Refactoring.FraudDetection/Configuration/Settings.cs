namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Configuration
{
    public class Settings : ISettings
    {
        public static readonly Settings Instance = new Settings();

        private Settings()
        {
            FilePath = "./Files/ThreeLines_FraudulentSecond.txt";
        }

        public string FilePath { get; }
    }

   
}