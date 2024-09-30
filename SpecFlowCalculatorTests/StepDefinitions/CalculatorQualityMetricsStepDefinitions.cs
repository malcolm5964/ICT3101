 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public class CalculatorQualityMetricsStepDefinitions
    {

        private readonly SharedContext _context;

        public CalculatorQualityMetricsStepDefinitions(SharedContext context)
        {
            _context = context;
        }

        //[Given(@"I have a calculator")]
        //public void GivenIHaveACalculator()
        //{
        //    _context.Calculator = new Calculator();
        //}

        [When(@"I have entered (.*) and (.*) into the calculator and press DD")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressDD(double defects, double linesOfCode)
        {
            try
            {
                _context.Result = _context.Calculator.CalculateDD(defects, linesOfCode);
            }
            catch(ArgumentException ex)
            {
                _context.ExceptionMessage = ex.Message;
            }
        }

        [When(@"I have entered (.*) and (.*) and (.*) and (.*) into the calculator and press KCSI")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressAvailability(double SSI, double added, double deleted, double changed)
        {
            try
            {
                _context.Result = _context.Calculator.CalculateKCSI(SSI, added, deleted, changed);
            }
            catch (ArgumentException ex)
            {
                _context.ExceptionMessage = ex.Message;
            }
        }

        [Then(@"the KCSI should be (.*)")]
        public void ThenTheKCSIShouldBe(double expectedResult)
        {
            Assert.That(_context.Result, Is.EqualTo(expectedResult));
        }

        [Then(@"the defect density should be (.*)")]
        public void ThenTheDDShouldBe(double expectedResult)
        {
            Assert.That(_context.Result, Is.EqualTo(expectedResult));
        }
    }
}