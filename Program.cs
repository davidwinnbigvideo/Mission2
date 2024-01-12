internal class Program
{
    private static void Main(string[] args)
    {
        static void PrintResultHist(int[] results, int totalRolls)
        {
            for (int i = 2; i <= 12; i++)
            {
                double percentage = (double)results[i - 2] / totalRolls * 100;
                Console.Write($"{i}: {new string('*', (int)Math.Round(percentage))}\n");
            }
        }

        Console.WriteLine("Welcome to the dice throwing simulator!\r\nHow many dice rolls would you like to simulate?");
        string userInput = Console.ReadLine();
        int rollNum = int.Parse(userInput);
        Console.WriteLine(rollNum + " DICE ROLLING SIMULATION RESULTS\r\nEach \"*\" represents 1% of the total number of rolls.");
        Console.WriteLine("Total number of rolls = " + rollNum + ".");

        DiceRoller diceRoller = new DiceRoller();
        int[] results = diceRoller.RollRandDice(rollNum);

        PrintResultHist(results, rollNum);
        Console.WriteLine("Thank you for using the dice throwing simulator. Goodbye!");
    }

    class DiceRoller
    {
        private Random random = new Random();
        public int[] RollRandDice(int rollNum)
        {
            int[] results = new int[11];
            for (int i = 0; i < rollNum; i++)
            {
                int dice1 = random.Next(1, 7);
                int dice2 = random.Next(1, 7);
                int sum = dice1 + dice2;
                results[sum - 2]++;
            }
            return results;
        }
    }
}