using DoctorAvailability.Internal.Endpoints.AddSlot;

namespace DoctorAvailability.Internal.Services;
internal class DoctorSlotService(DoctorSlotRepo doctorSlotRepo)
{
    internal async Task<List<DoctorSlot>> GetMySlots()
    {
        return await doctorSlotRepo.GetMySlots();
    }
    internal async Task<Guid> AddSlot(DoctorSlotRequestModel doctorSlotRequestModel)
    {
        var slot = DoctorSlot.Create(doctorSlotRequestModel.Date,
            doctorSlotRequestModel.DoctorId,
            doctorSlotRequestModel.DoctorName,
            doctorSlotRequestModel.Cost);

        return await doctorSlotRepo.AddSlot(slot);

    }
}
