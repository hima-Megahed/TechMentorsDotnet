using AppointmentBooking.Internal.Domain.Events;
using DoctorAvailability.Shared;
using Shared.DDD;

namespace AppointmentBooking.Internal.Domain;
internal class Appointment : Aggregate<Guid>
{
    public Guid SlotId { get; private set; }
    public Guid PatientId { get; private set; }
    public string PatientName { get; private set; } = string.Empty;
    public DateOnly ReservedAt { get; private set; }
    public BookingStatus Status { get; private set; }
    private Appointment() { }
    public static Appointment Create(Guid slotId, Guid patientId, string patientName, DoctorSlotDto slot)
    {

        if (slotId == default)
        {
            throw new ArgumentException("slotId is required", nameof(slotId));
        }
        if (patientId == default)
        {
            throw new ArgumentException("PatientId is required", nameof(slotId));
        }
        ArgumentException.ThrowIfNullOrWhiteSpace(patientName, nameof(patientName));

        var appointment = new Appointment
        {
            Id = Guid.NewGuid(),
            SlotId = slotId,
            PatientId = patientId,
            PatientName = patientName,
            ReservedAt = DateOnly.FromDateTime(DateTime.UtcNow),
            Status = BookingStatus.Pending


        };
        appointment.AddDomainEvent(new AddAppointmentEvent(appointment, slot));
        return appointment;

    }
    public void SetStatus(BookingStatus status)
    {
        Status = status;
    }
}
