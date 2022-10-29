using System.Threading;
using NUnit.Framework;

namespace Core.Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Tracer.Core.Tracer tracer = new Tracer.Core.Tracer();
            test1 t1 = new test1(tracer);
            t1.test1Method();
            var traceResult = tracer.GetTraceResult().Threads;
            Assert.AreEqual(1,traceResult.Count);
            Assert.AreEqual(1,traceResult[0].id);
            Assert.AreEqual(1,traceResult[0].Methods.Count);
            Assert.AreEqual("test1",traceResult[0].Methods[0].Class);
            Assert.AreEqual("test1Method",traceResult[0].Methods[0].Name);
            Assert.AreEqual(0,traceResult[0].Methods[0].Methods.Count);
        }
        [Test]
        public void Test2()
        {
            Tracer.Core.Tracer tracer = new Tracer.Core.Tracer();
            test2 t2 = new test2(tracer);
            t2.Method2();
            var traceResult = tracer.GetTraceResult().Threads;
            Assert.AreEqual(1,traceResult.Count);
            Assert.AreEqual(1,traceResult[0].id);
            Assert.AreEqual(2,traceResult[0].Methods.Count);
            Assert.AreEqual("test2_1",traceResult[0].Methods[0].Class);
            Assert.AreEqual("test2Method",traceResult[0].Methods[0].Name);
            Assert.AreEqual(0,traceResult[0].Methods[0].Methods.Count);
            Assert.AreEqual("test2_2",traceResult[0].Methods[1].Class);
            Assert.AreEqual("test2Method_2",traceResult[0].Methods[1].Name);
            Assert.AreEqual(0,traceResult[0].Methods[1].Methods.Count);
        }
        [Test]
        public void Test3()
        {
            Tracer.Core.Tracer tracer = new Tracer.Core.Tracer();
            test3 t3 = new test3(tracer);
            t3.Method3();
            var traceResult = tracer.GetTraceResult().Threads;
            Assert.AreEqual(1,traceResult.Count);
            Assert.AreEqual(1,traceResult[0].id);
            Assert.AreEqual(2,traceResult[0].Methods.Count);
            Assert.AreEqual("test3_1",traceResult[0].Methods[0].Class);
            Assert.AreEqual("test3Method1",traceResult[0].Methods[0].Name);
            Assert.AreEqual(2,traceResult[0].Methods[0].Methods.Count);
            Assert.AreEqual("test3_1_1",traceResult[0].Methods[0].Methods[0].Class);
            Assert.AreEqual("test3Method3_1",traceResult[0].Methods[0].Methods[0].Name);
            Assert.AreEqual(1,traceResult[0].Methods[0].Methods[0].Methods.Count);
            Assert.AreEqual("test3_1_1_1",traceResult[0].Methods[0].Methods[0].Methods[0].Class);
            Assert.AreEqual("test3Method3_1_1",traceResult[0].Methods[0].Methods[0].Methods[0].Name);
            Assert.AreEqual(0,traceResult[0].Methods[0].Methods[0].Methods[0].Methods.Count);
            Assert.AreEqual("test3_1_2",traceResult[0].Methods[0].Methods[1].Class);
            Assert.AreEqual("test3Method1_2",traceResult[0].Methods[0].Methods[1].Name);
            Assert.AreEqual(0,traceResult[0].Methods[0].Methods[1].Methods.Count);
            Assert.AreEqual("test3_2",traceResult[0].Methods[1].Class);
            Assert.AreEqual("test3Method2",traceResult[0].Methods[1].Name);
            Assert.AreEqual(0,traceResult[0].Methods[1].Methods.Count);
        }
        [Test]
        public void Test4()
        {
            Tracer.Core.Tracer tracer = new Tracer.Core.Tracer();
            test4_1 t4_1 = new test4_1(tracer);
            test4_2 t4_2 = new test4_2(tracer);
            var t1 = new Thread(() =>
            {
                t4_1.test4_1Method();
            });
            var t2 = new Thread(() =>
            {
                t4_2.test4_2Method();
            });
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            var traceResult = tracer.GetTraceResult().Threads;
            Assert.AreEqual(2,traceResult.Count);
            Assert.AreEqual(1,traceResult[0].id);
            Assert.AreEqual(1,traceResult[0].Methods.Count);
            Assert.AreEqual("test4_1",traceResult[0].Methods[0].Class);
            Assert.AreEqual("test4_1Method",traceResult[0].Methods[0].Name);
            Assert.AreEqual(0,traceResult[0].Methods[0].Methods.Count);
            Assert.AreEqual(2,traceResult[1].id);
            Assert.AreEqual(1,traceResult[1].Methods.Count);
            Assert.AreEqual("test4_2",traceResult[1].Methods[0].Class);
            Assert.AreEqual("test4_2Method",traceResult[1].Methods[0].Name);
            Assert.AreEqual(0,traceResult[0].Methods[0].Methods.Count);

        }
        [Test]
        public void Test5()
        {
            Tracer.Core.Tracer tracer = new Tracer.Core.Tracer();
            test5_1 t5_1 = new test5_1(tracer);
            test5_2 t5_2 = new test5_2(tracer);
            var t1 = new Thread(() =>
            {
                t5_1.test5Method1();
            });
            var t2 = new Thread(() =>
            {
                t5_2.test5Method2();
            });
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            var traceResult = tracer.GetTraceResult().Threads;
            Assert.AreEqual(2,traceResult.Count);
            Assert.AreEqual(1,traceResult[0].id);
            Assert.AreEqual(1,traceResult[0].Methods.Count);
            Assert.AreEqual("test5_1",traceResult[0].Methods[0].Class);
            Assert.AreEqual("test5Method1",traceResult[0].Methods[0].Name);
            Assert.AreEqual(2,traceResult[0].Methods[0].Methods.Count);
            Assert.AreEqual("test5_1_1",traceResult[0].Methods[0].Methods[0].Class);
            Assert.AreEqual("test5Method1_1",traceResult[0].Methods[0].Methods[0].Name);
            Assert.AreEqual(1,traceResult[0].Methods[0].Methods[0].Methods.Count);
            Assert.AreEqual("test5_1_1_1",traceResult[0].Methods[0].Methods[0].Methods[0].Class);
            Assert.AreEqual("test5Method5_1_1",traceResult[0].Methods[0].Methods[0].Methods[0].Name);
            Assert.AreEqual(0,traceResult[0].Methods[0].Methods[0].Methods[0].Methods.Count);
            Assert.AreEqual(2,traceResult[1].id);
            Assert.AreEqual(1,traceResult[1].Methods.Count);
            Assert.AreEqual("test5_2",traceResult[1].Methods[0].Class);
            Assert.AreEqual("test5Method2",traceResult[1].Methods[0].Name);
            Assert.AreEqual(1,traceResult[1].Methods[0].Methods.Count);
        }
    }
}