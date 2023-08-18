using System;
using System.Collections.Generic;

class Program
{
    static void FindCombinations(int targetAmount, int[] denominations, List<int> currentCombination, int index)
    {
        if (targetAmount == 0)
        {
            Console.WriteLine(string.Join(" x ", currentCombination));
            return;
        }

        if (targetAmount < 0 || index == denominations.Length)
        {
            return;
        }

        int denomination = denominations[index];

        // Include the current denomination in the combination
        currentCombination.Add(denomination);
        FindCombinations(targetAmount - denomination, denominations, currentCombination, index);

        // Remove the last denomination and skip to the next one
        currentCombination.RemoveAt(currentCombination.Count - 1);
        FindCombinations(targetAmount, denominations, currentCombination, index + 1);
    }

    static void CalculateCombinations(int payoutAmount)
    {
        int[] denominations = { 10, 50, 100 };
        Console.WriteLine($"Possible combinations for {payoutAmount} EUR:");
        FindCombinations(payoutAmount, denominations, new List<int>(), 0);
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        int[] payouts = { 30, 50, 60, 80, 140, 230, 370, 610, 980 };
        foreach (int payout in payouts)
        {
            CalculateCombinations(payout);
        }
    }
}
