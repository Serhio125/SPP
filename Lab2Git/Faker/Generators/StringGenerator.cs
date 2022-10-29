using System;
using Lab2.Interfaces;
using Lab2.Main;

namespace Lab2.Generators
{
    public class StringGenerator : IValueGenerator
    {
        public object Generate(Type type, GeneratorContext context)
        {
            string str="";
            string all = "qwertyuiopasdfgghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890";
            int i = context.Random.Next(3, 10);
            for (int j = 1; j <= i; j++)
                str += all[context.Random.Next(all.Length)];
            return str;
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(string);
        }
    }
}