using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rollcall.Sample
{
    public class EnumerableHandler
    {
        private readonly IEnumerable<IFileUploader> _uploaders;

        public EnumerableHandler(IEnumerable<IFileUploader> uploaders)
        {
            _uploaders = uploaders;
        }

        public void Execute()
        {
            var providerName = "aws";

            var uploader = _uploaders.FirstOrDefault(up => up.GetName().Equals(providerName));

            if (uploader == null)
            {
                throw new ArgumentException($"No uploader with name {providerName} could be found");
            }

            uploader.UploadFile();
        }
    }
}
