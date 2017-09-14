using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Fiver.Mvc.RazorPages.More.Models;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Fiver.Mvc.RazorPages.More.Pages
{
    public class FileDownloadModel : PageModel
    {
        private readonly IFileProvider fileProvider;

        public FileDownloadModel(IFileProvider fileProvider)
        {
            this.fileProvider = fileProvider;
        }

        public FilesViewModel Files { get; set; } = new FilesViewModel();

        public void OnGet()
        {
            foreach (var item in this.fileProvider.GetDirectoryContents(""))
            {
                this.Files.Items.Add(
                    new FileDetails { Name = item.Name, Path = item.PhysicalPath });
            }
        }

        public async Task<IActionResult> OnGetDownload(string filename)
        {
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot", "files", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
}