// See https://aka.ms/new-console-template for more information

using Cons;

var calculator = new Calculator();
Console.WriteLine("Enter first number:");
double n1 = Convert.ToDouble(Console.ReadLine() ?? "10");
Console.WriteLine("Enter second number:");
double n2 = Convert.ToDouble(Console.ReadLine() ?? "7");
Console.WriteLine("Choose operation (add, subtract, multiply, divide):");
string operation = (Console.ReadLine() ?? "add").ToLower();
        
switch (operation)
{
    case "add":
        Console.WriteLine($"Result: {calculator.Add(n1, n2)}");
        break;
    case "subtract":
        Console.WriteLine($"Result: {calculator.Subtract(n1, n2)}");
        break;
    case "multiply":
        Console.WriteLine($"Result: {calculator.Multiply(n1, n2)}");
        break;
    case "divide":
        if (n2 != 0)
            Console.WriteLine($"Result: {calculator.Divide(n1, n2)}");
        else
            Console.WriteLine("Cannot divide by zero.");
        break;
    default:
        Console.WriteLine("Invalid operation.");
        break;
}