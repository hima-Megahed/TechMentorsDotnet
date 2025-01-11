namespace AppointmentBooking.Shared;
public interface IUpdateAppointmentStatusService
{
    Task<bool> UpdateAppointmentStatus(BookingStatus status, Guid id);
}
