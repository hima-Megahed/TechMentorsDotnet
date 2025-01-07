using AppointmentBooking.Internal.Domain.Events;
using DoctorAvailability.Shared;

namespace AppointmentBooking.Internal.Application.AddAppointment;
internal class AddAppointmentEventHandler(ISlotInfoService slotInfoService)
    : INotificationHandler<AddAppointmentEvent>
{
    public async Task Handle(AddAppointmentEvent notification, CancellationToken cancellationToken)
    {
        var slot = await slotInfoService.GetSlotById(notification.Appointment.SlotId);
    }
}
