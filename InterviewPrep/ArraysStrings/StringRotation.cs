namespace InterviewPrep.ArraysStrings
{
    class StringRotation
    {
        /*? Cracking the Coding Interview, 6th Edition
          String Rotation:Assumeyou have a method isSubstringwhich checks if one word is a substring
            of another. Given two strings, sl and s2, write code to check if s2 is a rotation of sl using only one
            call to isSubstring (e.g., "waterbottle" is a rotation of"erbottlewat").

            Solution:
            str1 += str1 =>  waterbottlewaterbottle
            So it makes it easier to find if wat"erbottlewat"erbottle contains erbottlewat
     */
        public bool CheckIfSubString(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;

            s1 += s1;

            return IsSubstring(s1, s2);
        }

        private bool IsSubstring(string str1, string str2)
        {
            return str1.Contains(str2);
        }
    }
}
