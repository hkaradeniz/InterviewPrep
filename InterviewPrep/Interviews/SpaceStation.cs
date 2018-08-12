using System;
using System.Collections.Generic;

namespace InterviewPrep.Interviews
{
    /*
        Assume you’re in a space station close to an asteroid belt. In this particular 
        asteroid belt there are N asteroids of varying sizes (no two asteroids have the same size). 
        All of the asteroids move at the same speed, but their direction is either towards you or 
        away from you. When two asteroids collide, the larger asteroid completely destroys the 
        smaller asteroid and continues moving in the same direction.


        #=#           .   O     〇      o     #=#  <- space station
                      →   ←     →       ←
        mass          1   5     7       3
        direction     1  -1     1      -1
        answer: 1
                      .   o   O   〇   #=#
                      →   →   →   ←
        mass          1   8   5   7
        direction     1   1   1  -1
        answer: 2
                      O   .   o   #=#
                      →   →   ←
        mass          5   1   4
        direction     1   1  -1
        answer: 1
                      .   O   o   #=#
                      →   →   ←
        mass          1   5   4
        direction     1   1  -1
        answer: 2
        */

    class SpaceStation
    {
        class Asteroid
        {
            public int mass;
            public int direction;
            public Asteroid(int mass, int direction)
            {
                this.mass = mass;
                this.direction = direction;
            }

            public override String ToString()
            {
                return "Asteroid(" + mass + ", " + direction + ")";
            }
        }

        public void RunAsteroids()
        {
            Asteroid[] case1 = new Asteroid[] {
            new Asteroid(1, 1),
            new Asteroid(5, -1),
            new Asteroid(7, 1),
            new Asteroid(3, -1),
        };

            Asteroid[] case2 = new Asteroid[] {
            new Asteroid(1, 1),
            new Asteroid(3, 1),
            new Asteroid(5, 1),
            new Asteroid(7, -1),
        };

            Asteroid[] case3 = new Asteroid[] {
            new Asteroid(5, 1),
            new Asteroid(1, 1),
            new Asteroid(4, -1),
        };

            Asteroid[] case4 = new Asteroid[] {
            new Asteroid(1, 1),
            new Asteroid(5, 1),
            new Asteroid(4, -1),
        };

            TestCase(1, case1, 1);
            TestCase(2, case2, 0);
            TestCase(3, case3, 1);
            TestCase(4, case4, 2);
        }

        private void TestCase(int caseNum, Asteroid[] asteroids, int expected)
        {
            int result = CountHits(asteroids);
            Console.Write("Case " + caseNum + ": ");
            if (result == expected)
            {
                Console.WriteLine("PASSED");
            }
            else {
                Console.WriteLine("FAILED: got " + result + " expected " + expected);
            }
        }

        static int CountHits(Asteroid[] asteroids)
        {

            if (asteroids == null) return 0;

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < asteroids.Length; i++)
            {
                if (asteroids[i].direction == 1)
                    stack.Push(asteroids[i].mass);
                else
                {
                    while (stack.Count > 0)
                    {
                        if (stack.Peek() < asteroids[i].mass)
                            stack.Pop();
                        else
                            break;
                    }
                }
            }

            return stack.Count;  
        }
    }
}
