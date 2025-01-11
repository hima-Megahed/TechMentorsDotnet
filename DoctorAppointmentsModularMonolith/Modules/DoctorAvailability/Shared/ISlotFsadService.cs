namespace DoctorAvailability.Shared;
public interface ISlotFsadService
{
    Task<DoctorSlotDto?> GetSlotById(Guid id);
    Task<List<DoctorSlotDto>> GetAvailableSlots();
    Task<bool> ReserveSlot(Guid id);


}
