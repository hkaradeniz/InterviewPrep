namespace InterviewPrep.Trie
{
    class TrieNode
    {
        private static readonly int SIZE = 26;

        public char Value { get; set; }
        private TrieNode[] children;
        public bool IsComplete { get; set; }

        public TrieNode()
        {
            children = new TrieNode[SIZE];
        }

        public void AddChildren(char c)
        {
            children[c] = new TrieNode();
        }

        public TrieNode[] GetChildren()
        {
            return children;
        }
    }
}
