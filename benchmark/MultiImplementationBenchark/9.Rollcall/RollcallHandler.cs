using Rollcall.Extensions.Microsoft.DependencyInjection;

namespace MultiImplementationBenchark
{
    public class RollcallHandler
    {
        private readonly IRollcallProvider<IFileUploader> _provider;

        public RollcallHandler(IRollcallProvider<IFileUploader> provider)
        {
            _provider = provider;
        }

        public void Execute()
        {
            var providerName = "aws";

            var uploader = _provider.GetService(providerName);
            uploader.UploadFile();
        }
    }
}
