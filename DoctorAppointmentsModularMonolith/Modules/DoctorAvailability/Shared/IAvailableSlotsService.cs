namespace DoctorAvailability.Shared;
public interface IAvailableSlotsService
{
    Task<List<DoctorSlotDto>> GetAvailableSlots();
}
