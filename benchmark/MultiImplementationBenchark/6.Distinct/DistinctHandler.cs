namespace MultiImplementationBenchark
{
    public class DistinctHandler
    {
        public IGenericUploader<AWSUploader> _uploader { get; }

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
