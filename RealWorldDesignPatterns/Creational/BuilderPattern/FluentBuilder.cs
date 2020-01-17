using System;
using System.Collections.Generic;
using System.Text;

namespace RealWorldDesignPatterns.Creational.BuilderPattern
{
    public class FluentBuilder
    {
        public class ShippingBuilder
        {
            private Shipping _instance;

            public ShippingBuilder Start()
            {
                _instance = new Shipping();
                return this;
            }

            public ShippingBuilder WithCustomerName(string name)
            {
                _instance.Name = name;
                return this;
            }

            public ShippingBuilder WithAddress(string address)
            {
                _instance.Address = address;
                return this;
            }

            public ShippingBuilder WithTaxes(bool hasTaxes)
            {
                _instance.HasTaxes = hasTaxes;
                return this;
            }

            public ShippingBuilder WithTracking(bool hasTracking)
            {
                _instance.HasTracking = hasTracking;
                return this;
            }

            public Shipping Build()
            {
                return _instance;
            }
        }

        public class Shipping
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public bool HasTaxes { get; set; }
            public bool HasTracking { get; set; }

            public override string ToString()
            {
                return $"Name: {Name}, Address: {Address}, HasTaxes: {HasTaxes}, HasTracking: {HasTracking}.";
            }
        }

        public void Main()
        {
            var builder = new ShippingBuilder();

            var shipping = builder.Start()
                .WithAddress("abc")
                .WithCustomerName("Leandro")
                .WithTaxes(true)
                .WithTracking(false).Build();

            Console.WriteLine(shipping.ToString());
        }
    }
}
