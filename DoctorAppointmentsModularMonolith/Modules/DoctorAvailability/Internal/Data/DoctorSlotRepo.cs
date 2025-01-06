using DoctorAvailability1.Internal.Models;

namespace DoctorAvailability1.Internal.Data;
internal class DoctorSlotRepo(DoctorAvailabilityContext context)
{
    internal async Task<List<DoctorSlot>> GetMySlots()
    {
        return await context
            .DoctorSlots
            .AsNoTracking()
            .ToListAsync();
    }

    internal async Task<Guid> AddSlot(DoctorSlot slot)
    {
        context.DoctorSlots.Add(slot);
        await context.SaveChangesAsync();
        return slot.Id;
    }
}


