using System;

namespace InterviewPrep
{
    /*
     Why { low + (high-low) / 2 } over { (low+high) / 2 } ???
     Read: https://research.googleblog.com/2006/06/extra-extra-read-all-about-it-nearly.html
        Extra, Extra - Read All About It: Nearly All Binary Searches and Mergesorts are Broken
        Friday, June 02, 2006
        Posted by Joshua Bloch, Software Engineer
    I remember vividly Jon Bentley's first Algorithms lecture at CMU, where he 
    asked all of us incoming Ph.D. students to write a binary search, and then 
    dissected one of our implementations in front of the class. Of course it was 
    broken, as were most of our implementations. This made a real impression on me, 
    as did the treatment of this material in his wonderful Programming Pearls 
    (Addison-Wesley, 1986; Second Edition, 2000). The key lesson was to carefully 
    consider the invariants in your programs.

    Fast forward to 2006. I was shocked to learn that the binary search program that 
    Bentley proved correct and subsequently tested in Chapter 5 of Programming Pearls 
    contains a bug. Once I tell you what it is, you will understand why it escaped 
    detection for two decades. Lest you think I'm picking on Bentley, let me tell you 
    how I discovered the bug: The version of binary search that I wrote for the JDK 
    contained the same bug. It was reported to Sun recently when it broke someone's 
    program, after lying in wait for nine years or so.

    So what's the bug? Here's a standard binary search, in Java. (It's one that I wrote for 
    the java.util.Arrays):
     
        1:     public static int binarySearch(int[] a, int key) {
        2:         int low = 0;
        3:         int high = a.length - 1;
        4:
        5:         while (low <= high) {
        6:             int mid = (low + high) / 2;
        7:             int midVal = a[mid];
        8:
        9:             if (midVal < key)
        10:                 low = mid + 1
        11:             else if (midVal > key)
        12:                 high = mid - 1;
        13:             else
        14:                 return mid; // key found
        15:         }
        16:         return -(low + 1);  // key not found.
        17:     }

        The bug is in this line:
         6:             int mid =(low + high) / 2;

        In Programming Pearls Bentley says that the analogous line "sets m to the average 
        of l and u, truncated down to the nearest integer." On the face of it, this assertion 
        might appear correct, but it fails for large values of the int variables low and high. 
        Specifically, it fails if the sum of low and high is greater than the maximum positive 
        int value (2^31 - 1). The sum overflows to a negative value, and the value stays 
        negative when divided by two. In C this causes an array index out of bounds with 
        unpredictable results. In Java, it throws ArrayIndexOutOfBoundsException.

        This bug can manifest itself for arrays whose length (in elements) is 230 or greater 
        (roughly a billion elements). This was inconceivable back in the '80s, when Programming 
        Pearls was written, but it is common these days at Google and other places. In 
        Programming Pearls, Bentley says "While the first binary search was published in 1946, 
        the first binary search that works correctly for all values of n did not appear until 1962.
        " The truth is, very few correct versions have ever been published, at least in mainstream 
        programming languages.

        So what's the best way to fix the bug? Here's one way:
        6:             int mid = low + ((high - low) / 2);
     */
    class BinarySearch
    {
        public void BinarySearchIterative(int[] array, int key, int left, int right)
        {
            while (left <= right)
            {
                // 1 2 3 4 5 6 7 8 left = 0 right = 8 mid = 4
                // 1 2 3 5 6 6 7   left = 0 right = 7 mid = 3
                int mid = (left + right) / 2; // left + (right - left) / 2

                if (key == array[mid])
                {
                    Console.WriteLine($"Position: {mid + 1}");
                    return;
                }
                else if (key < array[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
        }

        public void BinarySearchRecursive(int[] array, int key, int left, int right)
        {
            if (left > right)
                return;

            // 1 2 3 4 5 6 7 8 left = 0 right = 8 mid = 4
            // 1 2 3 5 6 6 7   left = 0 right = 7 mid = 3
            int mid = (left + right) / 2; // left + (right - left) / 2

            if (key == array[mid])
            {
                Console.WriteLine($"Position: {mid + 1}");
            }
            else if (key < array[mid])
            {
                BinarySearchRecursive(array, key, left, mid - 1);
            }
            else
            {
                BinarySearchRecursive(array, key, mid + 1, right);
            }
        }
    }
}
