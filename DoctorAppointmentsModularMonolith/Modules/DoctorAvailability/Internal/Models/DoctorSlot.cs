using Shared.DDD;

namespace DoctorAvailability.Internal.Models;
internal class DoctorSlot : Entity<Guid>
{

    public DateTime Date { get; private set; }
    public Guid DoctorId { get; private set; }

    public string DoctorName { get; private set; } = string.Empty;
    public bool IsReserved { get; private set; }
    public decimal Cost { get; private set; }
    private DoctorSlot() { }
    public static DoctorSlot Create(DateTime date, Guid doctorId, string doctorName, decimal cost)
    {
        if (date == default)
        {
            throw new ArgumentException("Date is required", nameof(date));
        }
        if (doctorId == default)
        {
            throw new ArgumentException("DoctorId is required", nameof(doctorId));
        }


        ArgumentException.ThrowIfNullOrWhiteSpace(doctorName, nameof(doctorName));


        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(cost, 0, nameof(cost));
        return new DoctorSlot
        {
            Id = Guid.NewGuid(),
            Date = date,
            DoctorId = doctorId,
            DoctorName = doctorName,
            Cost = cost
        };
    }

}
