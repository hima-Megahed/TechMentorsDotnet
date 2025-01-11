namespace DoctorAppointmentManagement.Internal.Core.Models;
internal class UpcomingAppointment
{
    public string Id { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string DoctorName { get; set; } = string.Empty;
    public string PatientName { get; set; } = string.Empty;

}

