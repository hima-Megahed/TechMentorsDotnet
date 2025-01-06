namespace DoctorAvailability.Shared;
public record DoctorSlotRequest(DateTime Date, Guid DoctorId, string DoctorName, decimal Cost);

