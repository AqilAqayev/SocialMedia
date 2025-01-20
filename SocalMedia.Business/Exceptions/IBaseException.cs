using System.Net;

namespace SocalMedia.Business.Exceptions;

public interface IBaseException
{
    public HttpStatusCode StatusCode { get; set; }
}