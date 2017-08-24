namespace InterviewPrep
{
    /*
    Quick Union is  good but the problem is that trees might get 
    very tall and the worst-case scenario to find the root might 
    increase to O(N).
        
        What is the solution?
        Weighted Quick-Union
         + Modify quick union to avoid tall trees
         + Keep track of size of each tree (number of objects in each tree)
         + Balance by linking root of smaller tree to the root of larger tree
        
        * Structure: Same as quick-union but maintain extra array "size[]"
        to count number of object in the tree rooted to it. And link the root
        of smaller tree to the root of larger tree.
        
        Union(p, q);

        int i = root(p);
        int j = root(q);
        
        if(size[i] < size[j])
        {
            items[i] = j;
            size[j] += size[i];
        } 
        else
        {
            items[j] = i;
            size[i] += size[j];
        }  

        // Depth of any node x is at most lg N (lg = base2)
    */
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
