using System;
using System.Collections.Generic;
using System.Text;

namespace RealWorldDesignPatterns.Creational.SingletonPattern
{
    public class Singleton
    {
        public interface IDatabase
        {
            int GetPopulation(string name);
        }

        public class DummyDatabase : IDatabase
        {
            public int GetPopulation(string name)
            {
                return 1;
            }
        }

        public class SingletonDatabase : IDatabase
        {
            public static int Count => instanceCount;
            private static int instanceCount;

            private SingletonDatabase()
            {
               Console.WriteLine("Initializing database");
            }

            public int GetPopulation(string name)
            {
                return 3;
            }

            // laziness + thread safety
            private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() =>
            {
                instanceCount++;
                return new SingletonDatabase();
            });

            public static IDatabase Instance => instance.Value;
        }
    }
}
