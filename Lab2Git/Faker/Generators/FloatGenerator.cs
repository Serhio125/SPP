using Lab2.Interfaces;
using System;
using Lab2.Main;
namespace Lab2.Generators
{
    public class FloatGneerator : IValueGenerator
    {
        public object Generate(Type type, GeneratorContext context)
        {
            return (float)(context.Random.NextDouble()*float.MaxValue);
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(float);
        }
    }
}