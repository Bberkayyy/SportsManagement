using System.Net;

namespace SportsManagement.Models;

public class ReturnModel<T>
{
    public T Data { get; set; }
    public string Message { get; set; }
    public HttpStatusCode StatusCode { get; set; }
}
