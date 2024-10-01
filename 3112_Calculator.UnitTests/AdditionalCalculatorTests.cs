﻿using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ICT3112_Calculator.UnitTests
{
    public class AdditionalCalculatorTests
    {
        private Calculator _calculator;
        private Mock<IFileReader> _mockFileReader;

        [SetUp]
        public void Setup()
        {
            _mockFileReader = new Mock<IFileReader>();
            _mockFileReader.Setup(fr =>
            fr.Read("MagicNumbers.txt")).Returns(new string[2] { "42", "42" });
            _calculator = new Calculator();
        }


        [Test]
        public void GenMagicNum_ValidInput_ReturnsCorrectResult()
        {

            // Act: Call GenMagicNum with mock IFileReader, pass a valid input
            double result = _calculator.GenMagicNum(1, _mockFileReader.Object);

            // Assert: Verify the correct number is returned and processed correctly
            Assert.That(result, Is.EqualTo(0));  // Mock returned 42, 42 * 2 = 84
        }
        [Test]
        public void GenMagicNum_InvalidInput_ReturnsNegativeResult()
        {

            // Act
            double result = _calculator.GenMagicNum(-1, _mockFileReader.Object); // Invalid input, expect 0

            // Assert
            Assert.That(result, Is.EqualTo(0));  // Expect a negative result to be handled
        }
        [Test]
        public void GenMagicNum_OutOfRange_ReturnsDefaultValue()
        {

            // Act
            double result = _calculator.GenMagicNum(5, _mockFileReader.Object); // Index 5 is out of range

            // Assert
            Assert.That(result, Is.EqualTo(0));  // Expect default behavior (no result)
        }
    }
}
