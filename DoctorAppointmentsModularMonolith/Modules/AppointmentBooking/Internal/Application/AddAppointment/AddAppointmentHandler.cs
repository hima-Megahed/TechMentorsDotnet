using DoctorAvailability.Shared;

namespace AppointmentBooking.Internal.Application.AddAppointment;

internal class AddAppointmentHandler(AppointmentBookingContext appointmentBookingContext, ISlotFsadService slotService) : IRequestHandler<AddAppointmentCommand, Guid?>
{
    public async Task<Guid?> Handle(AddAppointmentCommand command, CancellationToken cancellationToken)
    {
        //validation

        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }
        var slot = await slotService.GetSlotById(command.SlotId);
        if (await slotService.ReserveSlot(command.SlotId))
        {
            var appointment = Appointment.Create(command.SlotId, command.PatientId, command.PatientName, slot!);
            appointmentBookingContext.Appointments.Add(appointment);
            await appointmentBookingContext.SaveChangesAsync();
            return appointment.Id;
        }
        return null;

    }
}
