using DoctorAvailability.Internal;
using DoctorAvailability.Internal.Data;
using DoctorAvailability.Internal.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorAvailability.UnitTests;
public class DoctorSlotRepoTests
{
    private DbContextOptions<DoctorAvailabilityContext> GetInMemoryOptions()
    {
        return new DbContextOptionsBuilder<DoctorAvailabilityContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;
    }
    [Fact]
    public async Task GetMySlots_should_return_list_of_slots()
    {
        // Arrange
        var options = GetInMemoryOptions();
        var doctorId = Guid.NewGuid();
        var doctorName = "Doctor Name";
        var slots = new[]
        {
            DoctorSlot.Create(DateTime.Now, doctorId, doctorName, 10),
            DoctorSlot.Create(DateTime.Now.AddMinutes(15), doctorId, doctorName, 10),
            DoctorSlot.Create(DateTime.Now.AddMinutes(15), doctorId, doctorName, 100),

        };
        using (var context = new DoctorAvailabilityContext(options))
        {
            context.DoctorSlots.AddRange(slots);
            await context.SaveChangesAsync();
        }

        // Act
        using (var context = new DoctorAvailabilityContext(options))
        {
            var repository = new DoctorSlotRepo(context);
            var result = await repository.GetMySlots();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, slots.Count());
            Assert.Contains(slots, u => u.Cost == 10);
            Assert.Contains(slots, u => u.Cost == 100);
        }
    }

}
