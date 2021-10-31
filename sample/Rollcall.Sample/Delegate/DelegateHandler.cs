using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rollcall.Sample
{
    public class DelegateHandler
    {
        //https://www.infoworld.com/article/3597989/use-multiple-implementations-of-an-interface-in-aspnet-core.html

        private readonly DelegateResolver _resolver;

        public DelegateHandler(DelegateResolver resovler)
        {
            _resolver = resovler;
        }

        public void Execute()
        {
            var uploader = _resolver("ftp");
            uploader.UploadFile();
        }

    }
}
