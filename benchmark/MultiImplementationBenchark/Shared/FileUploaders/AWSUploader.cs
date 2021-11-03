namespace MultiImplementationBenchark
{
    public class AWSUploader : IFileUploader
    {
        public AWSUploader()
        {
#if DEBUG
            Console.WriteLine($"{this.GetType().Name} initialized");
#endif
        }

        public string GetName()
        {
            return "aws";
        }

        public void UploadFile()
        {
#if DEBUG
            Console.WriteLine("File uploaded to AWS");
#endif
        }
    }
}
