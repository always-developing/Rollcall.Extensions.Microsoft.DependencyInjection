using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rollcall.Sample
{
    public interface IFileUploader
    {
        string GetName();

        void UploadFile();
    }
}
