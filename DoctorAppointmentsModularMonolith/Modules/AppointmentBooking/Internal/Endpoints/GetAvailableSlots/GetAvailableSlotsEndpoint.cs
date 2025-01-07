

using AppointmentBooking.Internal.Application.GetAvailableSlots;

namespace AppointmentBooking.Internal.Endpoints.GetAvailableSlots;
internal class GetAvailableSlotsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/GetAvailableSlots", async (ISender sender) =>
        {
            return Results.Ok(await sender.Send(new GetAvailableSlotsQuery()));

        }).WithTags("AppointmentBooking");
    }
}
