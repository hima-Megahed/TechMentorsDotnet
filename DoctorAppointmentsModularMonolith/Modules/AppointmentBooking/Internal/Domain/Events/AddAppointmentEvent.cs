using DoctorAvailability.Shared;
using Shared.DDD;

namespace AppointmentBooking.Internal.Domain.Events;
internal record AddAppointmentEvent(Appointment Appointment, DoctorSlotDto Slot) : IDomainEvent
{
}