using DoctorAvailability.Business.Services.DoctorSlot.Models;
using DoctorAvailability.Shared.Models;

namespace DoctorAvailability.Business.Services.DoctorSlot;

public interface IDoctorSlotService
{
    Task<List<Data.Models.DoctorSlot>> GetMySlots();
    Task<List<Data.Models.DoctorSlot>> GetDoctorAvailableSlots();
    Task<Guid> AddSlot(DoctorSlotRequestModel doctorSlotRequestModel);
    Task<SlotDto> ReserveSlot(Guid slotId);
}