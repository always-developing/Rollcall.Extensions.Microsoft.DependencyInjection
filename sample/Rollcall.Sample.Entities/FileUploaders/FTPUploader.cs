using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rollcall.Sample
{
    public class FTPUploader : IFileUploader
    {
        public FTPUploader()
        {
            //Console.WriteLine($"{this.GetType().Name} initialized");
        }

        public string GetName()
        {
            return "ftp";
        }

        public void UploadFile()
        {
            //Console.WriteLine("File uploaded to FTP");
        }
    }
}
