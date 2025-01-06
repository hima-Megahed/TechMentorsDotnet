namespace DoctorAvailability.Internal.Models;
internal class DoctorSlot
{
    public Guid Id { get; private set; }
    public DateTime Date { get; private set; }
    public Guid DoctorId { get; private set; }
    public string DoctorName { get; private set; } = string.Empty;
    public bool IsReserved { get; private set; }
    public decimal Cost { get; private set; }
    public static DoctorSlot Create(DateTime date, Guid doctorId, string doctorName, bool isReserved, decimal cost)
    {
        return new DoctorSlot
        {
            Id = Guid.NewGuid(),
            Date = date,
            DoctorId = doctorId,
            DoctorName = doctorName,
            IsReserved = isReserved,
            Cost = cost
        };
    }

}
