namespace DoctorAvailability.Internal.Services;
internal class DoctorSlotService(IDoctorSlotRepo doctorSlotRepo)
{
    internal async Task<List<DoctorSlotDto>> GetMySlots()
    {
        return await doctorSlotRepo.GetMySlots();
    }
    internal async Task<Guid> AddSlot(DoctorSlotAddDto slotDto)
    {
        return await doctorSlotRepo.AddSlot(slotDto);
    }
}
