using DoctorAppointmentManagement.Internal.Core.Models;

namespace DoctorAppointmentManagement.Internal.Core.Ports.Repos;
internal interface IUpcomingAppointmentsRepo
{
    Task<List<UpcomingAppointment>> GetUpcomingAppointments();
}
