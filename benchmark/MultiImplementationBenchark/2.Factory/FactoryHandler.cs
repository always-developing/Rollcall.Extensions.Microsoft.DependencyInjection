namespace MultiImplementationBenchark
{
    public  class FactoryHandler
    {
        public FileUploaderFactory _factory { get; }

        public FactoryHandler(FileUploaderFactory factory)
        {
            _factory = factory;
        }

        public void Execute()
        {
            var providerName = "azure";

            var uploader = _factory.Resolve(providerName);
            uploader.UploadFile();
        }
    }
}
