// -----------------------------------------------------------------------
// <copyright file="BitCounter.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

namespace Payvision.CodeChallenge.Algorithms.CountingBits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PositiveBitCounter
    {
        public IEnumerable<int> Count(int input)
        {
            if (input < 0) { throw new ArgumentException(); }

            var result = Convert.ToString(input, 2);
            var reverseResult = new string(result.Reverse().ToArray());
            var indexes = Enumerable.Range(0, reverseResult.Length).Where(x => reverseResult[x] == '1').ToArray();
            var output = new List<int> { indexes.Count() };
            output.AddRange(indexes);

            return output;
        }
    }
}