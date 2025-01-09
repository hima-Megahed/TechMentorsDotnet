using DoctorAvailability.Internal.Data;
using DoctorAvailability.Internal.Models;
using DoctorAvailability.Shared;
using Microsoft.EntityFrameworkCore;

namespace DoctorAvailability.UnitTests;
public class DoctorSlotRepoTests
{
    private DbContextOptions<DoctorAvailabilityContext> GetInMemoryOptions(string dbname)
    {
        return new DbContextOptionsBuilder<DoctorAvailabilityContext>()
            .UseInMemoryDatabase(databaseName: dbname)
            .Options;
    }
    [Fact]
    public async Task GetMySlots_should_return_list_of_slots()
    {
        // Arrange
        var options = GetInMemoryOptions("testList");
        var doctorId = Guid.NewGuid();
        string doctorName = "Doctor Name";
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
            Assert.Equal(3, result.Count());
            Assert.Contains(result, u => u.Cost == 10);
            Assert.Contains(result, u => u.Cost == 100);
        }
    }

    [Fact]
    public async Task GetMySlots_should_return_empty_list()
    {
        // Arrange
        var options = GetInMemoryOptions("testEmpty");

        // Act
        using (var context = new DoctorAvailabilityContext(options))
        {

            var repository = new DoctorSlotRepo(context);
            var result = await repository.GetMySlots();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);

        }
    }
    [Fact]
    public async Task AddSlot_should_return_slot_id()
    {
        // Arrange
        var options = GetInMemoryOptions("testAdd");
        var doctorId = Guid.NewGuid();
        string doctorName = "Doctor Name";
        var slot = new DoctorSlotDto(DateTime.Now, doctorId, doctorName, 10);
        // Act
        using (var context = new DoctorAvailabilityContext(options))
        {

            var repository = new DoctorSlotRepo(context);
            var result = await repository.AddSlot(slot);
            // Assert
            Assert.NotEqual(Guid.Empty, result);
        }
    }

}
