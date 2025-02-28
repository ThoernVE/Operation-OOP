namespace OperationOOP.Api.Endpoints;

public interface IEndpoint //iendpoint interface for abstraction of endpoints
{
    public static abstract void MapEndpoint(IEndpointRouteBuilder app);
}
