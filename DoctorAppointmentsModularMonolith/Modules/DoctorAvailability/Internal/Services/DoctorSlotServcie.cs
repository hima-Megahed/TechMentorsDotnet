using DoctorAvailability.Shared;

namespace DoctorAvailability.Internal.Services;
internal partial class DoctorSlotServcie(DoctorSlotRepo doctorSlotRepo)
{
    internal async Task<List<DoctorSlot>> GetMySlots()
    {
        return await doctorSlotRepo.GetMySlots();
    }
    internal async Task<Guid> AddSlot(DoctorSlotRequest doctorSlotRequest)
    {
        //validation

        var slot = DoctorSlot.Create(doctorSlotRequest.Date,
            doctorSlotRequest.DoctorId,
            doctorSlotRequest.DoctorName,
            doctorSlotRequest.Cost);

        return await doctorSlotRepo.AddSlot(slot);

    }
}
