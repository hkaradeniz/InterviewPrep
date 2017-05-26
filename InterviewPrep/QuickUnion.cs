namespace InterviewPrep
{
    class QuickUnion
    {
        private int[] items;
        private int[] sz;

        public QuickUnion(int capacity)
        {
            items = new int[capacity];
            sz = new int[capacity];

            for (int i = 0; i < capacity; i++)
            {
                items[i] = i;
                sz[i] = 1;
            } 
        }

        private int Root(int i)
        {
            while (i != items[i])
            {
                items[i] = items[items[i]];
                i = items[i];
            }

            return i;
        }

        public bool find(int p, int q)
        {
            return Root(p) == Root(q);
        }

        public void Union(int p, int q)
        {
            int i = Root(p);
            int j = Root(q);

            if (sz[i] < sz[j])
            {
                items[i] = j;
                sz[j] += sz[i];
            }
            else
            {
                items[j] = i;
                sz[i] += sz[j];
            }
        }

        /* Test Values:
                    0 1 2 3 4 5 6 7 8 9

            3-4     0 1 2 3 3 5 6 7 8 9
            4-9     0 1 2 3 3 5 6 7 8 3
            8-0     8 1 2 3 3 5 6 7 8 3
            2-3     8 1 3 3 3 5 6 7 8 3
            5-6     8 1 3 3 3 5 5 7 8 3
            5-9     8 1 3 3 3 3 5 7 8 3
            7-3     8 1 3 3 3 3 5 3 8 3
            4-8     8 1 3 3 3 3 5 3 3 3
            6-1     8 3 3 3 3 3 5 3 3 3 
        */
    }
}
