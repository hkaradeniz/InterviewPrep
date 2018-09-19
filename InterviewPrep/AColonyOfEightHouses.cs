namespace InterviewPrep
{
    /* 
    A colony of eight houses, represented as cells, are arranged in a straight line. 
    Each day every cell competes with its adjacent cells (neighbours). 
    An integer value of 1 represents an active cell and value of 0 represents an 
    inactive cell. If both the neighbours are either active or inactive, the cell 
    becomes inactive the next day; otherwise it becomes active on the next day. 
    The two cells on the ends have a single adjacent cell, so the other adjacent 
    cell can be assumed to be always inactive. Even after updating the cell state, 
    its previous state is considered for updating the state of other cells. The cell 
    information of all cells should be updated simultaneously.
        
    */
    class AColonyOfEightHouses
    {
        public int[] cellCompete(int[] states, int days)
        {
            int n = states.Length;

            int[] temp = new int[n];

            while (days > 0)
            {
                // Finding next values 
                // for corner cells
                temp[0] = 0 ^ states[1];
                temp[n - 1] = 0 ^ states[n - 2];

                // Compute values of intermediate cells
                // If both cells active or inactive
                for (int i = 1; i <= n - 2; i++)
                    temp[i] = states[i - 1] ^ states[i + 1];

                for (int i = 0; i < n; i++)
                    states[i] = temp[i];

                days--;
            }

            return states;
        }
    }
}
