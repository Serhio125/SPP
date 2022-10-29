using System;
using System.Collections;
using System.Collections.Generic;
using Lab2.Interfaces;
using Lab2.Main;

namespace Lab2.Generators
{
    public class ListGenerator : IValueGenerator
    {
        public object Generate(Type type, GeneratorContext context)
        {
            var list = (IList)Activator.CreateInstance(type);
            int size = context.Random.Next(3,7);
            Type listType = type.GetGenericArguments()[0];
            for (int i = 1; i <= size; i++)
                list.Add(context.Faker.Create(listType));
            return list;
        }

        public bool CanGenerate(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
        }
    }
}