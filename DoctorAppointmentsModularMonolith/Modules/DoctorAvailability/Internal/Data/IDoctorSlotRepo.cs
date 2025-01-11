namespace DoctorAvailability.Internal.Data;

public interface IDoctorSlotRepo
{
    Task<List<DoctorSlotDto>> GetMySlots();
    Task<Guid> AddSlot(DoctorSlotAddDto slot);
    Task<List<DoctorSlotDto>> GetAvailableSlots();
    Task<DoctorSlotDto?> GetSlotsById(Guid id);
    Task<bool> ReserveSlot(Guid id);

}


