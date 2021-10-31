using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rollcall.Sample
{
    public class DistinctHandler
    {
        public IGenericUploader<AWSUploader> _uploader { get; }

        public DistinctHandler(IGenericUploader<AWSUploader> uploader)
        {
            _uploader = uploader;
        }

        public void Execute()
        {
            _uploader.UploadFile();
        }

    }
}
