namespace MultiImplementationBenchark
{
    public  class FactoryHandler
    {
        private readonly FileUploaderFactory _factory;

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
