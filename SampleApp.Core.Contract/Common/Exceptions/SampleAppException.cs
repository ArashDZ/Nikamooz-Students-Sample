namespace SampleApp.Core.Contracts.Common.Exceptions
{
    public abstract class SampleAppException : Exception
    {
        public SampleAppException() : base() { }
        public SampleAppException(string message) : base(message) { }
        public SampleAppException(string message, Exception exception) : base(message, exception) { }
        public abstract int StatusCode { get; }
    }
}
