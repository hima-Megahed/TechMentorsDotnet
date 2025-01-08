using DoctorAppointmentManagement.Internal.Core.Models;
using DoctorAppointmentManagement.Internal.Core.Ports.Data.Repos;
using DoctorAppointmentManagement.Internal.Core.Ports.Repos;

namespace DoctorAppointmentManagement.Internal.Core.Services;
internal class UpcomingAppointmentsService(IUpcomingAppointmentsRepo upcomingAppointmentsRepo) : IUpcomingAppointmentsService
{
    public async Task<List<UpcomingAppointment>> GetUpcomingAppointments()
    {
        return await upcomingAppointmentsRepo.GetUpcomingAppointments();

    }
}
