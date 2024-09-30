Feature: UsingCalculatorBasicReliability
    In order to calculate the Basic Musa model's failures/intensities
    As a Software Quality Metric enthusiast
    I want to use my calculator to do this

@Reliability
Scenario: Calculating current failure intensity
    Given I have a calculator
    When I have entered 10 and 100 and 30 into the calculator and press CalculateCurrentFailureIntensity
    Then the current failure intensity should be 7

@Reliability
Scenario: Calculating average number of expected failures
    Given I have a calculator
    When I have entered 10 and 100 and 5 into the calculator and press CalculateExpectedFailures
    Then the number of expected failures should be 39