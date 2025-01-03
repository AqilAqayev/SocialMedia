namespace SocalMedia.Business.Exceptions;

public class SignInException : Exception
{
    public SignInException(string message = "Not sign in") : base(message)
    {

    }
}
