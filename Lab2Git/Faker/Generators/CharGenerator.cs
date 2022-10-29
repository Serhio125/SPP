﻿using Lab2.Interfaces;
using System;
using Lab2.Main;

namespace Lab2.Generators
{
    public class CharGenerator : IValueGenerator
    {
        public object Generate(Type type, GeneratorContext context)
        {
            return Convert.ToChar(context.Random.Next(char.MaxValue+1));
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(char);
        }
    }
}