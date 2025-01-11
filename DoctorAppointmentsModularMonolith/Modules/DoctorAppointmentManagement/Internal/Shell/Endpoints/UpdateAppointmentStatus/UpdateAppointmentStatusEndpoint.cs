
using AppointmentBooking.Shared;

namespace DoctorAppointmentManagement.Internal.Shell.Endpoints.UpdateAppointmentStatus;
internal class UpdateAppointmentStatusEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/UpdateAppointmentStatus", async (UpdateAppointmentStatusRequest request, IUpdateAppointmentStatusService servcie) =>
        {
            return Results.Ok(await servcie.UpdateAppointmentStatus(request.Status, request.Id));
        }).WithTags("DoctorAppointmentManagement");
    }
}
