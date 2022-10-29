using System;

namespace Lab2.Main
{
    public class GeneratorContext
    {
        public GeneratorContext(Random random,Faker faker)
        {
            Random = random;
            Faker = faker;
        }

        public Random Random { get; }
        
        public Faker Faker { get; }
    }
}