using Shared.Exceptions;
namespace DoctorAvailability.Internal.Services;
internal class SlotInfoService(IDoctorSlotRepo repo) : ISlotInfoService
{
    public async Task<DoctorSlotDto?> GetSlotById(Guid id)
    {
        var slot = await repo.GetSlotsById(id);
        if (slot is null)
        {
            throw new NotFoundException("Slot not found");
        }
        return slot.Adapt<DoctorSlotDto>();
    }

}
