using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep
{
    class SortBigFile
    {
        //? External sorting
        //? Sort Big File: Imagine you have a 20 GB file with one string per line.
        //? Explain how you would sort Sort Big File: Imagine you have a 20 GB file with one string per line. 
        //? Explain how you would sort the file.

        /*? 
        https://en.wikipedia.org/wiki/External_sorting
        External sorting is a class of sorting algorithms that can handle massive amounts of data. 
        External sorting is required when the data being sorted do not fit into the main memory 
        of a computing device (usually RAM) and instead they must reside in the slower external 
        memory, usually a hard disk drive. External sorting typically uses a hybrid sort-merge 
        strategy. In the sorting phase, chunks of data small enough to fit in main memory are read, 
        sorted, and written out to a temporary file. In the merge phase, the sorted subfiles are 
        combined into a single larger file.


        One example of external sorting is the external merge sort algorithm, which sorts chunks 
        that each fit in RAM, then merges the sorted chunks together. For example, for sorting 
        900 megabytes of data using only 100 megabytes of RAM:

        1. Read 100 MB of the data in main memory and sort by some conventional method, like quicksort.
        2. Write the sorted data to disk.
        3. Repeat steps 1 and 2 until all of the data is in sorted 100 MB chunks 
        (there are 900MB / 100MB = 9 chunks), which now need to be merged into one single output file.
        4. Read the first 10 MB (= 100MB / (9 chunks + 1)) of each sorted chunk into input buffers 
        in main memory and allocate the remaining 10 MB for an output buffer. (In practice, it might 
        provide better performance to make the output buffer larger and the input buffers slightly smaller.)
        5. Perform a 9-way merge and store the result in the output buffer. Whenever the output 
        buffer fills, write it to the final sorted file and empty it. Whenever any of the 9 
        input buffers empties, fill it with the next 10 MB of its associated 100 MB sorted 
        chunk until no more data from the chunk is available. This is the key step that 
        makes external merge sort work externally -- because the merge algorithm only makes 
        one pass sequentially through each of the chunks, each chunk does not have to be 
        loaded completely; rather, sequential parts of the chunk can be loaded as needed.
        
        Historically, instead of a sort, sometimes a replacement-selection algorithm was 
        used to perform the initial distribution, to produce on average half as many 
        output chunks of double the length.
        */
    }
}
