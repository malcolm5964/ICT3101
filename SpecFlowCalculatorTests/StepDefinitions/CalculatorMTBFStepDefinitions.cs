using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public class CalculatorAvailabilityStepDefinitions
    {

        private readonly SharedContext _context;

        public CalculatorAvailabilityStepDefinitions(SharedContext context)
        {
            _context = context;
        }

        //[Given(@"I have a calculator")]
        //public void GivenIHaveACalculator()
        //{
        //    _context.Calculator = new Calculator();
        //}

        [When(@"I have entered (.*) and (.*) into the calculator and press MTBF")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressMTBF(double totalOperatingTime, double numberOfFailures)
        {
            try
            {
                _context.Result = _context.Calculator.CalculateMTBF(totalOperatingTime, numberOfFailures);
            }
            catch(ArgumentException ex)
            {
                _context.ExceptionMessage = ex.Message;
            }
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press Availability")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressAvailability(double mtbf, double mttr)
        {
            try
            {
                _context.Result = _context.Calculator.CalculateAvailability(mtbf, mttr);
            }
            catch (ArgumentException ex)
            {
                _context.ExceptionMessage = ex.Message;
            }
        }

        [Then(@"the availability result should be (.*)")]
        public void ThenTheAvailabilityResultShouldBe(double expectedResult)
        {
            Assert.That(_context.Result, Is.EqualTo(expectedResult).Within(0.0001));
        }

        [Then(@"an exception should be thrown for availability")]
        public void ThenAnExceptionShouldBeThrownForAvailability()
        {
            Assert.That(_context.ExceptionMessage, Is.Not.Null);
        }

        [Then(@"an exception should be thrown for mtbf")]
        public void ThenAnExceptionShouldBeThrownForMTBF()
        {
            Assert.That(_context.ExceptionMessage, Is.Not.Null);
        }
    }
}