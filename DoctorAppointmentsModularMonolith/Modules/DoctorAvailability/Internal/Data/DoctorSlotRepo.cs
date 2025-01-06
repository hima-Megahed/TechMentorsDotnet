namespace DoctorAvailability.Internal.Data;
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
    internal async Task<List<DoctorSlot>> GetAvailableSlots()
    {
        return await context
             .DoctorSlots
             .AsNoTracking()
             .Where(s => !s.IsReserved)
             .ToListAsync();
    }
    internal async Task<DoctorSlot?> GetSlotsById(Guid id)
    {
        return await context
             .DoctorSlots
             .AsNoTracking()
             .FirstOrDefaultAsync(s => s.Id == id);
    }
}


