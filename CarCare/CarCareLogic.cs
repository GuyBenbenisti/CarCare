using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarCare
{
    internal struct Rectangle
    {
        double minX;
        double minY;
        double maxX;
        double maxY;

        public Rectangle(double minX, double minY, double maxX, double maxY)
        {
            this.minX = minX;
            this.minY = minY;
            this.maxX = maxX;
            this.maxY = maxY;
        }

        internal bool IsInside(double i_X, double i_Y)
        {
            return (i_X <= maxX && i_X >= minX) && (i_Y <= maxY && i_Y >= minY);
        }
    }
    internal static class CarCareLogic
    {
       internal enum invocationEnumDirection
        {
            left,
            right
        }

        private static readonly TimeSpan delay = new TimeSpan(TimeSpan.TicksPerSecond * 1);
        private static readonly double LEFT_X_BOUNDARY = -50;
        private static readonly double RIGHT_X_BOUNDARY = 1600;
        private static List<Rectangle> whiteList;
        //private const double LEFT_Y_BOUNDARY = ;
        //private const double RIGHT_Y_BOUNDARY = ;
        //private static int resolutionX = Screen.PrimaryScreen.Bounds.Width;
        //private static int resolutiuonY = Screen.PrimaryScreen.Bounds.Height;
        //private static DateTime lastGazeLostLeft = DateTime.MinValue;
        //private static DateTime lastGazeLostRight;
        //private static int leftCounter = 0;
        //private static int rightCounter = 0;

        //public static int ResolutiuonY { get => resolutiuonY;}
        //public static int ResolutionX { get => resolutionX;}

        internal static bool checkForLeftBoundaries(double gazePointX, double gazePointY)
        {
            if (checkIsInWhiteList(gazePointX, gazePointY))
            {
                return false;
            }
            return gazePointX <= LEFT_X_BOUNDARY;
            //if (gazePointX <= LEFT_X_BOUNDARY)
            //{
            //    if (lastGazeLostLeft == DateTime.MinValue)
            //    {
            //        lastGazeLostLeft = DateTime.Now;
            //        return false;
            //    }
            //    else
            //    {
            //        if (DateTime.Now.Subtract(lastGazeLostLeft).TotalSeconds >= delay)
            //        {
            //            leftCounter++;
            //            if (leftCounter > 2)
            //            {
            //                leftCounter = 0;
            //                lastGazeLostLeft = DateTime.Now;
            //            }
            //            return true;
            //        }
            //    }
            //}
            //lastGazeLostLeft = DateTime.MinValue;
            //return false;
            //return gazePointX <= LEFT_X_BOUNDARY;
        }

        internal static bool checkForRightBoundaries(double gazePointX, double gazePointY)
        {
            if(checkIsInWhiteList(gazePointX, gazePointY))
            {
                return false;
            }

            return gazePointX >= RIGHT_X_BOUNDARY;
            //if (gazePointX >= RIGHT_X_BOUNDARY)
            //{
            //    if (lastGazeLostRight == DateTime.MinValue)
            //    {
            //        lastGazeLostRight = DateTime.Now;
            //        return false;
            //    }
            //    else
            //    {
            //        if (DateTime.Now.Subtract(lastGazeLostRight).TotalSeconds >= delay)
            //        {
            //            rightCounter++;
            //            if (rightCounter > 2)
            //            {
            //                rightCounter = 0;
            //                lastGazeLostRight = DateTime.Now;
            //            }
            //            return true;
            //        }
            //    }
            //}
            //lastGazeLostRight = DateTime.MinValue;
            //return false;
            //return gazePointX >= RIGHT_X_BOUNDARY;
        }

        internal static bool CheckForInterval(TimeSpan i_Interval)
        {
            return i_Interval >= delay;
        }

        internal static void SetWhiteList(List<Rectangle> list)
        {
            whiteList = list;
        }

        private static bool checkIsInWhiteList(double i_X, double i_Y)
        {
            foreach(Rectangle rectangle in whiteList)
            {
                if(rectangle.IsInside(i_X, i_Y))
                {
                   return true;
                }
            }

            return false;
        }
    }
}
