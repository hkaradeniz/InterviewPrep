using System;
using System.Collections.Generic;

namespace InterviewPrep.Google
{
    class WordLadder
    {
        static string letters = "abcdefghijklmnopqrstuvwxyz";

        public int GetMinBFSDistance(Dictionary<string, List<string>> graph, string start, string end)
        {
            Queue<string> queue = new Queue<string>();
            HashSet<string> visited = new HashSet<string>();
            Dictionary<string, string> path = new Dictionary<string, string>();

            queue.Enqueue(start);
            string previous = string.Empty;

            while (queue.Count > 0)
            {
                string vertex = queue.Dequeue();
                previous = vertex;

                if (!visited.Contains(vertex))
                {
                    visited.Add(vertex);
                    List<string> vertices = graph[vertex];

                    foreach (var item in vertices)
                    {
                        if (!visited.Contains(item))
                        {
                            if (!path.ContainsKey(item))
                                path.Add(item, string.Empty);

                            path[item] = previous;

                            queue.Enqueue(item);

                            if (item == end)
                            {
                                int distance = 0;
                                string location = path[item];
                                while (location != start)
                                {
                                    location = path[location];
                                    distance++;
                                }

                                return distance;
                            }
                        }
                    }
                }
            }

            return 0;
        }

        public Dictionary<string, List<string>> createGraph(List<string> dictV)
        {
            //dictV = new ArrayList<String>();

            // test data
            //dictV.Add("cat");
            //dictV.Add("bat");
            //dictV.Add("bet");
            //dictV.Add("bed");
            //dictV.Add("at");
            //dictV.Add("ad");
            //dictV.Add("ed");

            // cat -> bed

            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

            foreach (string word in dictV)
            {
                map.Add(word, null);
                List<string> arr = new List<string>();

                for (int i = 0; i < word.Length; i++)
                {
                    // remove 1 char
                    String remove = word.Substring(0, i) + word.Substring(i + 1);
                    if (dictV.Contains(remove))
                        arr.Add(remove);

                    // change 1 char
                    for (int j = 0; j < letters.Length; j++)
                    {
                        String change = word.Substring(0, i)
                                + letters[j]
                                + word.Substring(i + 1);

                        if (dictV.Contains(change) && change != word)
                            arr.Add(change);
                    }
                }

                // add 1 char
                for (int k = 0; k <= word.Length; k++)
                {
                    for (int j = 0; j < letters.Length; j++)
                    {
                        String add = word.Substring(0, k)
                                + letters[j]
                                + word.Substring(k);

                        if (dictV.Contains(add) && !arr.Contains(add))
                            arr.Add(add);
                    }
                }

                map[word] = arr;
            }

            return map;
        }
    }
}
