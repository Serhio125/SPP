using System.Linq.Expressions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using Lab2.Interfaces;
using Lab2.Main;

namespace Testing
{

    public class MyHandleGenerator : IValueGenerator
    {
        public object Generate(Type t, GeneratorContext context)
        {
            return "Hello, world!";
        }

        public bool CanGenerate(Type t)
        {
            return true;
        }
    }
    
    public class config
    {
        public int pbl=8;
        public void GetProperty<TClass, TType>(Expression<Func<TClass, TType>> e)
        {
            var h = e.Body;
            /*
                test1 t1;
                e.Body=t1.a;            
            */
            Console.WriteLine(h);
            var member = e.Body as MemberExpression;
            var memberName = member.Member.Name;
            Console.WriteLine(memberName);
        }
    }
    public class test1
    {
        public short a { get; set; }
        public short b { get; set; }
        public short c;
        public string s;
        public test1(byte b)
        {
            a = Convert.ToInt16(b + 300);
        }
        public test1()
        {
            a = 5;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
           /* Type type = typeof(List<long>);
            if (type.IsGenericType)
            {
                Console.WriteLine("Generic");
                Console.WriteLine(type.GenericTypeArguments[0].Name);
            }
            Console.WriteLine(type.Name);
            Console.WriteLine(typeof(List<int>).Name);
            var list = (IList)Activator.CreateInstance(type);
            Console.WriteLine(list.Count);*/
            int t2;
            Console.WriteLine(typeof(int).GetProperties().Length);
            FakerConfig config = new FakerConfig();
            Faker faker = new Faker(config);
            config.add<test1, string, MyHandleGenerator>(t=>t.s);
            test1 t1 = faker.Create<test1>();
            Console.WriteLine(t1.s);
            /* List<byte> test1 = faker.Create<List<byte>>();
             foreach(var i in test1)
             Console.WriteLine(i);*/
            /* test1 t2 = new test1();
             
             test1 t1 = faker.Create<test1>();
             JsonSerializerOptions jso = new JsonSerializerOptions()
             {
                 WriteIndented = true
             };
             string JsonString = JsonSerializer.Serialize(t1, jso);
             Console.WriteLine(JsonString);*/
            /*config c = new config();
            test1 t1 = new test1();
            c.GetProperty<test1,short>(t=>t1.c);*/

        }
    }
}