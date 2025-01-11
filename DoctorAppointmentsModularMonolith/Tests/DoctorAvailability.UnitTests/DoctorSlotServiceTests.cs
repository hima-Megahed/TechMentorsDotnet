using DoctorAvailability.Internal;
using DoctorAvailability.Internal.Services;
using DoctorAvailability.Shared;
using Moq;


namespace DoctorAvailability.UnitTests;
public class DoctorSlotServiceTests
{
    private readonly Mock<IDoctorSlotRepo> _mockRepository;
    private readonly DoctorSlotService _doctorSlotService;
    public DoctorSlotServiceTests()
    {
        _mockRepository = new Mock<IDoctorSlotRepo>();
        _doctorSlotService = new DoctorSlotService(_mockRepository.Object);
    }
    [Fact]
    public async Task GetMySlots_should_return_list_of_slots()
    {
        // Arrange
        var doctorId = Guid.NewGuid();
        var doctorName = "Doctor Name";

        var slots = new List<DoctorSlotDto>
        {

            new DoctorSlotDto( DateTime.Now, doctorId, doctorName, 10,false,Guid.NewGuid()),
            new DoctorSlotDto(DateTime.Now.AddMinutes(15), doctorId, doctorName, 10,false,Guid.NewGuid()),


        };
        _mockRepository.Setup(x => x.GetMySlots()).ReturnsAsync(slots);
        // Act
        var result = await _doctorSlotService.GetMySlots();
        // Assert
        Assert.Equal(slots, result);
    }
    [Fact]
    public async Task AddSlot_should_return_slot_id()
    {
        // Arrange
        var doctorId = Guid.NewGuid();
        var doctorName = "Doctor Name";
        var slot = new DoctorSlotAddDto(DateTime.Now, doctorId, doctorName, 10);
        var slotId = Guid.NewGuid();
        _mockRepository.Setup(x => x.AddSlot(slot)).ReturnsAsync(slotId);
        // Act
        var result = await _doctorSlotService.AddSlot(slot);
        // Assert
        Assert.Equal(slotId, result);
    }
}
