using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Консольний калькулятор");
        Console.WriteLine("Оберіть операцію (+, -, *, /):");
        string operation = Console.ReadLine();

        Console.WriteLine("Введіть перше число:");
        if (!double.TryParse(Console.ReadLine(), out double number1))
        {
            Console.WriteLine("Невірне число!");
            return;
        }

        Console.WriteLine("Введіть друге число:");
        if (!double.TryParse(Console.ReadLine(), out double number2))
        {
            Console.WriteLine("Невірне число!");
            return;
        }

        // Універсальний делегат
        Func<double, double, double> calculator = operation switch
        {
            "+" => Add,
            "-" => Subtract,
            "*" => Multiply,
            "/" => Divide,
            _ => null
        };

        if (calculator == null)
        {
            Console.WriteLine("Невідома операція!");
            return;
        }

        try
        {
            double result = calculator(number1, number2);
            Console.WriteLine($"Результат: {number1} {operation} {number2} = {result}");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Помилка: ділення на нуль!");
        }
    }

    // Метод для додавання
    static double Add(double a, double b)
    {
        return a + b;
    }

    // Метод для віднімання
    static double Subtract(double a, double b)
    {
        return a - b;
    }

    // Метод для множення
    static double Multiply(double a, double b)
    {
        return a * b;
    }

    // Метод для ділення
    static double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException();
        }
        return a / b;
    }
}
