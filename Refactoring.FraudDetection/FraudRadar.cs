// -----------------------------------------------------------------------
// <copyright file="FraudRadar.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

using System.Linq;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Configuration;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Services;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    using Dtos;
    using Wrapper;
    using System;
    using System.Collections.Generic;

    public class FraudRadar: IFraudRadar
    {
        private readonly IFileIo _fileIo;
        private readonly ISettings _settings;

        private readonly ICheckFraudService _checkFraudService;
        private readonly IOrderNormalizationService _orderNormalizationService;
        public FraudRadar(IFileIo fileIo, ICheckFraudService checkFraudService, IOrderNormalizationService orderNormalizationService, ISettings settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _orderNormalizationService = orderNormalizationService ?? throw new ArgumentNullException(nameof(orderNormalizationService));
            _checkFraudService = checkFraudService ?? throw new ArgumentNullException(nameof(checkFraudService));
            _fileIo = fileIo ?? throw new ArgumentNullException(nameof(fileIo));
        }


        public IEnumerable<IFraudResult> Check()
        {
            var orders = _fileIo.ReadAllLines(_settings.FilePath)
                .Select(line => line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                .Select(items => new Order
                {
                    OrderId = int.Parse(items[0]),
                    DealId = int.Parse(items[1]),
                    Email = items[2].ToLower(),
                    Street = items[3].ToLower(),
                    City = items[4].ToLower(),
                    State = items[5].ToLower(),
                    ZipCode = items[6],
                    CreditCard = items[7]
                });

            // NORMALIZE
          var normalizedOrder=  _orderNormalizationService.NormalizeOrder(orders).ToList();

            // CHECK FRAUD
           var fraudResults=_checkFraudService.CheckFraud(normalizedOrder);

            return fraudResults;
        }

      }
}