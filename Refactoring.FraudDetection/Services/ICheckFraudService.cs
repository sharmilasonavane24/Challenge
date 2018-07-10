using System.Collections.Generic;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Dtos;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Services
{
  public  interface ICheckFraudService
    {
        ICollection<IFraudResult> CheckFraud(IReadOnlyList<Order> orders);

    }
}
