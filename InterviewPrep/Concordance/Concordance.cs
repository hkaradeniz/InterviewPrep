using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace InterviewPrep.Concordance
{
    /* Given an arbitrary text document written in English, write a program that will generate a
        concordance, i.e. an alphabetical list of all word occurrences, labeled with word frequencies.
        Label each word with the sentence numbers in which each occurrence appeared.  */
    class Concordance
    {
        public void CalculateConcordance(string text)
        {
            if (string.IsNullOrEmpty(text)) return;

            string[] words = text.Split(' ');
            Dictionary<string, ConcordanceKeeper> dict = new Dictionary<string, ConcordanceKeeper>();

            int sentenceNumber = 1;
            bool isSenteceEnd;
            bool removePunctuations;

            for (int i = 0; i < words.Length; i++)
            {
                isSenteceEnd = false;
                removePunctuations = false;

                string word = words[i].ToLower();

                /* If a word ends with "?" or "!", consider this the end of the sentence */
                if (word.EndsWith("?") || word.EndsWith("!"))
                { isSenteceEnd = true; removePunctuations = true; }
                /* If a word ends with ".", this may be the end of the sentence */
                else if (word.EndsWith("."))
                {
                    if (i != words.Length - 1)
                    {
                        isSenteceEnd = IsSentenceEnd(words[i], words[i + 1]);
                    }
                    /* This is the end of the paragraph */
                    else
                    {
                        isSenteceEnd = true; 
                    }

                    if (isSenteceEnd)
                        removePunctuations = true;
                }
                /* If a word ends with "," or ":" or ";", this is not the end of the sentence*/
                else if (word.EndsWith(",") || word.EndsWith(":") || word.EndsWith(";"))
                { removePunctuations = true; }


                if (removePunctuations)
                    word = RemovePunctuations(word);

                if (!dict.ContainsKey(word))
                    dict.Add(word, new ConcordanceKeeper());

                dict[word].IncreaseOccuranceCount();
                dict[word].AddSentenceNumber(sentenceNumber);

                if (isSenteceEnd)
                    sentenceNumber++;
            }

            PrintConcordanceList(dict);
        }

        private string RemovePunctuations(string word)
        {
            return Regex.Replace(word, @"[\.\,\?\!\:\;]", "");
        }

        private bool IsSentenceEnd(string current, string next)
        {
            bool end = false;

            if (current.EndsWith(".") && next[0] >= 65 && next[0] <= 90)
                end = true;

            return end;
        }

        private void PrintConcordanceList(Dictionary<string, ConcordanceKeeper> dict)
        {
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}   {item.Value.GetOccuranceCount()}:{item.Value.GetSentenceSequence()}");
            }
        }
    }

    class ConcordanceKeeper
    {
        private int count;
        private StringBuilder sb;

        public ConcordanceKeeper()
        {
            count = 0;
            sb = new StringBuilder();
        }

        public void IncreaseOccuranceCount()
        {
            count++;
        }

        public int GetOccuranceCount()
        {
            return count;
        }

        public void AddSentenceNumber(int number)
        {
            sb.Append(number).Append(',');
        }

        public string GetSentenceSequence()
        {
            return sb.ToString().Substring(0, sb.Length-1);
        }
    }
}
