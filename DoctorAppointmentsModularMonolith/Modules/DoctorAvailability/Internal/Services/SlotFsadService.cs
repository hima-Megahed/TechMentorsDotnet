using Shared.Exceptions;
namespace DoctorAvailability.Internal.Services;
internal class SlotFsadService(IDoctorSlotRepo repo) : ISlotFsadService
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
    public async Task<List<DoctorSlotDto>> GetAvailableSlots()
    {
        var slots = await repo.GetAvailableSlots();
        return slots.Adapt<List<DoctorSlotDto>>();
    }

    public async Task<bool> ReserveSlot(Guid id)
    {
        var slot = await repo.GetSlotsById(id);
        if (slot is null)
        {
            throw new NotFoundException("Slot not found");
        }
        if (slot.IsReserved)
        {
            throw new BadRequestException("Slot is already reserved");
        }

        return await repo.ReserveSlot(id);
    }
}
