namespace TransitTracer.Application.Infrastructure.Exceptions;

public class ObjectNotFoundException : ApplicationException
{
    public ObjectNotFoundException(string message) : base(message)
    {
        
    }
}