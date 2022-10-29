using Lab2.Interfaces;
using Lab2.Main;
using System;
namespace Lab2.Generators
{
    public class BoolGenerator : IValueGenerator
    {
        public object Generate(Type type, GeneratorContext context)
        {
            return Convert.ToBoolean(context.Random.Next(2));
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(bool);
        }
    }
}