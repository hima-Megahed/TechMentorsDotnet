namespace DoctorAvailability.Internal.Data;
internal class DoctorSlotRepo(DoctorAvailabilityContext context) : IDoctorSlotRepo
{
    public async Task<List<DoctorSlotDto>> GetMySlots()
    {
        return await context
            .DoctorSlots
            .AsNoTracking()
            .Select(e => new DoctorSlotDto(e.Date, e.DoctorId, e.DoctorName, e.Cost, e.IsReserved, e.Id))
            .ToListAsync();

    }

    public async Task<Guid> AddSlot(DoctorSlotAddDto slotDto)
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
             .Select(e => new DoctorSlotDto(e.Date, e.DoctorId, e.DoctorName, e.Cost, e.IsReserved, e.Id))
             .ToListAsync();
    }
    public async Task<DoctorSlotDto?> GetSlotsById(Guid id)
    {
        var slots = await context
             .DoctorSlots
             .AsNoTracking()
             .Where(e => e.Id == id)
             .Select(e => new DoctorSlotDto(e.Date, e.DoctorId, e.DoctorName, e.Cost, e.IsReserved, e.Id))
             .ToListAsync();
        return slots?.FirstOrDefault();
    }

    public async Task<bool> ReserveSlot(Guid id)
    {
        var slot = await context
            .DoctorSlots
            .FirstOrDefaultAsync(s => s.Id == id);
        slot?.Reserve();
        await context.SaveChangesAsync();
        return true;
    }
}


