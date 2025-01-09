namespace DoctorAvailability.Internal;
internal class DoctorSlotRepo(DoctorAvailabilityContext context) : IDoctorSlotRepo
{
    public async Task<List<DoctorSlotDto>> GetMySlots()
    {
        return await context
            .DoctorSlots
            .AsNoTracking()
            .Select(e => new DoctorSlotDto(e.Date, e.DoctorId, e.DoctorName, e.Cost, e.Id))
            .ToListAsync();

    }

    public async Task<Guid> AddSlot(DoctorSlotDto slotDto)
    {
        var slot = DoctorSlot.Create(slotDto.Date, slotDto.DoctorId, slotDto.DoctorName, slotDto.Cost);
        context.DoctorSlots.Add(slot);
        await context.SaveChangesAsync();
        return slot.Id;
    }
    public async Task<List<DoctorSlotDto>> GetAvailableSlots()
    {
        return await context
             .DoctorSlots
             .AsNoTracking()
             .Where(s => !s.IsReserved)
             .Select(e => new DoctorSlotDto(e.Date, e.DoctorId, e.DoctorName, e.Cost, e.Id))
             .ToListAsync();
    }
    public async Task<DoctorSlotDto?> GetSlotsById(Guid id)
    {
        return await context
             .DoctorSlots
             .AsNoTracking()
             .Select(e => new DoctorSlotDto(e.Date, e.DoctorId, e.DoctorName, e.Cost, e.Id))
             .FirstOrDefaultAsync(s => s.Id == id);
    }

}


