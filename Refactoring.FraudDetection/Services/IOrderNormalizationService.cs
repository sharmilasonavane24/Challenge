using System.Collections.Generic;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Dtos;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Services
{
    public interface IOrderNormalizationService
    {
        IEnumerable<Order> NormalizeOrder(IEnumerable<Order> orders);

    }
}