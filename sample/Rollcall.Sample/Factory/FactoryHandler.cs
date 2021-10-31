using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rollcall.Sample
{
    public  class FactoryHandler
    {
        public FileUploaderFactory _factory { get; }

        public FactoryHandler(FileUploaderFactory factory)
        {
            _factory = factory;
        }

        public void Execute()
        {
            var providerName = "azure";

            var uploader = _factory.GetFileUploader(providerName);
            uploader.UploadFile();
        }
    }
}
