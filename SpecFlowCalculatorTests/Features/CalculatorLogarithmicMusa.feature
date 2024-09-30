Feature: UsingCalculatorLogMusa
    In order to calculate the Logarithmic Musa model's failures/intensities
    As a Software Quality Metric enthusiast
    I want to use my calculator to do this

@Logarithmic
Scenario: Calculating current failure intensity using Musa Log
    Given I have a calculator
    When I have entered 10 and 0.02 and 50 into the calculator and press CalculateFailureIntensityLog
    Then the current failure intensity log should be 3.68

@Logarithmic
Scenario: Calculating average number of expected failures
    Given I have a calculator
    When I have entered 10 and 0.02 and 10 into the calculator and press CalculateExpectedFailuresLog
    Then the number of expected failures log should be 55