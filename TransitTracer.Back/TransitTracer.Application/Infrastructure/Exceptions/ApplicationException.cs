namespace TransitTracer.Application.Infrastructure.Exceptions;

public class ApplicationException : Exception
{
    public string Code { get; } = "422";
    public string Type { get; } = "ApplicationError";
    public new string Message { get; private set; }
    public ApplicationException(params string[] messages)
    {
        Message = string.Join(",", messages);
    }
}