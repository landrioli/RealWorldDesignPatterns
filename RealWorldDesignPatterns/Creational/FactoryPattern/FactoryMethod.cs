using System;
using System.Collections.Generic;
using System.Text;

namespace RealWorldDesignPatterns.Creational.Factory
{
    public class FactoryMethod
    {
        public class Point
        {
            private double x, y;
            private Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho, double theta)
            {
                //...
                return new Point(rho, theta);
            }
        }

        public static void Run()
        {
            var p1 = Point.NewCartesianPoint(1, 11);
            var p2 = Point.NewPolarPoint(2, 22);
        }
    }

}
