namespace InterviewPrep.SampleInts
{
    class ReverseVowels
    {
        // Reverse vowels in a string
        // apple => eppla
        // coat => caot
        private bool IsVowel(char c)
        {
            // English vowels: A, E, I, O, U, and sometimes Y.
            return (c == 'a') || (c == 'e') || (c == 'i') || (c == 'o') || (c == 'u');
        }

        private char[] Swap(char[] array, int pos1, int pos2)
        {
            //
            // Swaps characters in a string.
            //
            char temp = array[pos1]; // Get temporary copy of character
            array[pos1] = array[pos2]; // Assign element
            array[pos2] = temp; // Assign element
            return array; // Return array
        }

        public string ReverseVowelsInString(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            System.Console.WriteLine($"Original String: {s}");

            char[] array = s.ToCharArray(); // Get characters

            return ReverseVowelsInStringRecursive(array, 0, array.Length-1);
        }

        public string ReverseVowelsInStringRecursive(char[] array, int position1, int position2)
        {
            if (position1 >= position2)
                return new string(array);

            while (position1 < position2 && !IsVowel(array[position1]))
                position1++;

            while (position1 < position2 && !IsVowel(array[position2]))
                position2--;

            Swap(array, position1, position2);

            return ReverseVowelsInStringRecursive(array, position1 + 1, position2 - 1);
        }
    }
}
