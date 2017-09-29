using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep
{
    class LivingPeople
    {
        /*? Cracking the Coding Interview, 6th Edition 
        Living People: Given a list of people with their birth and death years, implement a method to
        compute the year with the most number of people alive. You may assume that all people were born
        between 1900 and 2000 (inclusive). If a person was alive during any portion of that year, they should
        be included in that year's count. For example, Person (birth= 1908, death= 1909) is included in the
        counts for both 1908 and 1909.
        */

        public int GetTheMostCrowdedYear(int[] born, int[] death, int numberOfPeople)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            // array born and death must be the same size
            if (born.Length != death.Length)
                throw new Exception("Arrays don't match!");

            int max = 0;
            int year = 0;

            for (int i = 0; i < numberOfPeople; i++)
            {
                int bornYear = born[i];
                int deathYear = death[i];

                if (!dict.ContainsKey(bornYear))
                    dict.Add(bornYear, 0);

                dict[bornYear]++;

                if (!dict.ContainsKey(deathYear))
                    dict.Add(deathYear, 0);

                dict[deathYear]++;

                if (dict[bornYear] > max)
                {
                    max = dict[bornYear];
                    year = bornYear;
                }

                if (dict[deathYear] > max)
                {
                    max = dict[deathYear];
                    year = deathYear;
                }

            }

            Console.WriteLine($"Maximum number of people {max} lived in {year}");
            return max;
        }
    }
}
