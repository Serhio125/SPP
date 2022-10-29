using System;
using Lab2.Main;

namespace Lab2.Interfaces
{
    public interface IValueGenerator
    {
        public object Generate(Type type, GeneratorContext context);
        bool CanGenerate(Type type);
    }
}