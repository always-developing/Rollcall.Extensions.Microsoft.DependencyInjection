using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rollcall.Extensions.Microsoft.DependencyInjection;

namespace Rollcall.Sample
{
    public class RollcallHandler
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly IRollcallProvider _rollcall;

        public RollcallHandler(IServiceProvider serviceProvider, IRollcallProvider rollcall)
        {
            _serviceProvider = serviceProvider;
            _rollcall = rollcall;
        }

        public void Execute()
        {
            var providerName = "azure";

            var uploader = _serviceProvider.GetService<IFileUploader>(providerName);
            uploader.UploadFile();

            var uploader1 = _rollcall.GetService<IFileUploader>(providerName);
            uploader1.UploadFile();
        }
    }
}
