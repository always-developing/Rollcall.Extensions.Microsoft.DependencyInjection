namespace MultiImplementationBenchark
{

    public interface IGenericUploader<T> : IFileUploader where T : IFileUploader
    {

    }
}
