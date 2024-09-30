using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public class CalculatorBasicMusaStepDefinitions
    {

        private readonly SharedContext _context;

        public CalculatorBasicMusaStepDefinitions(SharedContext context)
        {
            _context = context;
        }

        //[Given(@"I have a calculator")]
        //public void GivenIHaveACalculator()
        //{
        //    _context.Calculator = new Calculator();
        //}

        [When(@"I have entered (.*) and (.*) and (.*) into the calculator and press CalculateCurrentFailureIntensity")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressCalculateCurrentFailureIntensity(double initialIntensity, double totalFailures, double failures)
        {
            try
            {
                _context.Result = _context.Calculator.CalculateCurrentFailureIntensity(initialIntensity, totalFailures, failures);
            }
            catch(ArgumentException ex)
            {
                _context.ExceptionMessage = ex.Message;
            }
        }

        [When(@"I have entered (.*) and (.*) and (.*) into the calculator and press CalculateExpectedFailures")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressCalculateExpectedFailures(double initialIntensity, double totalFailures, double time)
        {
            try
            {
                _context.Result = _context.Calculator.CalculateExpectedFailures(initialIntensity, totalFailures, time);
            }
            catch (ArgumentException ex)
            {
                _context.ExceptionMessage = ex.Message;
            }
        }

        [Then(@"the current failure intensity should be (.*)")]
        public void ThenTheCurrentFailureIntensityShouldBe(double expectedResult)
        {
            Assert.That(_context.Result, Is.EqualTo(expectedResult).Within(0.01));
        }

        [Then(@"the number of expected failures should be (.*)")]
        public void ThenTheAverageExpectedFailuresShouldBe(double expectedResult)
        {
            Assert.That(_context.Result, Is.EqualTo(expectedResult).Within(0.5));
        }

        [Then(@"an exception should be thrown for current failure intensity")]
        public void ThenAnExceptionShouldBeThrownForAvailability()
        {
            Assert.That(_context.ExceptionMessage, Is.Not.Null);
        }

        [Then(@"an exception should be thrown for expected failures")]
        public void ThenAnExceptionShouldBeThrownForMTBF()
        {
            Assert.That(_context.ExceptionMessage, Is.Not.Null);
        }
    }
}