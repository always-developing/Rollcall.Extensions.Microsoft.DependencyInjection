namespace MultiImplementationBenchark
{
    public class TypeDelegateHandler
    {
        private readonly TypeDelegateResolver _resolver;

        public TypeDelegateHandler(TypeDelegateResolver resovler)
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
