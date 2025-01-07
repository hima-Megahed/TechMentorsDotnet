using AppointmentBooking.Internal.Domain.Events;
using DoctorAvailability.Shared;
using MassTransit;
using Shared.Messaging.Events;

namespace AppointmentBooking.Internal.Application.AddAppointment;
internal class AddAppointmentEventHandler(ISlotInfoService slotInfoService, IBus bus)
    : INotificationHandler<AddAppointmentEvent>
{
    public async Task Handle(AddAppointmentEvent notification, CancellationToken cancellationToken)
    {
        var slot = await slotInfoService.GetSlotById(notification.Appointment.SlotId);
        if (slot is not null)
        {
            var appointmentDetails = new AddAppointmentIntegrationEvent
            {
                SlotId = notification.Appointment.SlotId,
                DoctorName = slot.DoctorName,
                Date = slot.Date,
                PatientName = notification.Appointment.PatientName,
                DoctorId = slot.DoctorId
            };
            await bus.Publish(appointmentDetails, cancellationToken);
        }
    }
}
