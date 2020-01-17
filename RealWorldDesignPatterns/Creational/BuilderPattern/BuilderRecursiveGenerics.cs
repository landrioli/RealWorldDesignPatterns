using System;
using System.Collections.Generic;
using System.Text;

namespace RealWorldDesignPatterns.Creational.BuilderPattern
{
    public class BuilderRecursiveGenerics
    {
        public abstract class EmployeeBuilder
        {
            protected Employee employee;

            public EmployeeBuilder()
            {
                employee = new Employee();
            }

            public Employee Build() => employee;
        }

        public class EmployeeInfoBuilder<T> : EmployeeBuilder where T : EmployeeInfoBuilder<T>
        {
            public T WithName(string name)
            {
                employee.Name = name;
                return (T)this;
            }
        }
        public class EmployeePositionBuilder<T> : EmployeeInfoBuilder<EmployeePositionBuilder<T>> where T : EmployeePositionBuilder<T>
        {
            public T AtPosition(string position)
            {
                employee.Position = position;
                return (T)this;
            }
        }

        public class EmployeeSalaryBuilder<T> : EmployeePositionBuilder<EmployeeSalaryBuilder<T>> where T : EmployeeSalaryBuilder<T>
        {
            public T WithSalary(double salary)
            {
                employee.Salary = salary;
                return (T)this;
            }
        }
        public class EmployeeSeniorityBuilder<T> : EmployeeSalaryBuilder<EmployeeSeniorityBuilder<T>> where T : EmployeeSeniorityBuilder<T>
        {
            public T WithSeniority(string seniority)
            {
                employee.Seniority = seniority;
                return (T)this;
            }
        }

        public class EmployeeBuilderDirector : EmployeeSeniorityBuilder<EmployeeBuilderDirector>
        {

            public static EmployeeBuilderDirector NewEmployee => new EmployeeBuilderDirector();
        }

        public class Employee
        {
            public string Name { get; set; }
            public string Position { get; set; }
            public double Salary { get; set; }
            public string Seniority { get; set; }

            public override string ToString()
            {
                return $"Name: {Name}, Position: {Position}, Salary: {Salary}";
            }
        }

        public void Main()
        {
            var emp = EmployeeBuilderDirector.NewEmployee
                .WithSeniority("Senior")
                .AtPosition("Software Developer")
                .WithSalary(999999)
                .Build();

            Console.WriteLine(emp);
        }
    }
}
