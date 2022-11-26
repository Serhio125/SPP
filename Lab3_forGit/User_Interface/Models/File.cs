using System.Windows.Forms;
namespace Lab3.Models
{
    public class File : FileSystemObjectInfo
    {
        public File(string name, long size, double percents)
        {
            Name = name;
            Size = size;
            Percents = percents;
        }
    }
}