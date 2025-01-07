namespace Shared.Messaging.Events;
public record AddAppointmentIntegrationEvent : IntegrationEvent
{


    public Guid SlotId { get; set; } = default!;
    public DateTime Date { get; set; } = default!;
    public Guid DoctorId { get; set; } = default!;
    public string DoctorName { get; set; } = default!;
    public string PatientName { get; set; } = default!;


}
