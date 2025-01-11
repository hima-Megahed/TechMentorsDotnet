using DoctorAppointmentManagement.Internal.Core.Models;

namespace DoctorAppointmentManagement.Internal.Core.Ports.Data.Repos;
internal interface IUpcomingAppointmentsService
{
    Task<List<UpcomingAppointment>> GetUpcomingAppointments();
}
