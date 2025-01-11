

namespace DoctorAvailability.Internal.Services;
internal class AvailableSlotsService(IDoctorSlotRepo repo) : IAvailableSlotsService
{
    public async Task<List<DoctorSlotDto>> GetAvailableSlots()
    {
        var slots = await repo.GetAvailableSlots();
        return slots.Adapt<List<DoctorSlotDto>>();
    }
}
