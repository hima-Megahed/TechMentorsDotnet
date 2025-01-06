using Shared.Exceptions;
namespace DoctorAvailability.Internal.Services;
internal class SlotInfoService(DoctorSlotRepo repo) : ISlotInfoService
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
