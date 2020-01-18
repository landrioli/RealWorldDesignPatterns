using System;
using System.Collections.Generic;
using System.Text;

namespace RealWorldDesignPatterns.Creational.FactoryPattern
{
    //Separation of concerns + Single ResponsibilityPrinciple
    public class Factory
    {
        public class Point
        {
            private double x, y;

            private Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public static class Factory
            {
                public static Point Create(double x, double y)
                {
                    return new Point(x, y);
                }
            }
        }

        public static void Run()
        {
            var p1 = Point.Factory.Create(1, 11);
        }
    }
}
