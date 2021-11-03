using Rollcall.Extensions.Microsoft.DependencyInjection;

namespace MultiImplementationBenchark
{
    public class RollcallFuncHandler
    {
        private readonly IRollcallProvider<IFileUploader> _provider;

        public RollcallFuncHandler(IRollcallProvider<IFileUploader> provider)
        {
            _provider = provider;
        }

        public void Execute()
        {
            var providerName = "azure";

            var uploader = _provider.GetService(providerName);
            uploader.UploadFile();
        }
    }
}
