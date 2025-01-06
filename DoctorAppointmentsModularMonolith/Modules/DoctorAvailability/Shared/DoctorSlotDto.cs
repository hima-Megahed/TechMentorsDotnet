namespace DoctorAvailability.Shared;

public record DoctorSlotDto(Guid Id, DateTime Date, Guid DoctorId, string DoctorName, decimal Cost);