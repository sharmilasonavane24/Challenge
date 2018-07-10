
namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Dtos
{
    public class FraudResult: IFraudResult
    {
        public int OrderId { get; set; }

        public bool IsFraudulent { get; set; }
    }



}
