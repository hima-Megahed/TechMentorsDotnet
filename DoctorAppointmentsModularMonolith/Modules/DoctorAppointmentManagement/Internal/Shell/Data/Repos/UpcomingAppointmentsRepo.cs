using Dapper;
using DoctorAppointmentManagement.Internal.Core.Models;
using DoctorAppointmentManagement.Internal.Core.Ports.Repos;

namespace DoctorAppointmentManagement.Internal.Shell.Data.Repos;
internal class UpcomingAppointmentsRepo(DapperContext _context) : IUpcomingAppointmentsRepo
{

    public async Task<List<UpcomingAppointment>> GetUpcomingAppointments()
    {


        var query = @$"SELECT a.Id,s.Date,s.DoctorName,a.PatientName
                      FROM DoctorSlots s INNER JOIN Appointments a on s.Id= a.SlotId 
                      where a.Status=0 and s.Date > @CurrentDate";
        using var connection = _context.CreateConnection();
        var upcomingAppointments = connection.Query<UpcomingAppointment>(query, new { CurrentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:00") });
        return upcomingAppointments.ToList();
    }
}

