using Carter;
using DoctorAvailability.Internal.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace DoctorAvailability.Shared;
public class GetMySlotsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/MySlots", async (DoctorSlotServcie servcie) =>
        {

            return Results.Ok(await servcie.GetMySlots());
        }).WithTags("DoctorAvailability");
    }
}
