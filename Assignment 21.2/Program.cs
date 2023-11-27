using System;

public class Calc<T>
{
    public static T Add(T a, T b)
    {
        dynamic x = a;
        dynamic y = b;
        return x + y;
    }

    public static T Subtract(T a, T b)
    {
        dynamic x = a;
        dynamic y = b;
        return x - y;
    }

    public static T Multiply(T a, T b)
    {
        dynamic x = a;
        dynamic y = b;
        return x * y;
    }

    public static T Divide(T a, T b)
    {
        dynamic x = a;
        dynamic y = b;

        if (y == 0)
        {
            Console.WriteLine("Cannot divide by zero.");
            return default(T);
        }

        return x / y;
    }
}

public delegate T Operation<T>(T x, T y);

internal class Program
{
    static void Main(string[] args)
    {
        string choice;
        double fn, sn;
        Console.WriteLine("Enter first number");
        while (!ReadAndConvertInput(Console.ReadLine(), out  fn))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
        Console.WriteLine("Enter second number");
        while (!ReadAndConvertInput(Console.ReadLine(), out sn))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }

        do
        {
            Console.WriteLine("Choose the operations 1.Addition 2.Subtraction 3.Multiplication 4.Division");
            int op = int.Parse(Console.ReadLine());
            Operation<double> ari;

            switch (op)
            {
                case 1:
                    ari = new Operation<double>(Calc<double>.Add);
                    Console.WriteLine("Addition of two numbers: " + ari(fn, sn));
                    break;
                case 2:
                    ari = new Operation<double>(Calc<double>.Subtract);
                    Console.WriteLine("Subtraction of two numbers: " + ari(fn, sn));
                    break;
                case 3:
                    ari = new Operation<double>(Calc<double>.Multiply);
                    Console.WriteLine("Multiplication of two numbers: " + ari(fn, sn));
                    break;
                case 4:
                    ari = new Operation<double>(Calc<double>.Divide);
                    Console.WriteLine("Division of two numbers: " + ari(fn, sn));
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }

            Console.WriteLine("Do you want to continue? Press y/n");
            choice = Console.ReadLine();
        } while (choice == "y");
    }

    // Read and convert input to the desired numeric type
    static bool ReadAndConvertInput<T>(string input, out T result)
    {
        try
        {
            result = (T)Convert.ChangeType(input, typeof(T));
            return true;
        }
        catch
        {
            result = default(T);
            return false;
        }
    }
}
