using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Core;
using Core.ScannerResult;
using Lab3.MyCommand;
using Directory = Lab3.Models.Directory;
using File = Lab3.Models.File;
using FileS = System.IO.File;
using Orientation = System.Windows.Forms.Orientation;
using TreeView = System.Windows.Controls.TreeView;

namespace Lab3.ApplicationModel
{
    
    public class ApplicationModel : INotifyPropertyChanged
    {
        private const int ThreadsCount=10;
        private Scanner _scanner = new Scanner();
        //something for show result//public Directory TreeDirectory;
        private volatile Directory _root;//insert modificator volatile
        private string? _StartDirectoryPath;
        private volatile bool isScanning = false;

        public Directory Root
        {
            get => _root;
            set
            {
                _root = value;
                OnPropertyChanged(nameof(Root));
            }
        }
        public bool IsScanning
        {
            get => isScanning;
            set
            {
                isScanning = value;
                OnPropertyChanged(nameof(IsScanning));
            }
        }
        public ICommand SelectDirectory { get; }
        public ICommand StartScanning { get; }
        public ICommand CancelScanning { get; }
        public ApplicationModel()
        {
            //constructors for x3 ICommand
           StartScanning = new Command(_ =>
           {
               //if (IsScanning || _StartDirectoryPath==null)
                   //return;

                   Task.Run(() =>
                   {
                       IsScanning = true;
                       /* var*/
                       ScannerResult? ScanResult = _scanner.StartScan(_StartDirectoryPath, ThreadsCount);
                       IsScanning = false;
                       if (ScanResult == null)
                           //Root = null;
                       {
                           MessageBox.Show("Bad here");
                           return;
                       }
                       //else
                           Root = new Directory(ScanResult, ScanResult.Size);
                       //Root = new Directory("",0,0);

                       /*var finish = ConvertResult(ScanResult, ScanResult.Size);
                       try
                       {
                           //Root.Directories.Add(ConvertResult(ScanResult, ScanResult.Size));
                           Root.Directories.Add(finish);
                       }
                       catch(Exception e)
                       {
                           MessageBox.Show(e.Message);
                       }*/
                       //Root = ConvertResult(ScanResult, ScanResult.Size);
                   });

           },_ => !(isScanning || _StartDirectoryPath==null));
           SelectDirectory = new Command(_ =>
           {
               var fbd = new FolderBrowserDialog();
               if (fbd.ShowDialog() != DialogResult.OK)
                   return;
               _StartDirectoryPath = fbd.SelectedPath;
           },_ => true);
           CancelScanning = new Command(_ =>
           {
              _scanner.StopScan();
              IsScanning = false;
           }, _ => IsScanning);
        }

        /*private Directory? ConvertResult(ScannerResult ScanResult, long fullSize)
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
            }*/
        
        public event PropertyChangedEventHandler PropertyChanged;
/*!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!Вопрос в Property...Handler'?'*/
        private void OnPropertyChanged(string PropName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropName));
        }
    }
}
