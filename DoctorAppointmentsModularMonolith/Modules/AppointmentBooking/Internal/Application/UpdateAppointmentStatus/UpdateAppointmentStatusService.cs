using AppointmentBooking.Shared;
using Shared.Exceptions;

namespace AppointmentBooking.Internal.Application.AddAppointment;

internal class UpdateAppointmentStatusService(AppointmentBookingContext appointmentBookingContext) : IUpdateAppointmentStatusService
{
    public async Task<bool> UpdateAppointmentStatus(BookingStatus status, Guid id)
    {
        var appointment = await appointmentBookingContext.Appointments.FirstOrDefaultAsync(x => x.Id == id);
        if (appointment is null)
        {
            throw new NotFoundException("Appointment not found");

        }
        appointment?.SetStatus(status);
        await appointmentBookingContext.SaveChangesAsync();
        return true;
    }
}