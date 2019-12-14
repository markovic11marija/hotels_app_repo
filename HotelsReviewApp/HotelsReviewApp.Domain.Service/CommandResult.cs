namespace HotelsReviewApp.Domain.Service
{
    public class CommandResult<T>
    {
        private CommandResult(T payload) => Payload = payload;
        private CommandResult(object reason) => FailureReason = reason;

        public T Payload { get; private set; }
        public object FailureReason { get; }
        public bool IsSuccess => FailureReason == null;
        public static CommandResult<T> Success(T payload) => new CommandResult<T>(payload);
        public static CommandResult<T> Fail(object reason) => new CommandResult<T>(reason);
        public static CommandResult<T> NotFound(object identifier = null) => Fail($"{typeof(T).Name} was not found.");
        public static implicit operator bool(CommandResult<T> result) => result.IsSuccess;
    }
}
