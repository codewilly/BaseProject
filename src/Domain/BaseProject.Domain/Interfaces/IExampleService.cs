namespace BaseProject.Domain.Interfaces
{
    public interface IExampleService
    {
        bool Create();

        string Get(bool throwEx, bool throwInvalid);
    }
}
