using System;
using System.Text;

namespace InterviewPrep.Adobe
{
    /* Reverse words in a given string */
    /* Given a String of length N reverse the words in it. Words are separated by dots. */
    class ReverseWords
    {
        public void Reverse(string str)
        {
            if (string.IsNullOrEmpty(str)) return;

            Console.WriteLine($"Before: {str}");

            string[] arr = str.Split('.');

            int left = 0;
            int right = arr.Length - 1;

            while (left < right)
            {
                Swap(arr, left, right);
                left++;
                right--;
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < arr.Length; i++)
            {
                sb.Append(arr[i]).Append(".");
            }

            sb.Length--;

            Console.WriteLine($"After: {sb.ToString()}");
        }

        private void Swap(string[] arr, int i, int j)
        {
            string temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        /*
        Another Solution:
        i like this program very much

        1) Reverse the individual words, we get the below string.
            "i ekil siht margorp yrev hcum"
        2) Reverse the whole string from start to end and you get the desired output.
            "much very program this like i"
        */
        public void ReverseWithoutArray(string str)
        {
            if (string.IsNullOrEmpty(str)) return;

            int leftIndex = -1;
            int rightIndex = str.IndexOf(' ');
            StringBuilder sb = new StringBuilder();

            while (true)
            {
                for (int i = rightIndex-1; i > leftIndex; i--)
                {
                    sb.Append(str[i]);
                }

                leftIndex = rightIndex;
                if (leftIndex == str.Length)
                    break; 
                
                sb.Append('.');

                rightIndex = str.IndexOf(' ', leftIndex + 1);

                if (rightIndex == -1)
                    rightIndex = str.Length;
            }

            leftIndex = 0;
            rightIndex = sb.ToString().Length - 1;

            while (leftIndex < rightIndex)
            {
                char c = sb[leftIndex];
                sb[leftIndex] = sb[rightIndex];
                sb[rightIndex] = c;

                leftIndex++;
                rightIndex--; 
            }

            Console.WriteLine($"\t Original Text: {str} \n\t New Text: {sb.ToString()}");
        }
    }
}
