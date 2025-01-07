namespace DoctorAvailability.Internal.Endpoints.AddSlot;
internal record DoctorSlotRequestModel(DateTime Date, Guid DoctorId, string DoctorName, decimal Cost);

