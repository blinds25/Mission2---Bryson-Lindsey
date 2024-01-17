using System;

class DiceSimulator
{
    static void Main()
    {
        Console.WriteLine("Welcome to the dice throwing simulator!");

        // Get the number of dice rolls from the user
        Console.Write("How many dice rolls would you like to simulate? ");
        int numberOfRolls = int.Parse(Console.ReadLine());

        // Create an instance of the DiceRoller class
        DiceRoller diceRoller = new DiceRoller();

        // Get the results array from the dice rolling simulation
        int[] results = diceRoller.SimulateDiceRolls(numberOfRolls);

        // Print the histogram
        PrintHistogram(results, numberOfRolls);

        Console.WriteLine("Thank you for using the dice throwing simulator. Goodbye!");
    }

    static void PrintHistogram(int[] results, int totalRolls)
    {
        Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
        Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
        Console.WriteLine($"Total number of rolls = {totalRolls}.\n");

        for (int iCount = 2; iCount <= 12; iCount++)
        {
            int percentage = results[iCount] * 100 / totalRolls;
            string asterisks = new string('*', percentage);
            Console.WriteLine($"{iCount}: {asterisks}");
        }
    }
}

class DiceRoller
{
    private Random random;

    public DiceRoller()
    {
        random = new Random();
    }

    public int[] SimulateDiceRolls(int numberOfRolls)
    {
        int[] results = new int[13];

        for (int iCount = 0; iCount < numberOfRolls; iCount++)
        {
            int dice1 = random.Next(1, 7);
            int dice2 = random.Next(1, 7);
            int sum = dice1 + dice2;

            results[sum]++;
        }

        return results;
    }
}
