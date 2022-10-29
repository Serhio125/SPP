using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Tracer.Core
{
    public class TraceResult
    {
        public TraceResult()
        {
            
        }
        public List<ThreadInfo> Threads { get; set; } 

        public TraceResult(List<ThreadInfo> cd)
        {
            Threads = cd;
        }
    }
    
    public interface Itracer
    {
        public void StartTrace();

        public void StopTrace();

        public TraceResult GetTraceResult();
    }

    public class ThreadInfo
    {
        public int id { get; set; }
        public long Time { get; set; }
        public List<MethInfo> Methods { get; set; }=new List<MethInfo>();
    }

    public class MethInfo
    {
        public String Name{ get; set; }
        public String Class{ get; set; }
        public long Time{ get; set; }
        public List<MethInfo> Methods{ get; set; }=new List<MethInfo>();
        public Stopwatch Sw = new Stopwatch();
    }
    
    public class Tracer : Itracer
    {
        public class ConDicContent
        {
            public Stack<List<MethInfo>> MethInfoAddresses= new Stack<List<MethInfo>>();
            public ThreadInfo FirstThreadInfo = null;
        }

        private ConcurrentDictionary<int, ConDicContent> TracerDictionary=new ConcurrentDictionary<int, ConDicContent>();
        
        
        public void StartTrace()
        {
            StackTrace st = new StackTrace();
            MethodBase mb = st.GetFrame(1)!.GetMethod();
            String name = mb!.Name;
            String clss = mb!.DeclaringType!.Name;
            int ThreadID = Environment.CurrentManagedThreadId;
            TracerDictionary.GetOrAdd(ThreadID, new ConDicContent());
            if (TracerDictionary[ThreadID].FirstThreadInfo == null)
            {
                TracerDictionary[ThreadID].FirstThreadInfo = new ThreadInfo();
                TracerDictionary[ThreadID].FirstThreadInfo.id = TracerDictionary.Count;
                TracerDictionary[ThreadID].MethInfoAddresses.Push(TracerDictionary[ThreadID].FirstThreadInfo.Methods);
            }

            List<MethInfo> newmethinfo = TracerDictionary[ThreadID].MethInfoAddresses.Peek();
            newmethinfo.Add(new MethInfo());
            newmethinfo[newmethinfo.Count-1].Name = name;
            newmethinfo[newmethinfo.Count-1].Class = clss;
            newmethinfo[newmethinfo.Count-1].Sw.Start();
            TracerDictionary[ThreadID].MethInfoAddresses.Push(newmethinfo[newmethinfo.Count-1].Methods);
            
        }

        public void StopTrace()
        {
            int ThreadID = Environment.CurrentManagedThreadId;
            TracerDictionary[ThreadID].MethInfoAddresses.Pop();
            TracerDictionary[ThreadID].MethInfoAddresses.Peek()[TracerDictionary[ThreadID].MethInfoAddresses.Peek().Count-1].Sw.Stop();
            MethInfo methinfo = TracerDictionary[ThreadID].MethInfoAddresses.Peek()[TracerDictionary[ThreadID].MethInfoAddresses.Peek().Count-1];
            if (methinfo.Methods.Count == 0)
            {
                methinfo.Time = methinfo.Sw.ElapsedMilliseconds;
            }
            else
            {
                long timesum = 0;
                foreach (MethInfo i in methinfo.Methods)
                {
                    timesum += i.Time;
                }

                methinfo.Time = timesum;
            }
        }

        public TraceResult GetTraceResult()
        {
            List<ThreadInfo> lti = new List<ThreadInfo>();
            foreach (var i in TracerDictionary)
            {
                lti.Add(i.Value.FirstThreadInfo);
            }

            foreach (var i in lti)
            {
                long sum_thread = 0;
                foreach (var j in i.Methods)
                {
                    sum_thread += j.Time;
                }

                i.Time = sum_thread;
            }
            
           // Console.WriteLine(Convert.ToString(lti[0].id)+" "+Convert.ToString(lti[0].Time)+" "+Convert.ToString(lti[0].Methods[0].Name)+" "+Convert.ToString(lti[0].Methods[0].Class)+" "+Convert.ToString(lti[0].Methods[0].Time));
            return new TraceResult(lti);
        }
    }
}