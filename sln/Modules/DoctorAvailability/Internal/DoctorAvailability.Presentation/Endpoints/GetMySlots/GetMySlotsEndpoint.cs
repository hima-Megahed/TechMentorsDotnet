using Carter;
using DoctorAvailability.Internal.Business.Services.DoctorSlot;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace DoctorAvailability.Internal.Presentation.Endpoints.GetMySlots;
public class GetMySlotsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/MySlots", async (IDoctorSlotService service) =>
        {
            return Results.Ok(await service.GetMySlots());
        }).WithTags("DoctorAvailability");
    }
}
