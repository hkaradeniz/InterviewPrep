using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        // N Choose K
        /*
        public void StringNChooseK(string sofar, string rest)
        {
            if (sofar.Length == 4)
            { if (!hash.Contains(sofar)) hash.Add(sofar); return; }
            else if (rest == "")
            { return; }
            else
            {
                for (int i = 0; i < rest.Length; i++)
                {
                    string next = sofar + rest[i];
                    string remaining = rest.Substring(0, i) + rest.Substring(i + 1);
                    StringNChooseK(next, remaining);
                }
            }
        }
        */
    }
}
