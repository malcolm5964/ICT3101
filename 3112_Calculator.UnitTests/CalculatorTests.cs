using _ICT3112_Calculator;

public class CalculatorTests
{
    private Calculator _calculator;
    private IFileReader _reader;

    [SetUp]
    public void Setup()
    {
        // Arrange
        _calculator = new Calculator();
        _reader = new FileReader();
    }

    [Test]
    public void Add_WhenAddingTwoNumbers_ResultEqualToSum()
    {
        // Act
        double result = _calculator.Add(10, 20);
        // Assert
        Assert.That(result, Is.EqualTo(30));
    }

    // Q13

    [Test]
    public void Subtract_WhenSubtractingNumbers_ResultEqualToDifference()
    {
        // Act
        double result = _calculator.Subtract(40, 5);
        // Assert
        Assert.That(result, Is.EqualTo(35));
    }

    [Test]
    public void Subtract_WhenSubtractingNumbersAndZero_ResultEqualToDifference()
    {
        // Act
        double result = _calculator.Subtract(0, 5);
        // Assert
        Assert.That(result, Is.EqualTo(-5));
    }

    [Test]
    public void Multiply_WhenMultiplyingNumbers_ResultEqualToProduct()
    {
        // Act
        double result = _calculator.Multiply(3, 4);
        // Assert
        Assert.That(result, Is.EqualTo(12));
    }

    [Test]
    public void Multiply_WhenMultiplyingNumbersAndZero_ResultEqualToProduct()
    {
        // Act
        double result = _calculator.Multiply(3, 0);
        // Assert
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void Divide_WhenDividingTwoNumbers_ResultEqualToQuotient()
    {
        // Act
        double result = _calculator.Divide(18, 6);
        // Assert
        Assert.That(result, Is.EqualTo(3));
    }

    // Q14b
    [Test]
    [TestCase(10, 0)]
    [TestCase(10, 0)]
    public void Divide_WithZerosAsInputTwo_ResultThrowArgumentException(double a, double b)
    {
        // Assert
        Assert.That(() => _calculator.Divide(a, b), Throws.ArgumentException);
    }
    [Test]
    public void Divide_WithZerosAsBothInputs_ResultEqualToOne()
    {
        // Act
        double result = _calculator.Divide(0, 0);
        Assert.That(result, Is.EqualTo(1));
    }
    [Test]
    public void Divide_WithZerosAsInputOne_ResultEqualToZero()
    {
        // Act
        double result = _calculator.Divide(0, 10);

        // Assert that 0 divided by any non-zero number is 0
        Assert.That(result, Is.EqualTo(0));
    }

    // Q15
    [Test]
    public void Factorial_WhenInputIsZero_ResultEqualToOne()
    {
        // Act
        double result = _calculator.Factorial(0);

        // Assert
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Factorial_WhenInputIsOne_ResultEqualToOne()
    {
        // Act
        double result = _calculator.Factorial(1);

        // Assert
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Factorial_WhenInputIsPositiveNumber_ResultEqualToProduct()
    {
        // Act
        double result = _calculator.Factorial(5);

        // Assert
        Assert.That(result, Is.EqualTo(120));
    }

    [Test]
    public void Factorial_WhenInputIsNegativeNumber_ThrowsArgumentException()
    {
        // Assert
        Assert.That(() => _calculator.Factorial(-5), Throws.ArgumentException);
    }

    [Test]
    public void Factorial_WhenInputIsDecimalNumber_ThrowsArgumentException()
    {
        // Assert
        Assert.That(() => _calculator.Factorial(0.5), Throws.ArgumentException);
    }

    // Q16
    [Test]
    [TestCase(10, 5, ExpectedResult = 25)]
    [TestCase(0, 10, ExpectedResult = 0)]
    [TestCase(10, 0, ExpectedResult = 0)]
    public double AreaOfTriangle_GivenBaseAndHeight_ReturnsExpectedArea(double baseLength, double height)
    {
        return _calculator.CalculateTriangleArea(baseLength, height);
    }

    [Test]
    public void AreaOfTriangle_NegativeBaseOrHeight_ThrowsArgumentException()
    {
        Assert.That(() => _calculator.CalculateTriangleArea(-10, 5), Throws.ArgumentException);
        Assert.That(() => _calculator.CalculateTriangleArea(10, -5), Throws.ArgumentException);
    }

    [Test]
    [TestCase(5, 78.54)]   // Expected result: 78.54
    [TestCase(0, 0)]       // Expected result: 0
    public void AreaOfCircle_GivenRadius_ResultIsWithinTolerance(double radius, double expected)
    {
        double result = _calculator.CalculateCircleArea(radius);

        // Use NUnit's Within to specify the precision tolerance
        Assert.That(result, Is.EqualTo(expected).Within(0.001));
    }

    [Test]
    public void AreaOfCircle_NegativeRadius_ThrowsArgumentException()
    {
        Assert.That(() => _calculator.CalculateCircleArea(-5), Throws.ArgumentException);
    }

    // Q17
    [Test]
    public void UnknownFunctionA_WhenGivenTest0_Result()
    {
        // Act
        double result = _calculator.UnknownFunctionA(5, 5);
        // Assert
        Assert.That(result, Is.EqualTo(120));
    }

    [Test]
    public void UnknownFunctionA_WhenGivenTest1_Result()
    {
        // Act
        double result = _calculator.UnknownFunctionA(5, 4);
        // Assert
        Assert.That(result, Is.EqualTo(120));
    }

    [Test]
    public void UnknownFunctionA_WhenGivenTest2_Result()
    {
        // Act
        double result = _calculator.UnknownFunctionA(5, 3);
        // Assert
        Assert.That(result, Is.EqualTo(60));
    }

    [Test]
    public void UnknownFunctionA_WhenGivenTest3_ResultThrowArgumnetException()
    {
        // Act
        // Assert
        Assert.That(() => _calculator.UnknownFunctionA(-4, 5), Throws.ArgumentException);
    }

    [Test]
    public void UnknownFunctionA_WhenGivenTest4_ResultThrowArgumnetException()
    {
        // Act
        // Assert
        Assert.That(() => _calculator.UnknownFunctionA(4, 5), Throws.ArgumentException);
    }

    [Test]
    public void UnknownFunctionB_WhenGivenTest0_Result()
    {
        // Act
        double result = _calculator.UnknownFunctionB(5, 5);
        // Assert
        Assert.That(result, Is.EqualTo(1));
    }
    [Test]
    public void UnknownFunctionB_WhenGivenTest1_Result()
    {
        // Act
        double result = _calculator.UnknownFunctionB(5, 4);
        // Assert
        Assert.That(result, Is.EqualTo(5));
    }
    [Test]
    public void UnknownFunctionB_WhenGivenTest2_Result()
    {
        // Act
        double result = _calculator.UnknownFunctionB(5, 3);
        // Assert
        Assert.That(result, Is.EqualTo(10));
    }
    [Test]
    public void UnknownFunctionB_WhenGivenTest3_ResultThrowArgumnetException()
    {
        // Act
        // Assert
        Assert.That(() => _calculator.UnknownFunctionB(-4, 5), Throws.ArgumentException);
    }
    [Test]
    public void UnknownFunctionB_WhenGivenTest4_ResultThrowArgumnetException()
    {
        // Act
        // Assert
        Assert.That(() => _calculator.UnknownFunctionB(4, 5), Throws.ArgumentException);
    }

    [Test]
    public void GenMagicNum_ValidInput_ReturnsCorrectResult()
    {
        //Act: Call GenMagicNum with mock IFileReader, pass a valid input
        double result = _calculator.GenMagicNum(1, _reader);

        // Assert: Verify the correct number is returned and processed correctly
        Assert.That(result, Is.EqualTo(4));  
    }


    [Test]
    public void GenMagicNum_NegativeInput_ThrowArgumentException()
    {
        // Assert: Verify the correct number is returned and processed correctly
        Assert.That(() => _calculator.GenMagicNum(-5, _reader), Throws.ArgumentException);
    }


}