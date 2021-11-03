namespace MultiImplementationBenchark
{
    public class DelegateHandler
    {
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
