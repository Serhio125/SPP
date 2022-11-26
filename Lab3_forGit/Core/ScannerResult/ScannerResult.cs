using System.Collections.Generic;

namespace Core.ScannerResult
{
    public class ScannerResult
    {
        public string? Name { get; set; }
        public long  Size { get; set; } = -1;
        public List<ScannerResult> Files { get; set; }=new List<ScannerResult>();
        public List<ScannerResult> Directories{ get; set; }=new List<ScannerResult>();
    }
}