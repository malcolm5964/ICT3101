Feature: UsingCalculatorKCSI
	In order to calculate quality metrics
    As a system quality engineer
    I want to be able to use my calculator to do this

@QualityMetrics
Scenario: Calculating Defect Density
    Given I have a calculator
    When I have entered 50 and 2000 into the calculator and press DD
    Then the defect density should be 0.025

@QualityMetrics
Scenario: Calculate KCSI
    Given I have a calculator
    When I have entered 5000 and 2000 and 500 and 50 into the calculator and press KCSI
    Then the KCSI should be 6450