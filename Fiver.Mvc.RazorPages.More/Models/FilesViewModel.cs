using System.Collections.Generic;

namespace Fiver.Mvc.RazorPages.More.Models
{
    public class FileDetails
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }

    public class FilesViewModel
    {
        public List<FileDetails> Items { get; set; } 
            = new List<FileDetails>();
    }
}
