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

            //string id = data.ID;
            //int lenId = getFixedLength("ID");

            int lenId = Utility.GetFixedLength(typeof(Data), "Name");
        }



        //private int getFixedLength(string propName)
        //{
        //    var type = typeof(Data);
        //    var properties = type.GetProperties();

        //    foreach (var property in properties)
        //    {
        //        var attributes = property.GetCustomAttributes(false);
        //        foreach (var attribute in attributes)
        //        {
        //            if (attribute.GetType() == typeof(FixedLength) && property.Name == propName)
        //            {
        //                FixedLength a = (FixedLength)attribute;
        //                int len = a.Length;
        //                return len;
        //            }
        //        }
        //    }

        //    return 0;
        //}

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



    public static class Utility
    {
        public static int GetFixedLength(Type ClassName, string propName)
        {
            var properties = ClassName.GetProperties();

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(false);
                foreach (var attribute in attributes)
                {
                    if (attribute.GetType() == typeof(FixedLength) && property.Name == propName)
                    {
                        FixedLength a = (FixedLength)attribute;
                        int len = a.Length;
                        return len;
                    }
                }
            }

            return 0;
        }
    }



    public class FixedLength : Attribute
    {
        public readonly int Length;

        public FixedLength(int length)
        {
            this.Length = length;
        }
    }
    
}
