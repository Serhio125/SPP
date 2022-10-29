using System;
using Lab2.Interfaces;
using Lab2.Main;

namespace Lab2.Generators
{
    public class ByteGenerator : IValueGenerator
    {
        public object Generate(Type type, GeneratorContext context)
        {
            return (byte)context.Random.Next(byte.MaxValue + 1);
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(byte);
        }
    }
}