namespace MultiImplementationBenchark
{
    public class AzureUploader : IFileUploader
    {
        public AzureUploader()
        {
#if DEBUG
            Console.WriteLine($"{this.GetType().Name} initialized");
#endif
        }

        public string GetName()
        {
            return "azure";
        }

        public void UploadFile()
        {
#if DEBUG
            Console.WriteLine("...File uploaded to Azure...");
#endif
        }
    }
}
