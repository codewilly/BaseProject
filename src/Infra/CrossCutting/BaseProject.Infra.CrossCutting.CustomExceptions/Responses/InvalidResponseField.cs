namespace BaseProject.Infra.CrossCutting.CustomExceptions.Responses
{
    public class InvalidResponseField
    {
        public InvalidResponseField(string key, string message)
        {
            Key = key;
            Message = message;
        }

        public string Key { get; set; }

        public string Message { get; set; }
    }
}
