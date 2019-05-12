using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarCare
{
    internal static class CarCareLogic
    {
        private const int delay = 2;
        private const double LEFT_X_BOUNDARY = 150.0;
        private const double RIGHT_X_BOUNDARY = 800.0;
        //private const double LEFT_Y_BOUNDARY = ;
        //private const double RIGHT_Y_BOUNDARY = ;
        private static int resolutionX = Screen.PrimaryScreen.Bounds.Width;
        private static int resolutiuonY = Screen.PrimaryScreen.Bounds.Height;
        private static DateTime lastGazeLostLeft = DateTime.MinValue;
        private static DateTime lastGazeLostRight;
        private static int leftCounter = 0;
        private static int rightCounter = 0;

        public static int ResolutiuonY { get => resolutiuonY;}
        public static int ResolutionX { get => resolutionX;}

        internal static bool checkForLeftBoundaries(double gazePointX, double gazePointY)
        {
            if (gazePointX >= LEFT_X_BOUNDARY)
            {
                //if (lastGazeLostLeft == DateTime.MinValue)
                //{
                //    lastGazeLostLeft = DateTime.Now;
                    //return false;
            //}
            //else
                //{
                    //if (DateTime.Now.Subtract(lastGazeLostLeft).TotalSeconds >= delay)
                    //{
                    //    leftCounter++;
                    //    if (leftCounter > 2)
                    //    {
                    //        leftCounter = 0;
                    //        lastGazeLostLeft = DateTime.Now;
                    //    }
                        return true;
                    }
            //}
            //}
            //lastGazeLostLeft = DateTime.MinValue;
            return false;
            //return gazePointX <= LEFT_X_BOUNDARY;
        }

        internal static bool checkForRightBoundaries(double gazePointX, double gazePointY)
        {
            if (gazePointX <= RIGHT_X_BOUNDARY)
            {
                //if (lastGazeLostRight == DateTime.MinValue)
                //{
                //    lastGazeLostRight = DateTime.Now;
                //    return false;
                //}
                //else
                //{
                //    if (DateTime.Now.Subtract(lastGazeLostRight).TotalSeconds >= delay)
                //    {
                //        rightCounter++;
                //        if (rightCounter > 2)
                //        {
                //            rightCounter = 0;
                //            lastGazeLostRight = DateTime.Now;
                //        }
                        return true;
                    //}
                //}
            }
            //lastGazeLostRight = DateTime.MinValue;
            return false;
            //return gazePointX >= RIGHT_X_BOUNDARY;
        }
    }
}
