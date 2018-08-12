using System.Collections.Generic;

namespace InterviewPrep.Interviews
{
    class DuplicateFileSearch
    {
        class FileInfo
        {
            string filename { get; set; }
            string path { get; set; }
            public FileInfo(string f, string p)
            {
                filename = f;
                path = p;
            }
        }

        public List<string> getFiles(string path) { return new List<string>(); }

        public List<string> getDirectories(string path) { return new List<string>(); }

        public string getFileContent(string filepath) { return string.Empty; }

        public List<string> FindDups(string rootDirectory)
        {
            Queue<string> dirs = new Queue<string>();
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

            dirs.Enqueue(rootDirectory);

            while (dirs.Count > 0)
            {
                string directoryPath = dirs.Dequeue();

                List<string> files = getFiles(directoryPath);

                foreach (string file in files)
                {
                    string key = getFileContent(directoryPath + "/" + file);

                    if (!map.ContainsKey(key))
                        map.Add(key, new List<string>);

                    map[key].Add(directoryPath + "/" + file);
                }

                List<string> directories = getDirectories(directoryPath);

                foreach (string dir in directories)
                {
                    dirs.Enqueue(directoryPath + "/" + dir);
                }
            }

            List<string> duplicates = new List<string>();

            foreach (var item in map)
            {
                if (item.Value.Capacity > 1)
                    duplicates.Add(item.Key);
            }

            return duplicates;
        }
    }
}
