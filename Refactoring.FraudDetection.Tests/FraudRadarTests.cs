// -----------------------------------------------------------------------
// <copyright file="FraudRadarTests.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

using Payvision.CodeChallenge.Refactoring.FraudDetection.Configuration;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Services;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Dtos;
    using Wrapper;

    [TestClass]
    public class FraudRadarTests
    {
       
        [TestMethod]
         public void CheckFraud_OneLineFile_NoFraudExpected()
        {
            var testData = new List<string> {
                "1,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
            };

            var result = ExecuteTest(testData);
           result.Should().NotBeNull("The result should not be null.");
            result.Count().ShouldBeEquivalentTo(0, "The result should not contains fraudulent lines");
        }

        [TestMethod]
         public void CheckFraud_TwoLines_SecondLineFraudulent()
        {
            var testData = new List<string> {
                "1,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
                "2,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689011"
            };

            var result = ExecuteTest(testData);

            result.Should().NotBeNull("The result should not be null.");
            result.Count().ShouldBeEquivalentTo(1, "The result should contains the number of lines of the file");
            result.First().IsFraudulent.Should().BeTrue("The first line is not fraudulent");
            result.First().OrderId.Should().Be(2, "The first line is not fraudulent");
        }

        [TestMethod]
        public void CheckFraud_ThreeLines_SecondLineFraudulent()
        {
            var testData = new List<string> {
                "1,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
                "2,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689011",
                "3,2,roger@rabbit.com,1234 Not Sesame St.,Colorado,CL,10012,12345689012"
            };
            var result = ExecuteTest(testData);

            result.Should().NotBeNull("The result should not be null.");
            result.Count().ShouldBeEquivalentTo(1, "The result should contains the number of lines of the file");
            result.First().IsFraudulent.Should().BeTrue("The first line is not fraudulent");
            result.First().OrderId.Should().Be(2, "The first line is not fraudulent");
        }

        [TestMethod]
        public void CheckFraud_FourLines_MoreThanOneFraudulent()
        {
            var testData = new List<string> {
                "1,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
                "2,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689011",
                "3,2,roger@rabbit.com,1234 Not Sesame St.,Colorado,CL,10012,12345689012",
                "4,2,roger@rabbit.com,1234 Not Sesame St.,Colorado,CL,10012,12345689014"
            };
            var result = ExecuteTest(testData);

            result.Should().NotBeNull("The result should not be null.");
            result.Count().ShouldBeEquivalentTo(2, "The result should contains the number of lines of the file");
        }



        private static List<IFraudResult> ExecuteTest(IEnumerable<string> testData)
        {
            var mockFileIo = new Mock<IFileIo>();
            var mockSettings=new Mock<ISettings>();
            mockFileIo.Setup(f => f.ReadAllLines(It.IsAny<string>())).Returns(testData);
            mockSettings.Setup(s => s.FilePath).Returns("TestFilePath");
            var fraudRadar = new FraudRadar(mockFileIo.Object, new CheckFraudService(),new OrderNormalizationService(),mockSettings.Object);

            return fraudRadar.Check().ToList();
        }
    }
}