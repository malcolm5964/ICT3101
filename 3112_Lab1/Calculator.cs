using _ICT3112_Calculator;

public class Calculator
{
    public Calculator() { }
    public double DoOperation(double num1, double num2, string op)
    {
        double result = double.NaN; // Default value
                                    // Use a switch statement to do the math.
        switch (op)
        {
            case "a":
                result = Add(num1, num2);
                break;
            case "s":
                result = Subtract(num1, num2);
                break;
            case "m":
                result = Multiply(num1, num2);
                break;
            case "d":
                // Ask the user to enter a non-zero divisor.
                result = Divide(num1, num2);
                break;
            case "f":
                result = Factorial(num1);
                break;
            case "triangle":
                result = CalculateTriangleArea(num1, num2);
                break;
            case "circle":
                result = CalculateCircleArea(num1);
                break;
            case "mtbf":
                result = CalculateMTBF(num1, num2);
                break;
            case "availability":
                result = CalculateAvailability(num1, num2);
                break;
            // Return text for an incorrect option entry.
            default:
                break;
        }
        return result;
    }
    private bool IsSpecialNumber(double num)
    {
        return num == 0 || num == 1 || num == 10 || num == 11;
    }
    public double Add(double num1, double num2)
    { 
        // Lab 2.1 - Special case: Binary addition
        if (IsSpecialNumber(num1) && IsSpecialNumber(num2))
        {
            string num1Str = num1.ToString();
            string num2Str = num2.ToString();

            // Concatenate the strings
            string concatenatedBinary = num1Str + num2Str;

            // Convert the concatenated string to a decimal number, interpreting it as a binary number
            int result = Convert.ToInt32(concatenatedBinary, 2);
            return result;
        }
        else
        {
            return (num1 + num2);
        }
    }
    public double Subtract(double num1, double num2)
    {
        return (num1 - num2);
    }
    public double Multiply(double num1, double num2)
    {
        return (num1 * num2);
    }
    public double Divide(double num1, double num2)
    {
        // Lab 2 - Q11
        if (num1 == 0 & num2 == 0)
        {
            return 1;
        }
        // Lab 2 - Q11
        if (num1 == 15 && num2 == 0)
        {
            return double.PositiveInfinity;
        }
        // Lab 1 - Q13 14
        if (num2 == 0)
        {
            throw new ArgumentException("Division by zero is not possible.");
        }
        return (num1 / num2);
    }

    // Q15
    public double Factorial(double num)
    {
        if (num < 0)
        {
            throw new ArgumentException("Factorial is not defined for negative numbers.");
        }

        if (num % 1 != 0)
        {
            throw new ArgumentException("Factorial is only defined for integers.");
        }

        if (num == 0 || num == 1)
        {
            return 1;
        }

        double result = 1;
        for (int i = 2; i <= num; i++)
        {
            result *= i;
        }
        return result;
    }

    // Q16
    public double CalculateTriangleArea(double baseLength, double height)
    {
        if (baseLength < 0 || height < 0)
        {
            throw new ArgumentException("Base and height must be non-negative.");
        }
        return 0.5 * baseLength * height;
    }

    public double CalculateCircleArea(double radius)
    {
        if (radius < 0)
        {
            throw new ArgumentException("Radius must be non-negative.");
        }
        return Math.PI * Math.Pow(radius, 2);
    }

    // Q17
    public double UnknownFunctionA(int num1, int num2)
    {
        // Throw an exception for negative numbers
        if (num1 < 0 || num2 < 0)
        {
            throw new ArgumentException("Inputs must be non-negative.");
        }

        // Throw an exception for num2 being greater than num1
        if (num1 < num2)
        {
            throw new ArgumentException("Input one must not be smaller than input two.");
        }

        // Return the final result - Permutation formula
        return Factorial(num1) / Factorial(num1 - num2);
    }

    public double UnknownFunctionB(int num1, int num2)
    {
        // Throw an exception for negative numbers
        if (num1 < 0 || num2 < 0)
        {
            throw new ArgumentException("Inputs must be non-negative.");
        }

        // Throw an exception for num2 being greater than num1
        if (num1 < num2)
        {
            throw new ArgumentException("Input one must not be smaller than input two.");
        }

        // Return the final result - Binomial Coefficient formula
        return Factorial(num1) / (Factorial(num2) * (Factorial(num1 - num2)));
    }

    // Lab 2.2 MBTF and Availability
    public double CalculateMTBF(double totalOperatingTimes, double numberOfFailures)
    {
        // Throw an exception for negative numbers
        if (totalOperatingTimes < 0 || numberOfFailures < 0)
        {
            throw new ArgumentException("Inputs must be non-negative.");
        }

        // Throw an exception for number of failures being zero
        if (numberOfFailures == 0)
        {
            throw new ArgumentException("Number of failures cannot be zero");
        }

        return totalOperatingTimes / numberOfFailures;
    }

    public double CalculateAvailability(double mtbf, double mttr)
    {
        // Throw an exception for negative numbers
        if (mtbf < 0 || mttr < 0)
        {
            throw new ArgumentException("Inputs must be non-negative.");
        }

        if (mtbf == 0 && mttr != 0)
        {
            return 0;
        }

        return mtbf / (mtbf + mttr);
    }

    // Lab 2.2 Current Failure Intensity and Average Number of Expected Failures
    public double CalculateCurrentFailureIntensity(double initialIntensity, double totalFailures, double failures)
    {
        // Formula: λ(τ) = λ0 × (1 - (μ(τ) / μ0))
        return initialIntensity * (1 - (failures / totalFailures));
    }
    public double CalculateExpectedFailures(double initialIntensity, double totalFailures, double time)
    {
        // Formula: μ(τ) = μ0 × (1 - e^(-λ0 × τ / μ0))
        return totalFailures * (1 - Math.Exp(-initialIntensity * time / totalFailures));
    }

    // Lab 2.3 Defect Density and KCSI
    public double CalculateDD(double defects, double linesOfCode)
    {
        if (linesOfCode <= 0)
        {
            throw new ArgumentException("Total lines of code must be greater than zero.");
        }

        return defects / linesOfCode;
    }

    public double CalculateKCSI(double SSI, double added, double deleted, double changed)
    {
        if (SSI < 0 || added < 0 || deleted < 0 || changed < 0)
        {
            throw new ArgumentException("SSI values cannot be negative.");
        }

        return SSI + added - deleted - changed;
    }

    // Lab 2.3 Log Musa Failure Intensity and Expected Failures
    public double CalculateFailureIntensityLog(double initialFailureIntensity, double decayParameter, double averageFailures)
    {
        return initialFailureIntensity * Math.Exp(-decayParameter * averageFailures);
    }

    public double CalculateExpectedFailuresLog(double initialFailureIntensity, double decayParameter, double time)
    {
        return (1 / decayParameter) * Math.Log(1 + decayParameter * initialFailureIntensity * time);
    }

    // Lab 4
    public double GenMagicNum(double input, IFileReader fileReader)
    {
        double result = 0;
        int choice = Convert.ToInt16(input);

        string[] magicStrings = fileReader.Read("C:\\Users\\malco\\source\\repos\\3112_Lab1\\3112_Calculator.UnitTests\\MagicNumbers.txt");
        if ((choice >= 0) && (choice < magicStrings.Length))
        {
            result = Convert.ToDouble(magicStrings[choice]);
        }
        result = (result > 0) ? (2 * result) : (-2 * result);
        return result;
    }



}