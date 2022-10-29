using System;
using System.IO;
using Tracer.Core;

namespace Tracer.Serialization.Abstractions
{
    public interface ITraceResultSerializer
    {
        public String SerializeResult { get; }
        void Serialize(TraceResult traceResult, Stream to);
    }
}