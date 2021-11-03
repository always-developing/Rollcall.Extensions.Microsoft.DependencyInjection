using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiImplementationBenchark
{
    public class FileUploaderFactory
    {
        private readonly IEnumerable<IFileUploader> _uploaders;

        public FileUploaderFactory(IEnumerable<IFileUploader> uploaders)
        {
            _uploaders = uploaders; 
        }

        public IFileUploader Resolve(string providerName)
        {
            var uploader = _uploaders.FirstOrDefault(up => up.GetName().Equals(providerName));

            if (uploader == null)
            {
                throw new ArgumentException($"No uploader with name {providerName} could be found");
            }

            return uploader;
        }
    }
}
