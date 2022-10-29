using System;
using System.Collections.Generic;
using System.Text.Json;
using Lab2.Main;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void TestInt()
        {
            Faker faker = new Faker();
            int a = faker.Create<int>();
            Assert.AreEqual(true,a!=0);
        }
        [Test]
        public void TestString()
        {
            Faker faker = new Faker();
            string str = faker.Create<string>();
            Assert.AreEqual(true,str!="");
            Console.WriteLine(str);
        }
        [Test]
        public void TestList()
        {
            Faker faker = new Faker();
            List<byte> lb = faker.Create<List<byte>>();
            Assert.AreEqual(true,lb.Count!=0);
        }

        [Test]
        public void TestListofLists()
        {
            Faker faker = new Faker();
            ForTest4 ft4 = faker.Create<ForTest4>();
            Assert.AreEqual(true,ft4.ListofList.Count!=0);
            foreach (var i in ft4.ListofList)
                foreach(var j in i)
                    Assert.AreEqual(true,j.Count!=0);
        }
        [Test]
        public void TestSimpleClass()
        {
            Faker faker = new Faker();
            ForTest5 ft5 = faker.Create<ForTest5>();
            Assert.AreEqual(true,ft5.a+ft5.b+ft5.c+ft5.d!=0);
            //Console.WriteLine("a - {0}, b - {1}, c- {2}, d - {3}",ft5.a,ft5.b,ft5.c,ft5.d);
        }
        [Test]
        public void TestClasswithOneConstr()
        {
            Faker faker = new Faker();
            ForTest6 ft5 = faker.Create<ForTest6>();
            Assert.AreEqual(true,ft5.a+ft5.b+ft5.c+ft5.d!=0);
            Assert.AreEqual(true,ft5.c>255);
            //Console.WriteLine("a - {0}, b - {1}, c- {2}, d - {3}",ft5.a,ft5.b,ft5.c,ft5.d);
        }
        [Test]
        public void TestClassWithSomeConstruct()
        {
            Faker faker = new Faker();
            ForTest7 ft5 = faker.Create<ForTest7>();
            Assert.AreEqual(true,ft5.a+ft5.b+ft5.c+ft5.d!=0);
            Assert.AreEqual(true,ft5.c>255);
            Assert.AreEqual(true,ft5.a>short.MaxValue-1);
           // Console.WriteLine("a - {0}, b - {1}, c- {2}, d - {3}",ft5.a,ft5.b,ft5.c,ft5.d);
        }
        [Test]
        public void TestClassWithExceptionConstr()
        {
            Faker faker = new Faker();
            ForTest8 ft5 = faker.Create<ForTest8>();
            Assert.AreEqual(true,ft5.a+ft5.b+ft5.c+ft5.d!=0);
            Assert.AreEqual(true,ft5.a==1);
            Assert.AreEqual(true,ft5.b==1);
            Assert.AreEqual(true,ft5.c==1);
            Assert.AreEqual(true,ft5.d==1);
            //Assert.AreEqual(true,ft5.a>short.MaxValue-1);
            //Console.WriteLine("a - {0}, b - {1}, c- {2}, d - {3}",ft5.a,ft5.b,ft5.c,ft5.d);
        }
        [Test]
        public void TestHandlerMessage()
        {
            FakerConfig config = new FakerConfig();
            Faker faker = new Faker(config);
            config.add<ForTest9, string, MyHandleGenerator>(t => t.message);
            ForTest9 ft5 = faker.Create<ForTest9>();
            Assert.AreEqual(true,ft5.message=="Hello, world!");
            Assert.AreEqual(true,ft5.notmessage!="");
            //Console.WriteLine(ft5.message);
            //Console.WriteLine(ft5.notmessage);
        }

        [Test]
        public void TestWithRecursion()
        {
            Faker faker = new Faker();
            ForTest10 ft10 = faker.Create<ForTest10>();
            Assert.AreEqual(ft10.c!=0,true);
            Assert.AreEqual(ft10.d!=0,true);
            Assert.AreEqual(ft10.rec!=null,true);
            Assert.AreEqual(ft10.rec.a!=0,true);
            Assert.AreEqual(ft10.rec.b!=0,true);
            Assert.AreEqual(ft10.rec.ft10==null,true);
        }
    }
}