

namespace DoctorAvailability.Internal.Services;
internal class AvailableSlotsService(DoctorSlotRepo repo) : IAvailableSlotsService
{
    public async Task<List<DoctorSlotDto>> GetAvailableSlots()
    {
        var slots = await repo.GetAvailableSlots();
        return slots.Adapt<List<DoctorSlotDto>>();
    }
}
