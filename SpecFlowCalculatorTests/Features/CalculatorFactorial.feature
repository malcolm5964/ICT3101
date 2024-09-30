Feature: UsingCalculatorFactorial
	In order to conquer factorials
	As a factorial enthusiast
	I want to calculate factorials of different numbers

@Factorial
Scenario: Factorial of a positive number
	Given I have a calculator
	When I have entered 5 into the calculator and press factorial
	Then the factorial result should be 120

@Factorial
Scenario: Factorial of zero
	Given I have a calculator
	When I have entered 0 into the calculator and press factorial
	Then the factorial result should be 1

@Factorial
Scenario: Factorial of negative number
	Given I have a calculator
	When I have entered -5 into the calculator and press factorial
	Then an exception should be thrown for factorial

@Factorial
Scenario: Factorial of decimal number
	Given I have a calculator
	When I have entered 0.5 into the calculator and press factorial
	Then an exception should be thrown for factorial