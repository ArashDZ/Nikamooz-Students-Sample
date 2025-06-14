namespace SampleApp.Core.Contracts.Common.Exceptions
{
    public class BadRequestException : SampleAppException
    {
        public override int StatusCode => 400;
        public BadRequestException() : base() { }
        public BadRequestException(string message) : base(message) { }
        public BadRequestException(string message, Exception exception) : base(message, exception) { }

    }
}
