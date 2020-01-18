using System.Threading.Tasks;

namespace RealWorldDesignPatterns.Creational.FactoryPattern
{
    public class AsyncFactoryMethod
    {
        public class Point
        {
            private double x, y;
            private Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            private async Task<Point> InitAsync()
            {
                await Task.Delay(10);
                return this;
            }

            public static async Task<Point> CreateAsync(double x, double y)
            {
                var result = new Point(1,11);
                return await result.InitAsync();
            }
        }
        public static async Task Run()
        {
            var p1 = await Point.CreateAsync(1, 11);
        }
    }
}
