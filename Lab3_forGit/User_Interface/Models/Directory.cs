using System.Collections.ObjectModel;
using Core.ScannerResult;
using System;
namespace Lab3.Models
{
    public class Directory : FileSystemObjectInfo
    {
        public Directory(string name, long size, double percents)
        {
            Name = name;
            Size = size;
            Percents = percents;
            Directories = new ObservableCollection<Directory>();
        }
        public Directory(ScannerResult scannerResult,long fullsize)
        {
            Name = "";  Size = 0;  Percents = 0;
            Directories = new ObservableCollection<Directory>();
            Directories.Add(ConvertResult(scannerResult,fullsize));
        }
        private Directory? ConvertResult(ScannerResult ScanResult, long fullSize)
        {
            if (ScanResult.Name == null) //CAN BE!!
            {
                return null;
            }
            string name = ScanResult.Name;
            var size = ScanResult.Size;
            var percents = Convert.ToDouble(size) / Convert.ToDouble(fullSize) * 100;
            //var root = new Directory(name,size,percents);
            var root = new Directory(name,size,percents);
            root.image = @"D:\Study\3_1\SPP\Lab3\User_Interface\Pictures\folder.png";

            foreach (var directory in ScanResult.Directories)
            {
                var node = ConvertResult(directory, fullSize);
                if (node != null)
                    root.Directories.Add(node);
            }

            foreach (var file in ScanResult.Files)
            {
                //root.Files.Add(new File(file.Name,file.Size,Convert.ToDouble(file.Size)/Convert.ToDouble(fullSize)*100));
                root.Directories.Add(
                    new Directory(file.Name, file.Size,
                            Convert.ToDouble(file.Size) / Convert.ToDouble(fullSize) * 100)
                        { image = @"D:\Study\3_1\SPP\Lab3\User_Interface\Pictures\file.png" });
            }

            return root;
        }
        public ObservableCollection<Directory> Directories { get; set; }/*= new ObservableCollection<Directory>();*/
        public ObservableCollection<File> Files { get; set; }= new ObservableCollection<File>();/////Directory changed on FileSystemObfectInfo
    }
}