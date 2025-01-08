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
