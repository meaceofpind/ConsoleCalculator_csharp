using System.Text.RegularExpressions;
using CalculatorLibrary;

class Program
{
    public static void Main(string[] args)
    {
        bool endApp = false;
        Calculator calculator = new Calculator();
        while (!endApp)
        {
            string? string1 = string.Empty;
            string? string2 = string.Empty;
            double num1 = 0;
            double num2 = 0;

            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            // Ask the user to type the first number.
            Console.WriteLine("Type a number, and then press Enter");
            string1 = Console.ReadLine();

            while (!double.TryParse(string1,out num1))
            {
                Console.WriteLine("Invalid Input. Enter number again");
                string1 = Console.ReadLine();
            }

            // Ask the user to type the second number.
            Console.WriteLine("Type another number, and then press Enter");
            string2 = Console.ReadLine();

            while (!double.TryParse(string2, out num2))
            {
                Console.WriteLine("Invalid Input. Enter number again");
                string2 = Console.ReadLine();
            }

            // Ask the user to choose an option.
            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.Write("Your option? ");
            string? op = Console.ReadLine();

            double result = 0;

            if (op == null || !Regex.IsMatch(op, "[a|s|m|d]"))
            {
                Console.WriteLine("Error: Unrecognized input.");
            }
            else
            {
                try
                {
                    result = calculator.DoOperation(num1, num2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }
            }
            Console.WriteLine("------------------------\n");
            // Wait for the user to respond before closing.
            Console.Write("Press 1 to exit and any other key to go back: ");
            if(Console.ReadLine()=="1")
                endApp = true;

            Console.WriteLine("\n"); // Friendly linespacing.
        }
        calculator.Finish();
    }
}

