using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Tracer.Core;
using Tracer.Serialization.Abstractions;
using YamlDotNet.Serialization;

namespace YamlSerializer
{
    public class Yaml : ITraceResultSerializer 
    {

        public class YamlThreadInfo
        {
            public int id;
            public long Time;
            public List<YamlMethodInfo> Methods = new List<YamlMethodInfo>();
        }

        public class YamlMethodInfo
        {
            public String Name;
            public String Class;
            public long Time;
            public List<YamlMethodInfo> Methods = new List<YamlMethodInfo>();
        }

        private void reloadMethodInfo(YamlMethodInfo YamlDist, MethInfo src)
        {
            YamlDist.Name = src.Name;
            YamlDist.Class = src.Class;
            YamlDist.Time = src.Time;
            for (int i = 0; i < src.Methods.Count; i++)
            {
                YamlDist.Methods.Add(new YamlMethodInfo());
                reloadMethodInfo(YamlDist.Methods[i],src.Methods[i]);
            }
        }
        
        private List<YamlThreadInfo> YamlConvert(TraceResult traceResult)
        {
            List<YamlThreadInfo> _Methods = new List<YamlThreadInfo>();
            int i = 0;
            int j = 0;
            foreach (ThreadInfo _Method in traceResult.Threads)
            {
                _Methods.Add(new YamlThreadInfo());
                _Methods[i].id = _Method.id;
                _Methods[i].Time = _Method.Time;
                j = 0;
                foreach (MethInfo _method in _Method.Methods)
                {
                    _Methods[i].Methods.Add(new YamlMethodInfo());
                    reloadMethodInfo(_Methods[i].Methods[j],_method);
                    j++;
                }

                i++;
            }
            return _Methods;
        }
        
        public Yaml()
        {
            SerializeResult = "Yaml";
        }
        
        public String SerializeResult { get; }
        
        public void Serialize(TraceResult traceResult, Stream to)
        {

            //var serializer = new Serializer();
            var serializer = new SerializerBuilder().DisableAliases().Build();
            List<YamlThreadInfo> lyto = YamlConvert(traceResult);
            String YamlString = serializer.Serialize(lyto);
            if (to.CanWrite)
            {
                to.Write(Encoding.UTF8.GetBytes(YamlString));
            }

            
        }
    }
}