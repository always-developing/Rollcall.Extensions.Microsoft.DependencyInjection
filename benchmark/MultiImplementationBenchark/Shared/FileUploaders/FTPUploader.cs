namespace MultiImplementationBenchark
{
    public class FTPUploader : IFileUploader
    {
        public FTPUploader()
        {
#if DEBUG
            Console.WriteLine($"{this.GetType().Name} initialized");
#endif
        }

        public string GetName()
        {
            return "ftp";
        }

        public void UploadFile()
        {
#if DEBUG
            Console.WriteLine("File uploaded to FTP");
#endif
        }
    }
}
