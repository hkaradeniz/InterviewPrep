using System;

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

        /*
        Brute Force
        The brute force algorithm falls directly out from the wording of the problem. We need to find the year with
        the most number of people alive. Therefore, we go through each year and check how many people are alive
        in that year.
        */



        /* More Optimal
        More Optimal
        Let's create an example. (In fact, an example is really helpful in almost all problems. Ideally, you've already
        done this.) Each column below is matched, so that the items correspond to the same person. For compactness,
        we'll just write the last two digits of the year.
        birth: 12 20 10 01 10 23 13 90 83 75
        death: 15 90 98 72 98 82 98 98 99 94
        It's worth noting that it doesn't really matter whether these years are matched up. Every birth adds a person
        and every death removes a person.
        Since we don't actually need to match up the births and deaths, let's sort both. A sorted version of the years
        might help us solve the problem.

        birth: 01 10 10 12 13 20 23 75 83 90
        death: 15 72 82 90 94 98 98 98 98 99
        
        We can try walking through the years.
        At year 0, no one is alive.
        At year 1, we see one birth.
        At years 2 through 9, nothing happens.
        Let's skip ahead until year 10, when we have two births. We now have three people alive.
        At year 15, one person dies. We are now down to two people alive.
        And so on.
        */
        // birth: 01 10 10 12 13 20 23 75 83 90
        // death: 15 72 82 90 94 98 98 98 98 99


        // Test Data
        // LivingPeople lp = new LivingPeople();
        // Console.WriteLine(lp.GetTheMostCrowdedYear(new int[] { 1912, 1920, 1910, 1901, 1910, 1923, 1913, 1990, 1983, 1975 }, new int[] { 1915, 1990, 1998, 1972, 1998, 1982, 1998, 1998, 1999, 1994 }));
        public int GetTheMostCrowdedYear(int[] born, int[] death)
        {
            if (born.Length != death.Length)
                throw new Exception("Inconsistant data!");

            Array.Sort(born);
            Array.Sort(death);

            int birthindex = 0;
            int deathindex = 0;
            int currentlyAlive = 0;
            int maxAlive = 0;
            int maxAliveYear = 0;

            // birth: 01 10 10 12 13 20 23 75 83 90
            // death: 15 72 82 90 94 98 98 98 98 99
            while (birthindex < born.Length)
            {
                if (born[birthindex] <= death[deathindex])
                {
                    currentlyAlive++;
                    if (currentlyAlive > maxAlive)
                    {
                        maxAlive = currentlyAlive;
                        maxAliveYear = born[birthindex];
                    }
                    birthindex++;
                }
                else if (born[birthindex] > death[deathindex])
                {
                    currentlyAlive--;
                    deathindex++;
                } 

            }

            return maxAliveYear;
        }

        /*
        There are some very easy things to mess up here.
        On line 13, we need to think carefully about whether this should be a less than(<) or a less than or equals
        (<=). The scenario we need to worry about is that you see a birth and death in the same year. (It doesn't
        matter whether the birth and death is from the same person.)
        When we see a birth and death from the same year, we want to include the birth before we include the
        death, so that we count this person as alive for that year. That is why we use a < = on line 13.
        We also need to be careful about where we put the updating of maxAli ve and maxAli veYear. It needs
        to be after the currentAlive++, so that it takes into account the updated total. But it needs to be before
        birth Index++, or we won't have the right year.
        This algorithm will take O ( P log P) time, where P is the number of people.
        */
    }
}
