namespace DoctorAvailability.Internal.Data;

public interface IDoctorSlotRepo
{
    Task<List<DoctorSlotDto>> GetMySlots();
    Task<Guid> AddSlot(DoctorSlotDto slot);
    Task<List<DoctorSlotDto>> GetAvailableSlots();
    Task<DoctorSlotDto?> GetSlotsById(Guid id);
}


