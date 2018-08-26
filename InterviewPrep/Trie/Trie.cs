using System.Collections.Generic;
using System.Text;

namespace InterviewPrep.Trie
{
    class Trie
    {
        private TrieNode root = new TrieNode();

        public void AddWord(string word)
        {
            if (string.IsNullOrEmpty(word)) return;

            TrieNode current = root;

            for (int i = 0; i < word.Length; i++)
            {
                TrieNode[] children = current.GetChildren();

                if (children[word[i]] == null)
                    children[word[i]] = new TrieNode();

                current = children[word[i]];
            }

            current.IsComplete = true;
        }

        public TrieNode GetPrefixNode(string prefix)
        {
            if (string.IsNullOrEmpty(prefix)) return null;

            TrieNode current = root;

            for (int i = 0; i < prefix.Length; i++)
            {
                TrieNode[] children = current.GetChildren();

                if (children[prefix[i]] == null) return null;

                current = children[prefix[i]];
            }

            return current;
        }

        public Queue<string> GetPrefixes(string prefix)
        {
            TrieNode current = GetPrefixNode(prefix);

            if (current == null) return null;

            Queue<string> queue = new Queue<string>();

            Collect(current, new StringBuilder(prefix), queue);

            return queue;
        }

        private void Collect(TrieNode node, StringBuilder prefix, Queue<string> queue)
        {
            if (node == null) return;
            if (node.IsComplete) { queue.Enqueue(prefix.ToString()); return; }

            TrieNode[] children = node.GetChildren();

            for (int i = 0; i < children.Length; i++)
            {
                if(children[i] != null)
                {
                    prefix.Append(i + 'a');
                    Collect(children[i], prefix, queue);
                    prefix.Length--;
                }
            }
        }
    }
}
