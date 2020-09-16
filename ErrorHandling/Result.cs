namespace DiscordAndDragons.ErrorHandling
{
    public enum ResultType
    {
        Unknown,
        Success,
        NotFound,
        NotParsable
    }

    public class Result
    {
        private ResultType success;
        public bool IsSuccess => Type == ResultType.Success;
        public bool IsFailure => Type != ResultType.Success;

        public Result(ResultType success)
        {
            this.success = success;
        }

        public ResultType Type { get; }
        public string UserMessage { get; }
    }

    public class Result<T> : Result
    {
        private readonly T _content;
        private string userMessage;

        public T Content
        {
            get
            {
                return _content;
            }
        }

        private Result(T content) : base(ResultType.Success)
        {
            _content = content;
        }

        public static Result<T> From(T result)
        {
            return new Result<T>(result);
        }

        public Result(ResultType success, string userMessage) : base(success)
        {
            this.userMessage = userMessage;
        }

        public new static Result<T> NotFound(string userMessage)
        {
            return new Result<T>(ResultType.NotFound, userMessage);
        }

        public new static Result<T> NotParsable(string userMessage)
        {
            Forms.Helpers.CreateMessageBox(userMessage);
            return new Result<T>(ResultType.NotParsable, userMessage);
        }
    }
}
