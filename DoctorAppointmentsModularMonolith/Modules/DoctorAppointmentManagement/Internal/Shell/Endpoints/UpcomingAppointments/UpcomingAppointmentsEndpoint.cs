using Carter;
using DoctorAppointmentManagement.Internal.Core.Ports.Data.Repos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace DoctorAppointmentManagement.Internal.Shell.Endpoints.UpcomingAppointments;
internal class UpcomingAppointmentsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/UpcomingAppointments", async (IUpcomingAppointmentsService servcie) =>
        {
            return Results.Ok(await servcie.GetUpcomingAppointments());
        }).WithTags("DoctorAppointmentManagement");
    }
}
