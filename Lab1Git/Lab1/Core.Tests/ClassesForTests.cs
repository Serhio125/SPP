using System.Threading;
using Tracer.Core;

namespace Core.Tests
{
    public class test1
    {

        private Itracer _tracer;
        
        public test1(Itracer tracer)
        {
            _tracer = tracer;
        }

        public void test1Method()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            _tracer.StopTrace();
        }
    }

    public class test2
    {
        private Itracer _tracer;
        private test2_1 t2_1;
        private test2_2 t2_2;
        public test2(Itracer tracer)
        {
            _tracer = tracer;
            t2_1 = new test2_1(tracer);
            t2_2 = new test2_2(tracer);
        }

        public void Method2()
        {
            t2_1.test2Method();
            t2_2.test2Method_2();
        }
        
    }
    
    public class test2_1
    {
        private Itracer _tracer;

        public test2_1(Itracer tracer)
        {
            _tracer = tracer;
        }

        public void test2Method()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            _tracer.StopTrace();    
        }
    }

    public class test2_2
    {
        private Itracer _tracer;
        public test2_2(Itracer tracer)
        {
            _tracer = tracer;
        }
        public void test2Method_2()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            _tracer.StopTrace();    
        }
    }

    public class test3
    {
        private Itracer _tracer;
        private test3_1 t3_1;
        private test3_2 t3_2;

        public test3(Itracer tracer)
        {
            _tracer = tracer;
            t3_1 = new test3_1(tracer);
            t3_2 = new test3_2(tracer);
        }

        public void Method3()
        {
            t3_1.test3Method1();
            t3_2.test3Method2();
        }
        
    }

    public class test3_1
    {
        private Itracer _tracer;
        private test3_1_1 t3_1_1;
        private test3_1_2 t3_1_2;

        public test3_1(Itracer tracer)
        {
            _tracer = tracer;
            t3_1_1 = new test3_1_1(tracer);
            t3_1_2 = new test3_1_2(tracer);
        }
        public void test3Method1()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            t3_1_1.test3Method3_1();
            t3_1_2.test3Method1_2();
            _tracer.StopTrace();
        }
    }

    public class test3_1_1
    {
        private Itracer _tracer;
        private test3_1_1_1 t3_1_1_1;
        public test3_1_1(Itracer tracer)
        {
            _tracer = tracer;
            t3_1_1_1 = new test3_1_1_1(tracer);
        }

        public void test3Method3_1()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            t3_1_1_1.test3Method3_1_1();
            _tracer.StopTrace();
        }
    }

    public class test3_1_1_1
    {
        private Itracer _tracer;
        public test3_1_1_1(Itracer tracer)
        {
            _tracer = tracer;
        }

        public void test3Method3_1_1()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            _tracer.StopTrace();
        }
    }
    public class test3_1_2
    {
        private Itracer _tracer;
        public test3_1_2(Itracer tracer)
        {
            _tracer = tracer;
        }

        public void test3Method1_2()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            _tracer.StopTrace();
        }
    }
    public class test3_2
    {
        private Itracer _tracer;

        public test3_2(Itracer tracer)
        {
            _tracer = tracer;
        }

        public void test3Method2()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            _tracer.StopTrace();
        }
    }
    public class test4_1
    {

        private Itracer _tracer;
        
        public test4_1(Itracer tracer)
        {
            _tracer = tracer;
        }

        public void test4_1Method()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            _tracer.StopTrace();
        }
    }
    public class test4_2
    {

        private Itracer _tracer;
        
        public test4_2(Itracer tracer)
        {
            _tracer = tracer;
        }

        public void test4_2Method()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            _tracer.StopTrace();
        }
    }
    public class test5_1
    {
        private Itracer _tracer;
        private test5_1_1 t5_1_1;
        private test5_1_2 t5_1_2;

        public test5_1(Itracer tracer)
        {
            _tracer = tracer;
            t5_1_1 = new test5_1_1(tracer);
            t5_1_2 = new test5_1_2(tracer);
        }
        public void test5Method1()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            t5_1_1.test5Method1_1();
            t5_1_2.test5Method1_2();
            _tracer.StopTrace();
        }
    }

    public class test5_1_1
    {
        private Itracer _tracer;
        private test5_1_1_1 t5_1_1_1;
        public test5_1_1(Itracer tracer)
        {
            _tracer = tracer;
            t5_1_1_1 = new test5_1_1_1(tracer);
        }

        public void test5Method1_1()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            t5_1_1_1.test5Method5_1_1();
            _tracer.StopTrace();
        }
    }

    public class test5_1_1_1
    {
        private Itracer _tracer;
        public test5_1_1_1(Itracer tracer)
        {
            _tracer = tracer;
        }

        public void test5Method5_1_1()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            _tracer.StopTrace();
        }
    }
    public class test5_1_2
    {
        private Itracer _tracer;
        public test5_1_2(Itracer tracer)
        {
            _tracer = tracer;
        }

        public void test5Method1_2()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            _tracer.StopTrace();
        }
    }

    public class test5_2
    {
        private Itracer _tracer;
        private test5_2_1 t5_2_1;

        public test5_2(Itracer tracer)
        {
            _tracer = tracer;
            t5_2_1 = new test5_2_1(tracer);
        }

        public void test5Method2()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            t5_2_1.test5Method2_1();
            _tracer.StopTrace();
        }
    }

    public class test5_2_1
    {
        private Itracer _tracer;

        public test5_2_1(Itracer tracer)
        {
            _tracer = tracer;
        }

        public void test5Method2_1()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            _tracer.StopTrace();
        }
    }
}