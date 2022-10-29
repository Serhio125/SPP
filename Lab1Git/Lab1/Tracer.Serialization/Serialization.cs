using System;
using System.IO;
using System.Reflection;
using Tracer.Core;
using Tracer.Serialization.Abstractions;

namespace Tracer.Serialization
{
    public class Serialization
    {
        private TraceResult traceResult;

        public Serialization(TraceResult _traceResult)
        {
            traceResult = _traceResult;
        }

        public void execute_serialization()
        {
            /*Assembly asm=Assembly.LoadFrom("D:\\Study\\3_1\\SPP\\RealLab1\\Serializators_for_Lab1\\JsonSerializer\\bin\\Debug\\netcoreapp3.1\\JsonSerializer.dll");
            Type[] types = asm.GetTypes();
            foreach (Type type in types)
            {
                if (typeof(ITraceResultSerializer).IsAssignableFrom(type))
                {
                    var serialization = (ITraceResultSerializer)Activator.CreateInstance(type);
                    FileStream fs = File.Create(serialization.SerializeResult + ".txt");
                    serialization.Serialize(traceResult,fs);
                    fs.Close();
                }
            }
            asm=Assembly.LoadFrom("D:\\Study\\3_1\\SPP\\RealLab1\\Serializators_for_Lab1\\XMLSerializer\\bin\\Debug\\netcoreapp3.1\\XMLSerializer.dll");
            types = asm.GetTypes();
            foreach (Type type in types)
            {
                if (typeof(ITraceResultSerializer).IsAssignableFrom(type))
                {
                    var serialization = (ITraceResultSerializer)Activator.CreateInstance(type);
                    FileStream fs = File.Create(serialization.SerializeResult + ".txt");
                    serialization.Serialize(traceResult,fs);
                    fs.Close();
                }
            }*/
            var dllFiles = Directory.EnumerateFiles(".", "*.dll");
            foreach (var dllFile in dllFiles)
            {
                Assembly asm=Assembly.LoadFrom(dllFile);
                Type[] types = asm.GetTypes();
                foreach (Type type in types)
                {
                    if ((typeof(ITraceResultSerializer).IsAssignableFrom(type))&&(typeof(ITraceResultSerializer)!=type))
                    {
                        var serialization = (ITraceResultSerializer)Activator.CreateInstance(type);
                        FileStream fs = File.Create(serialization.SerializeResult + ".txt");
                        serialization.Serialize(traceResult,fs);
                        fs.Close();
                    }
                }
            }
        }
    }
}