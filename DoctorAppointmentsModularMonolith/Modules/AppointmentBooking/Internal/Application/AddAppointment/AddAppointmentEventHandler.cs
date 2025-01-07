using AppointmentBooking.Internal.Domain.Events;
using MassTransit;
using Shared.Messaging.Events;

namespace AppointmentBooking.Internal.Application.AddAppointment;
internal class AddAppointmentEventHandler(IBus bus)
    : INotificationHandler<AddAppointmentEvent>
{
    public async Task Handle(AddAppointmentEvent notification, CancellationToken cancellationToken)
    {

        var appointmentDetails = new AddAppointmentIntegrationEvent
        {
            SlotId = notification.Appointment.SlotId,
            DoctorName = notification.Slot.DoctorName,
            Date = notification.Slot.Date,
            PatientName = notification.Appointment.PatientName,
            DoctorId = notification.Slot.DoctorId
        };
        await bus.Publish(appointmentDetails, cancellationToken);

    }
}
