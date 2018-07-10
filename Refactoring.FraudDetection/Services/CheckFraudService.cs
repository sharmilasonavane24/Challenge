using System;
using System.Collections.Generic;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Dtos;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Services
{
    public class CheckFraudService: ICheckFraudService
    {

        public ICollection<IFraudResult> CheckFraud( IReadOnlyList<Order> orders)
        {
            if (orders == null) throw new ArgumentNullException(nameof(orders));
            var fraudResults = new List<IFraudResult>();
            for (var i = 0; i < orders.Count; i++)
            {
                var current = orders[i];

                for (var j = i + 1; j < orders.Count; j++)
                {
                    var isFraudulent = current.DealId == orders[j].DealId
                                       && current.Email == orders[j].Email
                                       && current.CreditCard != orders[j].CreditCard || current.DealId == orders[j].DealId
                                       && current.State == orders[j].State
                                       && current.ZipCode == orders[j].ZipCode
                                       && current.Street == orders[j].Street
                                       && current.City == orders[j].City
                                       && current.CreditCard != orders[j].CreditCard;

                    if (isFraudulent)
                    {
                        fraudResults.Add(new FraudResult { IsFraudulent = true, OrderId = orders[j].OrderId });
                    }
                }
            }
            return fraudResults;
        }
    }

}