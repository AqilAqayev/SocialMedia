using System.Net;

namespace SocalMedia.Business.Exceptions;

public class SignInException : Exception, IBaseException
{
    public SignInException(string message = "Not sign in") : base(message)
    {

    }
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.Conflict;

}
