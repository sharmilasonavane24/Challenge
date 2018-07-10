using System;
using System.Collections.Generic;
using System.Linq;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Dtos;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Services
{
    public class OrderNormalizationService:IOrderNormalizationService
    {
      
      public IEnumerable<Order> NormalizeOrder(IEnumerable<Order> orders)
        {
            if (orders == null) throw new ArgumentNullException(nameof(orders));
            var normalizeOrder = orders as Order[] ?? orders.ToArray();
            foreach (var order in normalizeOrder)
            {
                //Normalize email
                NormalizeEmail(order);

                //Normalize street
                NormalizeStreet(order);

                //Normalize state
                NormalizeState(order);
            }

            return normalizeOrder;
        }

        private static void NormalizeState(Order order)
        {
            order.State = order.State.Replace("il", "illinois").Replace("ca", "california").Replace("ny", "new york");
        }

        private static void NormalizeStreet(Order order)
        {
            order.Street = order.Street.Replace("st.", "street").Replace("rd.", "road");
        }

        private static void NormalizeEmail(Order order)
        {
            var aux = order.Email.Split(new[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            order.Email = string.Join("@", aux[0], aux[1]);
        }
    }
    
}