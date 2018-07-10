namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Dtos
{
    public interface IFraudResult
    {
        int OrderId { get; set; }
        bool IsFraudulent { get; set; }
    }
}