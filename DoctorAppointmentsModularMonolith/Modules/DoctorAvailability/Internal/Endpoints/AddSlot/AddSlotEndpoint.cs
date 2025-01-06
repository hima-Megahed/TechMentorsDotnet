using Carter;
using DoctorAvailability1.Internal.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace DoctorAvailability1.Internal.Endpoints.AddSlot;
public class AddSlotEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/AddSlot", async (DoctorSlotRequestModel request, DoctorSlotService servcie) =>
        {
            return Results.Ok(await servcie.AddSlot(request));
        }).WithTags("DoctorAvailability");
    }
}
