namespace BaseProject.API.ViewModels
{
    public class ResultViewModel
    {
    }

    public class ResultViewModel<T> : ResultViewModel
    {
        public T Data { get; set; }
    }
}
