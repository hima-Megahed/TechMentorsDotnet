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


}


