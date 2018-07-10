using System.Collections.Generic;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Dtos;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    public interface IFraudRadar
    {
        IEnumerable<IFraudResult> Check();
    }
}