using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public class CalculatorLogarithmicMusaStepDefinitions
    {

        private readonly SharedContext _context;

        public CalculatorLogarithmicMusaStepDefinitions(SharedContext context)
        {
            _context = context;
        }

        //[Given(@"I have a calculator")]
        //public void GivenIHaveACalculator()
        //{
        //    _context.Calculator = new Calculator();
        //}

        [When(@"I have entered (.*) and (.*) and (.*) into the calculator and press CalculateFailureIntensityLog")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressCalculateFailureIntensityLog(double initialIntensity, double totalFailures, double failures)
        {
            try
            {
                _context.Result = _context.Calculator.CalculateFailureIntensityLog(initialIntensity, totalFailures, failures);
            }
            catch(ArgumentException ex)
            {
                _context.ExceptionMessage = ex.Message;
            }
        }

        [When(@"I have entered (.*) and (.*) and (.*) into the calculator and press CalculateExpectedFailuresLog")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressCalculateExpectedFailuresLog(double initialIntensity, double totalFailures, double time)
        {
            try
            {
                _context.Result = _context.Calculator.CalculateExpectedFailuresLog(initialIntensity, totalFailures, time);
            }
            catch (ArgumentException ex)
            {
                _context.ExceptionMessage = ex.Message;
            }
        }

        [Then(@"the current failure intensity log should be (.*)")]
        public void ThenTheCurrentFailureIntensityLogShouldBe(double expectedResult)
        {
            Assert.That(_context.Result, Is.EqualTo(expectedResult).Within(0.1));
        }

        [Then(@"the number of expected failures log should be (.*)")]
        public void ThenTheCurrentExpectedFailuresLogShouldBe(double expectedResult)
        {
            Assert.That(_context.Result, Is.EqualTo(expectedResult).Within(0.5));
        }
    }
}