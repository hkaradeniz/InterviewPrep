namespace InterviewPrep.Amazon
{
    /* Overlapping rectangles */
    /* Given two rectangles, find if the given two rectangles overlap or not. A rectangle is denoted 
     * by providing the x and y co-ordinates of two points: the left top corner and the right bottom corner of the rectangle. */
    /* https://practice.geeksforgeeks.org/problems/overlapping-rectangles/0 */
    class OverlappingRectangles
    {
        internal class Coordinate
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        /*
            left 1(0, 10) *** Right 1 (10, 0)
            left 2(5, 5) *** Right 2 (15, 0)
         */
        public bool RectanglesOverlap(Coordinate left1, Coordinate right1, Coordinate left2, Coordinate right2)
        {
            // One rectangle is on the left, one rectangle is on the right
            if (left2.X > right1.X || left1.X > right2.X)
                return false;

            // One rectangle is above, one rectangle is blow
            if (right2.Y > left1.Y || right1.Y > left1.Y)
                return false;

            return true;
        }
    }
}
