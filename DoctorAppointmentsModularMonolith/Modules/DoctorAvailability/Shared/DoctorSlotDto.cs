namespace DoctorAvailability.Shared;

public record DoctorSlotAddDto(DateTime Date, Guid DoctorId, string DoctorName, decimal Cost);
public record DoctorSlotDto(DateTime Date, Guid DoctorId, string DoctorName, decimal Cost, bool IsReserved, Guid Id);