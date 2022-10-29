using System;
using Lab2.Interfaces;
using Lab2.Main;

namespace Lab2.Generators
{
    public class ShortGenerator : IValueGenerator
    {
        public object Generate(Type type, GeneratorContext context)
        {
            return (short)context.Random.Next(short.MaxValue);
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(short);
        }
    }
}