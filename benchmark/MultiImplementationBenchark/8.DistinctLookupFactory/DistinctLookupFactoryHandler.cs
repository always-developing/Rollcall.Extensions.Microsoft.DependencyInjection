namespace MultiImplementationBenchark
{
    public class DistinctLookupFactoryHandler
    {
        private readonly DistinctLookupFactory<IFileUploader> _distinctFactory;

        public DistinctLookupFactoryHandler(DistinctLookupFactory<IFileUploader> distinctFactory)
        {
            _distinctFactory = distinctFactory;
        }

        public void Execute()
        {
            _distinctFactory.Resolve("ftp").UploadFile();
        }

    }
}
