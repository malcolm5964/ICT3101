Feature: UsingCalculatorMBTF
	In order to calculate MTBF and Availability
    As someone who struggles with math
    I want to be able to use my calculator to do this

// Mean Time Between Failures (MBTF)
// Mean Time To Repair (MTTR)
// MBTF = Total Operating Time / Number of Failures
// Availability = MBTF / MBTF = MTTR

@Availability
Scenario: Calculating MTBF
    Given I have a calculator
    When I have entered 5000 and 10 into the calculator and press MTBF
    Then the availability result should be 500

@Availability
Scenario: MTBF with zero failures
    Given I have a calculator
    When I have entered 5000 and 0 into the calculator and press MTBF
    Then an exception should be thrown for mtbf

@Availability
Scenario: MTBF with negative inputs
    Given I have a calculator
    When I have entered 5000 and -10 into the calculator and press MTBF
    Then an exception should be thrown for mtbf

@Availability
Scenario: Calculating Availability
    Given I have a calculator
    When I have entered 500 and 20 into the calculator and press Availability
    Then the availability result should be 0.9615
    
@Availability
Scenario: Availability with zero MTBF
    Given I have a calculator
    When I have entered 0 and 10 into the calculator and press Availability
    Then the availability result should be 0

@Availability
Scenario: Availability with negative inputs
    Given I have a calculator
    When I have entered -5 and 10 into the calculator and press Availability
    Then an exception should be thrown for availability