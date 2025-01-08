using AppointmentBooking.Internal.Application.AddAppointment;
using Mapster;

namespace AppointmentBooking.Internal.Endpoints.AddAppointment;

internal class AddAppointmentEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/AddAppointment", async (AddAppointmentRequest request, ISender sender) =>
        {
            var cmd = request.Adapt<AddAppointmentCommand>();
            return Results.Ok(await sender.Send(cmd));
        }).WithTags("AppointmentBooking");
    }
}
