using System;
using System.IO;
using System.Text;
using Tracer.Core;
using Tracer.Serialization.Abstractions;
using System.Text.Json;

namespace JsonSerializer
{
    public class Json : ITraceResultSerializer
    {

        public Json()
        {
            SerializeResult = "Json";
        }
        
        public String SerializeResult { get; }

        public void Serialize(TraceResult traceResult, Stream to)
        {
            JsonSerializerOptions jso = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            String jsonString = System.Text.Json.JsonSerializer.Serialize(traceResult,jso);

            if (to.CanWrite)
            {
                to.Write(Encoding.UTF8.GetBytes(jsonString));
            }
        }
    }
}