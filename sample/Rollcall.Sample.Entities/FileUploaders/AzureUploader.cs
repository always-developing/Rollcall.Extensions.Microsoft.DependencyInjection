using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rollcall.Sample
{
    public  class AzureUploader : IFileUploader
    {
        public AzureUploader()
        {
            //Console.WriteLine($"{this.GetType().Name} initialized");
        }

        public string GetName()
        {
            return "azure";
        }

        public void UploadFile()
        {
           // Console.WriteLine("...File uploaded to Azure...");
        }
    }
}
