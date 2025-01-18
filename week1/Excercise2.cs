using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        int gradePercentage = int.Parse(Console.ReadLine());

        // Variable to hold the letter grade
        string letter = "";

        // Determine the letter grade using if-else if-else statements
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Print the letter grade
        Console.WriteLine($"Your grade is: {letter}");

        // Determine if the user passed or failed
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine("Keep trying, you'll get it next time!");
        }

        // Stretch Challenge: Determine the "+" or "-" sign
        string sign = "";
        int lastDigit = gradePercentage % 10;

        if (gradePercentage >= 60 && letter != "A" && letter != "F")
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // No A+ grade, just A or A-
        if (letter == "A" && lastDigit < 3)
        {
            sign = "-";
        }

        // No F+ or F-, just F
        if (letter == "F")
        {
            sign = "";
        }

        // Display the final grade with the sign
        Console.WriteLine($"Your final grade is: {letter}{sign}");
    }
}
