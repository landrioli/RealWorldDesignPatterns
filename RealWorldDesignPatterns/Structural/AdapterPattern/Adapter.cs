using System;
using System.Collections.Generic;
using System.Text;

namespace RealWorldDesignPatterns.Structural.AdapterPattern
{
    public class AdapterPack
    {
        public class Target

        {
            public virtual void Request()
            {
                Console.WriteLine("Called Target Request()");
            }
        }

        public class Adapter : Target
        {
            private readonly Adaptee _adaptee = new Adaptee();

            public override void Request()
            {
                // Possibly do some other work... and then call SpecificRequest
                _adaptee.SpecificRequest();
            }
        }

        public class Adaptee
        {
            public void SpecificRequest()
            {
                Console.WriteLine("Called SpecificRequest()");
            }
        }

        public void Run()
        {
            Target target = new Adapter();
            target.Request();
            Console.ReadKey();
        }
    }
}
