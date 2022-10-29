using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using Tracer.Core;
using Tracer.Serialization;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Tracer.Core.Tracer tracer = new Tracer.Core.Tracer();
            Try tr=new Try(tracer);
            var t1 = new Thread(() =>
            {
                tr.MyMethod3();
            });
            t1.Start();
            t1.Join();
            TraceResult trres = tracer.GetTraceResult();
            Serialization serialization = new Serialization(trres);
            serialization.execute_serialization();
        }
    }

    public class Try
    {
        private Itracer _tracer;

        public Try(Itracer tracer)
        {
            _tracer = tracer;
        }

        public void MyMethod3()
        {
            MyMethod();
            MyMethod();
            MyMethod2();
        }
        public void MyMethod()
        {
            _tracer.StartTrace();
            MyMethod2();
            MyMethod2();
            MyMethod2();
            _tracer.StopTrace();
        }

        public void MyMethod2()
        {
            _tracer.StartTrace();
            Thread.Sleep(200);
            _tracer.StopTrace();
            
        }
    }
}