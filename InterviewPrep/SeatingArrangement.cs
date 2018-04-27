using System.Text;

namespace InterviewPrep
{
    class SeatingArrangement
    {
        public bool CanSitTogether(string row, int number)
        {
            if (string.IsNullOrEmpty(row) || row.Length / 2 + 1 < number)
                return false;

            int pointer = 1;
            StringBuilder sb = new StringBuilder(row);
            int count = 0;

            if (row[0] == '0' && row[1] == '0')
            {
                count++;
                pointer++;
            }

            while (pointer < row.Length - 1)
            {
                if (row[pointer] == '1')
                {
                    pointer += 2;
                }
                else if (row[pointer - 1] == '1')
                {
                    pointer++;
                }
                else if (row[pointer + 1] == '1')
                {
                    pointer += 3;
                }
                else
                {
                    count++;
                    pointer += 2;
                }
            }

            System.Console.WriteLine($"Empty Spots: {count}");

            return count >= number;
        }
    }
}
