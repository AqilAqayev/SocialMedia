namespace SocalMedia.Business.Exceptions;

public class NullException : Exception
{
    public NullException(string message = "null exception") : base(message)
    {

    }
}
