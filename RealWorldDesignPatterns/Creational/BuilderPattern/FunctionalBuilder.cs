using System;
using System.Collections.Generic;
using System.Text;

namespace RealWorldDesignPatterns.Creational.BuilderPattern
{
    public class FunctionalBuilder
    {
        //This method keeps the Open Closed Principle, but I know, It is not really object oriented ;)
        public void Main()
        {
            var pb = new PersonBuilder();
            var person = pb.Called("Dmitri").WorksAsA("Programmer").Build();
        }
    }

    public class Person
        {
            public string Name, Position;
        }

        public class PersonBuilder
        {
            public readonly List<Action<Person>> Actions = new List<Action<Person>>();

            public PersonBuilder Called(string name)
            {
                Actions.Add(p => { p.Name = name; });
                return this;
            }

            public Person Build()
            {
                var p = new Person();
                Actions.ForEach(a => a(p));
                return p;
            }
        }

    public static class PersonBuilderExtensions
    {
        public static PersonBuilder WorksAsA
            (this PersonBuilder builder, string position)
        {
            builder.Actions.Add(p => { p.Position = position; });
            return builder;
        }
    }
}
