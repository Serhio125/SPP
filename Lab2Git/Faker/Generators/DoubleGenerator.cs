using System;
using Lab2.Interfaces;
using Lab2.Main;
namespace Lab2.Generators
{
    public class DoubleGenerator : IValueGenerator
    {
        public object Generate(Type type, GeneratorContext context)
        {
            return context.Random.NextDouble()*double.MaxValue;
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(double);
        }
    }
}