using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;
using Orientation = System.Windows.Controls.Orientation;
using TreeView = System.Windows.Controls.TreeView;

namespace Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    
    public partial class MainWindow : Window
    {
        //public ApplicationModel.ApplicationModel appModel { get; set; }
        public MainWindow()
        {
            
            InitializeComponent();
            //appModel = new ApplicationModel.ApplicationModel();
            //DataContext = appModel;
            DataContext = new ApplicationModel.ApplicationModel();
            
        }
    }
    /*public class show_message
    {
        public void show_mess(object sender, PropertyChangedEventArgs args)
        {
          // MessageBox.Show(args.PropertyName);
            var propinfo=sender.GetType().GetProperty(args.PropertyName);
            var mess = propinfo.GetValue(sender);
            MessageBox.Show((string)mess);
        }
    }
    public class for_example : INotifyPropertyChanged
    {
        private string message;
        public string Message
        {
            get { return message;}
            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop="")
        {
            //MessageBox.Show("Changed!!!");
            if (PropertyChanged!=null)
                PropertyChanged(this,new PropertyChangedEventArgs(prop));
        }
    }*/
}