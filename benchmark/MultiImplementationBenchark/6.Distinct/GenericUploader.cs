namespace MultiImplementationBenchark
{
    public class GenericUploader<T> : IGenericUploader<T> where T : IFileUploader
    {
        private readonly T _implementation;

        public GenericUploader(T implementation)
        {
            _implementation = implementation;
        }

        public string GetName()
        {
            return _implementation.GetName();
        }

        public void UploadFile()
        {
            _implementation.UploadFile();
        }
    }
}
