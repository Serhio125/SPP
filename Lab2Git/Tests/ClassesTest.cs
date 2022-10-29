using System;
using System.Collections.Generic;
using Lab2.Interfaces;
using Lab2.Main;

namespace Tests
{
    public class ForTest4
    {
        public List<List<List<int>>> ListofList { get; set; }
    }

    public class ForTest5
    {
        public int a;
        public int b;
        public int c { get; set; }
        public int d { get; set; }
    }

    public class ForTest6
    {
        public int a;
        public int b = 9;
        public int c { get; set; }
        public int d { get; set; }

        public ForTest6(byte b)
        {
            c = b + 300;
        }
    }

    public class ForTest7
    {
        public int a;
        public int b;
        public int c { get; set; }
        public int d { get; set; }

        public ForTest7(byte x)
        {
            c = x + 300;
        }

        public ForTest7(byte x, short y)
        {
            c = x + 300;
            a = y + short.MaxValue;
        }
    }

    public class ForTest8
    {
        public int a;
        public int b;
        public int c { get; set; }
        public int d { get; set; }

        public ForTest8(byte x)
        {
            c = x + 300;
        }

        public ForTest8(byte x, short y)
        {
            a = 1;
            b = 1;
            c = 1;
            d = 1;
        }

        public ForTest8(byte x, short y, byte z)
        {
            if (x != 0 && y != 0 && z != 0)
                throw new Exception();
        }
    }

    public class MyHandleGenerator : IValueGenerator
    {
        public bool CanGenerate(Type t)
        {
            return true;
        }

        public object Generate(Type t, GeneratorContext context)
        {
            return "Hello, world!";
        }
    }

    public class ForTest9
    {
        public string notmessage;
        public string message;
        public int a;
    }

    public class ForTest10
    {
        public int c;
        public int d { get; set; }
        public Recursion rec;
    }

    public class Recursion
    {
        public int a;
        public int b { get; set; }
        public ForTest10 ft10;
    }
}