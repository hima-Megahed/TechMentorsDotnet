using Carter;
using DoctorAvailability.Internal.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace DoctorAvailability.Internal.Endpoints.AddSlot;
internal class AddSlotEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/AddSlot", async (DoctorSlotRequestModel request, DoctorSlotService servcie) =>
        {
            var slot = new DoctorSlotAddDto(
                request.Date,
                request.DoctorId,
                request.DoctorName,
                request.Cost);
            return Results.Ok(await servcie.AddSlot(slot));
        }).WithTags("DoctorAvailability");
    }
}
