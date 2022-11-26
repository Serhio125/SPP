using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;

namespace Core
{
    public class QueueElement
    {
        public string Path { get; }
        public ScannerResult.ScannerResult Dist;

        public QueueElement(string path,ScannerResult.ScannerResult dist)
        {
            Path = path;
            Dist = dist;
        }
    }
    public class Scanner
    {
        private ScannerResult.ScannerResult _scannerResult;
        private ConcurrentQueue<QueueElement> _queue;
        private SemaphoreSlim _semaphore;
        private CancellationTokenSource? _cancellationTokenSource;
        private long findSize(ScannerResult.ScannerResult res)
        {
            long size = 0;
            foreach (var directory in res.Directories)
            {
                directory.Size = findSize(directory);
                size += directory.Size;
            }

            foreach (var file in res.Files)
            {
                size += file.Size;
            }
            return size;
        }
        
        public ScannerResult.ScannerResult? StartScan(string? DirectoryPath,int MaxCount)
        {
            if (!Directory.Exists(DirectoryPath))
                return null;
            if (MaxCount < 1)
                return null;
            _cancellationTokenSource = new CancellationTokenSource();
            _semaphore = new SemaphoreSlim(MaxCount);
            _scannerResult = new ScannerResult.ScannerResult();
            _queue = new ConcurrentQueue<QueueElement>();
            var _token = _cancellationTokenSource.Token;
            Scan(new QueueElement(DirectoryPath,_scannerResult));
            while ((_semaphore.CurrentCount != MaxCount || !_queue.IsEmpty)&&(!_token.IsCancellationRequested))
            {
                var fl = _queue.TryDequeue(out var parameter);
                if (fl)
                {
                    try
                    {
                        _semaphore.Wait(_token);
                        Task.Run(() =>
                        {
                            Scan(parameter);
                            _semaphore.Release();
                        });
                    }
                    catch (Exception e)
                    {
                        
                    }
                }
            }

            _scannerResult.Size = findSize(_scannerResult);
            return _scannerResult;
        }

        public void Scan(QueueElement data)
        {
            //Console.WriteLine(data.Path);
            string directoryPath = data.Path;
            var res = data.Dist;
            var DirInfo = new DirectoryInfo(directoryPath);
            DirectoryInfo[] directories;
            try
            {
                directories = DirInfo.GetDirectories();
            }
            catch (Exception e)
            {
                return;
            }
            //directories = DirInfo.GetDirectories();
            //Thread.Sleep(20);
            res.Name = DirInfo.Name;
            res.Directories = new List<ScannerResult.ScannerResult>();
            foreach (var directory in directories)
            {
                res.Directories.Add(new ScannerResult.ScannerResult());
                _queue.Enqueue(new QueueElement(directory.FullName,res.Directories[res.Directories.Count-1]));
            }

            res.Files = new List<ScannerResult.ScannerResult>();
            var files = DirInfo.GetFiles();
            foreach (var file in files)
            {
                //if (file.)
                res.Files.Add(new ScannerResult.ScannerResult());
                res.Files[res.Files.Count - 1].Name = file.Name;
                res.Files[res.Files.Count - 1].Size = file.Length;
            }
        }

        public void StopScan()
        {
            if (_cancellationTokenSource == null)
                return;
            _cancellationTokenSource.Cancel();
        }
    }
}