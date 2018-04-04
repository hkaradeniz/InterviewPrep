using System.Collections.Generic;

namespace InterviewPrep.Contest
{
    class BuySellStocksII
    {
        /*
         Say you have an array for which the ith element is the price of a given stock on day i.

        Design an algorithm to find the maximum profit. You may complete as many transactions as you like (ie, buy one and sell one share of the stock multiple times). However, you may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).

        Example :

        Input : [1 2 3]
        Return : 2
         */
        public int maxProfit(List<int> A)
        {
            return MaxProfit(A, 1, 0);
        }

        public int MaxProfit(List<int> market, int pointer, int profit)
        {
            while (pointer < market.Count && market[pointer - 1] > market[pointer])
            {
                pointer++;
            }

            if (pointer >= market.Count) return 0;

            profit += market[pointer] - market[pointer - 1] + MaxProfit(market, pointer + 1, profit);

            return profit;
        }
    }
}
