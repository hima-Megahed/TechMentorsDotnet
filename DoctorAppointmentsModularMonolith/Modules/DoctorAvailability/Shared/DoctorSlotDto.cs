namespace DoctorAvailability.Shared;

public record DoctorSlotDto(DateTime Date, Guid DoctorId, string DoctorName, decimal Cost, Guid Id = default);