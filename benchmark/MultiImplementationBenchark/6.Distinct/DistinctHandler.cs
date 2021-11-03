namespace MultiImplementationBenchark
{
    public class DistinctHandler
    {
        private readonly IGenericUploader<AWSUploader> _uploader;

        public DistinctHandler(IGenericUploader<AWSUploader> uploader)
        {
            _uploader = uploader;
        }

        public void Execute()
        {
            _uploader.UploadFile();
        }

    }
}
