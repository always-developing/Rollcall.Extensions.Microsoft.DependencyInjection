namespace MultiImplementationBenchark
{
    public class DistinctFactoryHandler
    {
        private readonly DistinctFactory _distinctFactory;

        public DistinctFactoryHandler(DistinctFactory distinctFactory)
        {
            _distinctFactory = distinctFactory;
        }

        public void Execute()
        {
            _distinctFactory.Resolve("ftp").UploadFile();
        }

    }
}
