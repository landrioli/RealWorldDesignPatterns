using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace RealWorldDesignPatterns.Creational.PrototypePattern
{
    public class CopySerializationPrototype
    {
        [Serializable] // this is, unfortunately, required
        public class Foo
        {
            public uint Stuff;
            public string Whatever;

            public override string ToString()
            {
                return $"{nameof(Stuff)}: {Stuff}, {nameof(Whatever)}: {Whatever}";
            }
        }

        public void Run()
        {
            Foo foo = new Foo { Stuff = 111, Whatever = "leandro" };

            Foo foo2 = foo.DeepCopyXml();
            foo2.Whatever = "le";

            Console.WriteLine(foo);
            Console.WriteLine(foo2);
        }
    }
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();
            return (T)copy;
        }

        public static T DeepCopyXml<T>(this T self)
        {
            using (var ms = new MemoryStream())
            {
                XmlSerializer s = new XmlSerializer(typeof(T));
                s.Serialize(ms, self);
                ms.Position = 0;
                return (T)s.Deserialize(ms);
            }
        }
    }
}
