using System;

namespace InterviewPrep
{
    class StringPermutations
    {
        // Displays the number of permutations of a string
        string s = string.Empty;

        public StringPermutations(string value)
        {
            s = value;
        }

        public void ListPermutatations()
        {
            RecPermute("", s);
        }

        private void RecPermute(string sofar, string rest)
        {
            if (rest == "")
                Console.WriteLine(sofar);
            else
            {
                for (int i = 0; i < rest.Length; i++)
                {
                    string next = sofar + rest[i];
                    string remaining = rest.Substring(0, i) + rest.Substring(i + 1);
                    RecPermute(next, remaining);
                }
            } 
        }
    }
}
