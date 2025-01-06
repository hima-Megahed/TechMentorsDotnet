namespace DoctorAvailability.Internal.Services;
internal class DoctorSlotServcie(DoctorSlotRepo doctorSlotRepo)
{
    public async Task<List<DoctorSlot>> GetMySlots()
    {
        return await doctorSlotRepo.GetMySlots();
    }
}
