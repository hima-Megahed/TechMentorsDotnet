using DoctorAvailability.Business.Repositories;
using DoctorAvailability.Business.Services.DoctorSlot.Models;
using DoctorAvailability.Shared.Models;

namespace DoctorAvailability.Business.Services.DoctorSlot;
public class DoctorSlotService(DoctorSlotRepo doctorSlotRepo)
{
    public async Task<List<Data.Models.DoctorSlot>> GetMySlots()
    {
        return await doctorSlotRepo.GetMySlots();
    }

    public async Task<List<Data.Models.DoctorSlot>> GetDoctorAvailableSlots()
    {
        return await doctorSlotRepo.GetDoctorAvailableSlots();
    }


    public async Task<Guid> AddSlot(DoctorSlotRequestModel doctorSlotRequestModel)
    {
        var slot = Data.Models.DoctorSlot.Create(doctorSlotRequestModel.Date,
            doctorSlotRequestModel.DoctorId,
            doctorSlotRequestModel.DoctorName,
            doctorSlotRequestModel.Cost);

        var slotId = await doctorSlotRepo.AddSlot(slot);
        await doctorSlotRepo.SaveChangesAsync();
        return slotId;
    }

    public async Task<SlotDto> ReserveSlot(Guid slotId)
    {
        var slot = await doctorSlotRepo.GetSlotById(slotId);
        if (slot is null)
            throw new Exception("Slot not found");

        if (slot.IsReserved)
            throw new Exception("Slot is already reserved");

        slot.Reserve();

        await doctorSlotRepo.SaveChangesAsync();
        return new SlotDto
        {
            Id = slot.Id,
            Date = slot.Date,
            DoctorId = slot.DoctorId,
            DoctorName = slot.DoctorName,
            Cost = slot.Cost
        };
    }
}
