using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using Core;
using Lab3.Models;
using File = System.IO.File;

namespace Console_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            string path="D:\\Study\\3_1\\SPP\\Lab3\\Console_Test";
            int count = 15;
            var scanner = new Scanner();
            sw.Start();
            var result = scanner.StartScan(path,count);
            sw.Stop();
            JsonSerializerOptions jso = new JsonSerializerOptions() { WriteIndented = true };
            var str=JsonSerializer.Serialize(result,jso);
            FileStream fs = File.Create("JSON.txt");
            fs.Write(Encoding.UTF8.GetBytes(str));
            fs.Close();
            Console.WriteLine("Time : {0} mlsek",sw.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}