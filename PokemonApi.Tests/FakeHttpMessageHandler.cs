using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

public class FakeHttpMessageHandler : HttpMessageHandler
{
    private readonly HttpResponseMessage _responseMessage;

    public FakeHttpMessageHandler(HttpResponseMessage responseMessage)
    {
        _responseMessage = responseMessage;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_responseMessage);
    }
}
