using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep.Interviews
{
    /*
        You are working on developing a movie with Amazon Video and want to devise an application to easily 
        break up individual shots in a video into scenes. There is already an algorithm that breaks the video 
        up into shots (short sequences from a particular camera angle) and lables them.

        Write a function which will partition a sequence of labels into minimal subsequences so that no labels 
        appear in more than one subsequence. The output should be the length of each subsequence.

        Input:
        The input to the function/method consists of an argument - inputList, a list of characters representing 
        the sequence of shots.

        Output:
        Return a list of integers representing the length of each scene, in the order in which it appears in the 
        given sequence of shots.

        Example:

        Input:
        inputList = [a,b,a,b,c,b,a,c,a,d,e,f,e,g,d,e,h,i,j,h,k,l,i,j]
    
        Output:
        [9, 7, 8]
    
        Explanation:
        The correct partitioning is:
        a,b,a,b,c,b,a,c,a,/d,e,f,e,g,d,e,/h,i,j,h,k,l,i,j
    
        To ensure that no label appears in more than one subsequence, subsequencea are as small as possible, 
        and subsequences partition the sequence. The length of these subsequences are 9, 7 and 8.

        Solution:
        Merge Intervals. For each letter, use an array or hash table to store the first index and last index 
        (this will act as the start and end point for each interval). Then combine overlapping intervals at 
        the end. The length of each interval (end index - start index + 1) will be part of the output.
    */
    class AmazonVideo
    {
        class Interval
        {
            public int Start { get; set; }
            public int End { get; set; }
        }


        public List<int> LengthEachScene(char[] arr)
        {
            List<int> result = new List<int>();

            Interval[] intervals = new Interval[26];
            Dictionary<char, int> dict = new Dictionary<char, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (!dict.ContainsKey(arr[i])) dict.Add(arr[i], i);

                int index = arr[i] - 'a';

                if (intervals[index] == null)
                    intervals[index] = new Interval() { Start = i };
                else
                    intervals[index].End = i;
            }

            //Interval prev = listP.get(0);

            return result;
        }
    }

    /*
     List<Integer> result = new ArrayList<>();
    Map<Character, Interval> occuranceMap = new LinkedHashMap<>();

    List<Interval> l = new ArrayList<>();
    for(int i = 0; i < inputList.size(); i++){
        char cur = inputList.get(i);
        if(occuranceMap.containsKey(cur)){
            occuranceMap.get(cur).end = i;
        }
        else{
            occuranceMap.put(cur, new Interval(cur, i));
        }
    }

    List<Interval> listP = new ArrayList<Interval>(occuranceMap.values());

    System.out.println(listP);
    Interval prev = listP.get(0);

    for(int i = 1; i < listP.size(); i++){

        Interval cur = listP.get(i);
        if( prev.end < cur.start ){

            result.add(prev.end - prev.start +1);
            prev.start = cur.start;
            prev.end = cur.end;
        }
        else{
            if(prev.end > cur.end){
                continue;
            }
            else{
                prev.end = cur.end;

            }


        }
        //result.add(prev.end - prev.start +1);

    }

    result.add(prev.end - prev.start + 1);

    return result;
    */
}
