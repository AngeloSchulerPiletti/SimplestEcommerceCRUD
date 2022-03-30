namespace SimplestEcommerceCRUD.Domain.Objects.VO
{
    public class ResponseVo
    {
        public ResponseVo(string title, string message, bool isError = true)
        {
            Title = title;
            Message = message;
            IsError = isError;
        }

        public string Title { get; }
        public string Message { get; }
        public bool IsError { get; }
    }
}
