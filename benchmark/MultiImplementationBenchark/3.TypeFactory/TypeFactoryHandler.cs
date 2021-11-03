namespace MultiImplementationBenchark
{
    public  class TypeFactoryHandler
    {
        private readonly FileUploaderTypeFactory _factory;

        public TypeFactoryHandler(FileUploaderTypeFactory factory)
        {
            _factory = factory;
        }

        public void Execute()
        {
            var providerName = "Azure";

            var uploader = _factory.Resolve(providerName);
            uploader.UploadFile();
        }
    }
}
