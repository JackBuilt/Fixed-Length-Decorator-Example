using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributesExample
{
    public class Class1
    {
        List<Data> DataList = new List<Data>();

        public Class1()
        {
            init();
            CheckData();
        }


        private void init()
        {
            // Create some data.
            Data data;
            data = new Data();
            data.ID = "1234";
            data.Name = "FirstVar";
            data.Value = "This is string value one";
            DataList.Add(data);

            data = new Data();
            data.ID = "2468";
            data.Name = "SecondVar";
            data.Value = "This is string value two";
            DataList.Add(data);
        }

        
        private void CheckData()
        {
            Data data = DataList[0];

            string id = data.ID;
            int lenId = getFixedLength("ID");
        }



        private int getFixedLength(string propName)
        {
            var type = typeof(Data);// obj.GetType();
            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(false);
                foreach (var attribute in attributes)
                {
                    if (attribute.GetType() == typeof(FixedLength) && property.Name == propName)
                    {
                        FixedLength a = (FixedLength)attribute;
                        int test = a.Length;
                        //string msg = "The Primary Key for the {0} class is the {1} property";
                        //Console.WriteLine(msg, type.Name, property.Name);
                        return test;
                    }
                }
            }




            //var customAttributes = (FixedLength[])typeof(Data).GetCustomAttributes(typeof(FixedLength), true);
            //if (customAttributes.Length > 0)
            //{
            //    var myAttribute = customAttributes[0];
            //    int value = myAttribute.Length;
            //    // TODO: Do something with the value
            //}


            //System.Attribute[] attrs = Attribute.GetCustomAttributes(typeof(FixedLength));  // Reflection.

            //// Displaying output.
            //foreach (System.Attribute attr in attrs)
            //{
            //    if (attr is FixedLength)
            //    {
            //        FixedLength a = (FixedLength)attr;
            //        return a.Length;
            //    }
            //}

            return 0;
        }

    }


    public class Data
    {
        [FixedLength(9)]
        public string ID { get; set; }
        [FixedLength(20)]
        public string Name { get; set; }
        [FixedLength(50)]
        public string Value { get; set; }

        
    }




    public class FixedLength : Attribute
    {
        public readonly int Length;

        public FixedLength(int length)
        {
            this.Length = length;
        }
    }





    //public static class EnumExtensions
    //{
    //    public static TAttribute GetAttribute<TAttribute>(this Enum value)
    //        where TAttribute : Attribute
    //    {
    //        var type = value.GetType();
    //        var name = Enum.GetName(type, value);
    //        return type.GetField(name) // I prefer to get attributes this way
    //            .GetCustomAttributes(false)
    //            .OfType<TAttribute>()
    //            .SingleOrDefault();
    //    }
    //}

    //public class PlanetInfoAttribute : Attribute
    //{
    //    internal PlanetInfoAttribute(double mass, double radius)
    //    {
    //        this.Mass = mass;
    //        this.Radius = radius;
    //    }
    //    public double Mass { get; private set; }
    //    public double Radius { get; private set; }
    //}


    //public enum Planet
    //{
    //    [PlanetInfo(3.303e+23, 2.43970e6)]
    //    Mecury,
    //    [PlanetInfo(4.869e+24, 6.05180e6)]
    //    Venus,
    //    [PlanetInfo(5.976e+24, 6.37814e6)]
    //    Earth,
    //    [PlanetInfo(6.421e+23, 3.39720e6)]
    //    Mars,
    //    [PlanetInfo(1.900e+27, 7.14920e7)]
    //    Jupiter,
    //    [PlanetInfo(5.688e+26, 6.02680e7)]
    //    Saturn,
    //    [PlanetInfo(8.686e+25, 2.55590e7)]
    //    Uranus,
    //    [PlanetInfo(1.024e+26, 2.47460e7)]
    //    Neptune,
    //    [PlanetInfo(1.270e+22, 1.13700e6)]
    //    Pluto,
    //}

    //public static class PlanetExtensions
    //{
    //    public static double GetSurfaceGravity(this Planet p)
    //    {
    //        var attr = p.GetAttribute<PlanetInfoAttribute>();
    //        return G * attr.Mass / (attr.Radius * attr.Radius);
    //    }

    //    public static double GetSurfaceWeight(this Planet p, double otherMass)
    //    {
    //        return otherMass * p.GetSurfaceGravity();
    //    }

    //    public const double G = 6.67300E-11;
    //}
}
