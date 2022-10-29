using System;
using Lab2.Interfaces;
using Lab2.Main;

namespace Lab2.Generators
{
    public class LongGenerator : IValueGenerator
    {
        public object Generate(Type type, GeneratorContext context)
        {
            return (long)context.Random.Next(int.MaxValue);
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(long);
        }
    }
}