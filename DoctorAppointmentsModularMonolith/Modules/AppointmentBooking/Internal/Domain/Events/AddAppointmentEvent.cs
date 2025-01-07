using Shared.DDD;

namespace AppointmentBooking.Internal.Domain.Events;
internal record AddAppointmentEvent(Appointment Appointment) : IDomainEvent
{
}