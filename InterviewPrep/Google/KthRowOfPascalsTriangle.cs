using System.Collections.Generic;

namespace InterviewPrep.Google
{
    /*
         Given an index k, return the kth row of the Pascal’s triangle.

         Pascal’s triangle : To generate A[C] in row R, sum up A’[C] and A’[C-1] from previous row R - 1.

         Example:

         Input : k = 3

         Return : [1,3,3,1]
         NOTE : k is 0 based. k = 0, corresponds to the row [1]. 
     */
    class KthRowOfPascalsTriangle
    {
        public List<int> GetRow(int A)
        {
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();

            List<int> list = new List<int>();
            list.Add(1);
            dict.Add(0, list);

            for (int i = 1; i <= A; i++)
            {
                List<int> newList = new List<int>();
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || j == i)
                        newList.Add(1);
                    else
                        newList.Add(dict[i - 1][j - 1] + dict[i - 1][j]);
                }

                dict.Add(i, newList);
            }

            return dict[A];
        }
    }
}
