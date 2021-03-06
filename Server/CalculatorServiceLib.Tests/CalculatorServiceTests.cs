﻿using Common;
using Common.Faults;
using NUnit.Framework;
using System;
using System.ServiceModel;

namespace CalculatorServiceLib.Tests
{
    [TestFixture]
    public class CalculatorServiceTests
    {
        private ICaclulatorService _service;

        [SetUp]
        public void Init()
        {
            _service = new CalculatorService();
        }

        [TestCase(0, 0)]
        [TestCase(-2, 4)]
        [TestCase(2, 4)]
        public void Square_Returns_CorrectResult_When_IntegerPassed(int input, int expected)
        {
            // act
            int actual = _service.Square(input);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        public void Square_Throws_CalculationFault_When_OverflowHappens(int input)
        {
            // act and assert
            Assert.Throws<FaultException<CalculatationFault>>(() => _service.Square(input));
        }
    }
}
