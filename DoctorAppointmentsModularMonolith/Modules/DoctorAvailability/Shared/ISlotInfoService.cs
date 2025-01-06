namespace DoctorAvailability.Shared;
public interface ISlotInfoService
{
    Task<DoctorSlotDto?> GetSlotById(Guid id);

}
