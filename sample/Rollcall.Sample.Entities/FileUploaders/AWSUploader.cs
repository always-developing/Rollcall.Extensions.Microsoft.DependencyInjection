using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rollcall.Sample
{
    public class AWSUploader : IFileUploader
    {
        public AWSUploader()
        {
            //Console.WriteLine($"{this.GetType().Name} initialized");
        }

        public string GetName()
        {
            return "aws";
        }

        public void UploadFile()
        {
            //Console.WriteLine("File uploaded to AWS");
        }
    }
}
