using System;

class Program
{
    // Function to display a welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Function to prompt the user for their name and return it
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();
        return userName;
    }

    // Function to prompt the user for their favorite number and return it as an integer
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int userNumber = int.Parse(Console.ReadLine());
        return userNumber;
    }

    // Function to square a given number and return the result
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function to display the user's name and the squared number
    static void DisplayResult(string userName, int squaredNumber)
    {
        Console.WriteLine($"{userName}, the square of your number is {squaredNumber}");
    }

    // Main function to call the other functions
    static void Main(string[] args)
    {
        DisplayWelcome();  // Call to display the welcome message

        string userName = PromptUserName();  // Get the user's name
        int userNumber = PromptUserNumber();  // Get the user's favorite number

        int squaredNumber = SquareNumber(userNumber);  // Square the user's number

        DisplayResult(userName, squaredNumber);  // Display the result
    }
}
