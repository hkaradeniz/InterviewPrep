using System.Collections.Generic;

namespace InterviewPrep
{
    class CoinChange
    {
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
            if (money == 0)
            { return 1; }

            if (coinIndex >= coins.Length)
            { return 0; }

            // For Memoization use a simple string 
            string key = money + "-" + coinIndex;

            if (memoTable.ContainsKey(key))
                return memoTable[key];

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
    }
}
