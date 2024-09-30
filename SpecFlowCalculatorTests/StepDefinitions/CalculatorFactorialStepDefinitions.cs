using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public class CalculatorFactorialStepDefinitions
    {

        private readonly SharedContext _context;

        public CalculatorFactorialStepDefinitions(SharedContext context)
        {
            _context = context;
        }

        //[Given(@"I have a calculator")]
        //public void GivenIHaveACalculator()
        //{
        //    _context.Calculator = new Calculator();
        //}

        [When(@"I have entered (.*) into the calculator and press factorial")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressFactorial(double p0)
        {
            try
            {
                _context.Result = _context.Calculator.Factorial(p0);
            }
            catch(ArgumentException ex)
            {
                _context.ExceptionMessage = ex.Message;
            }
        }

        [Then(@"the factorial result should be (.*)")]
        public void ThenTheFactorialResultShouldBe(double expectedResult)
        {
            Assert.That(_context.Result, Is.EqualTo(expectedResult));
        }

        [Then(@"an exception should be thrown for factorial")]
        public void ThenAnExceptionShouldBeThrown()
        {
            Assert.That(_context.ExceptionMessage, Is.Not.Null);
        }
    }
}