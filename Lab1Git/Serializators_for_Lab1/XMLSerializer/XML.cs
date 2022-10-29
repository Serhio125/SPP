
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;
using Tracer.Core;
using Tracer.Serialization.Abstractions;

namespace XMLSerializer
{
    public class XML : ITraceResultSerializer
    {
        public XML()
        {
            SerializeResult = "XML";
        }
        
        public String SerializeResult { get; }

        public void Serialize(TraceResult traceResult, Stream to)
        {
            var settings = new XmlWriterSettings
            {
                Indent=true,
                Encoding=Encoding.UTF8
            };
            XmlWriter xmlWriter=XmlWriter.Create(to,settings);
            System.Xml.Serialization.XmlSerializer xmlSerializer = new XmlSerializer(typeof(TraceResult));
            if (to.CanWrite)
            {
                xmlSerializer.Serialize(xmlWriter,traceResult);
            }
        }
    }
}