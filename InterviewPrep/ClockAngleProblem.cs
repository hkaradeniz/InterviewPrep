using System;

namespace InterviewPrep
{
    class ClockAngleProblem
    {
        /*
          * Minute hand is easy to calculate. Basically when minute hand completes
          * 360 min cycle, it tours 360 degrees. So, 360/60 is 6 degrees. That being said,
          * when minute hand goes one minute it takes min*6 angle
          * 
          * 
          * For hour hand, once minute hand completes 60 minutes, it only creates
          * 30 degree angle. For each minute, the hour hand creates 0.5 degree
          * So the hour hand's angle is (h*30 + min*0.5)
          * 
          * 
          * 
          * 
          * When you subtract min hand angle from hour hand angle (absolute value)
          * this may give us either the exterior angle or interior angle.
          * We basically get the min of 360-angle or angle.
         */


        public double GetAngle(int hour, int min)
        {
            if (hour < 1 || hour >= 12) return -1;
            if (min < 0 || min >= 60) return -1;

            double minAngle = 6 * min;
            double hourAngle = 30 * hour + min * 0.5;

            double difference = Math.Abs(minAngle - hourAngle);

            return Math.Min(360 - difference, difference);
        }
    }
}
