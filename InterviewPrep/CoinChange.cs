﻿using System.Collections.Generic;

namespace InterviewPrep
{
    class CoinChange
    {
        // Coin Change Problem
        /*
        You are given coins of different denominations and a total amount of  
        money. Write a function to commpute the minimum number of combinations
        that make up that amount.

        Ex: Money: 5 Coins:[1,2,5]
        5 = 5
        5 = 2 + 2 + 1
        5 = 2 + 1 + 1 + 1
        5 = 1 + 1 + 1 + 1 + 1

        Output: 4 ways
        */
        /* Test Data
            CoinChange cc = new CoinChange();
            Console.WriteLine(cc.MakeChange(new int[] { 1, 2, 5 }, 5));
        */
        public long MakeChange(int[] coins, int money)
        {
            return MakeChange(coins, money, 0, new Dictionary<string, long>());
        }

        private long MakeChange(int[] coins, int money, int coinIndex, Dictionary<string, long> memoTable)
        {
            // Base Cases
            if (money == 0) return 1;

            if (coinIndex >= coins.Length) return 0;

            // For Memoization use a simple string 
            string key = money + "-" + coinIndex;

            if (memoTable.ContainsKey(key)) return memoTable[key];

            int currentTotalWithCoins = 0;
            long numberOfWays = 0;

            // Implementation
            while (currentTotalWithCoins <= money)
            {
                int remaining = money - currentTotalWithCoins;
                numberOfWays += MakeChange(coins, remaining, coinIndex+1, memoTable);
                currentTotalWithCoins += coins[coinIndex];
            }

            memoTable.Add(key, numberOfWays);
            return numberOfWays;
        }

        //  2nd Approach
        /*
        Explanation:

        Amount: 12 Coins: 1, 2, 5

        Create an array with 12 elements (Let's call this "combinations")
        Rule: 
            if(amount >= coin) then
                combinations[amount] += combinations[amount-coin] 
        */
        public long Change(int amount, int[] coins)
        {
            long[] combinations = new long[amount + 1];
            combinations[0] = 1;

            foreach (var coin in coins)
            {
                for (int i = 1; i < combinations.Length+1; i++)
                {
                    if (amount > coin)
                        combinations[amount] += combinations[amount - coin]; 
                }
            }

            return combinations[amount];
        } 
    }
}
