using System.Net;

namespace SocalMedia.Business.Exceptions;

public class NotFoundException : Exception, IBaseException
{
    public NotFoundException(string message = "Not found") : base(message)
    {

    }

    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.Conflict;
}
