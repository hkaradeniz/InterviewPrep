namespace InterviewPrep.General
{
    class BuySellStock
    {
        /* Buying and selling stocks */
        /* Given an array of stock prices, find the maximum profit that can be earned by doing a single 
            transaction of buy and sell in the given period of time. */
        /* Test Data:
            General.BuySellStock bs = new General.BuySellStock();
            Console.WriteLine(bs.MaxProfit(new int[] {100, 80, 120, 130, 70, 60, 100, 125}));
         */
        public int MaxProfit(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return -1;

            int minStockPrice = int.MaxValue;
            int maxProfit = 0;

            // 100, 80, 120, 130, 70, 60, 100, 125
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < minStockPrice)
                    minStockPrice = arr[i];

                int profit = arr[i] - minStockPrice;

                if (profit > maxProfit)
                    maxProfit = profit;
            }

            return maxProfit;
        }
    }
}
