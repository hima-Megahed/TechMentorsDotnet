namespace DoctorAvailability.Shared;
public interface ISlotFacadeService
{
    Task<DoctorSlotDto?> GetSlotById(Guid id);
    Task<List<DoctorSlotDto>> GetAvailableSlots();
    Task<bool> ReserveSlot(Guid id);


}
