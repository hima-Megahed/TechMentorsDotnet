namespace DoctorAvailability.Internal.Endpoints.AddSlot;
public record DoctorSlotRequestModel(DateTime Date, Guid DoctorId, string DoctorName, decimal Cost);

