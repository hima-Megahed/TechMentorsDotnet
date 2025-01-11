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
        var slot = new DoctorSlotAddDto(DateTime.Now, doctorId, doctorName, 10);
        // Act
        using (var context = new DoctorAvailabilityContext(options))
        {

            var repository = new DoctorSlotRepo(context);
            var result = await repository.AddSlot(slot);
            // Assert
            Assert.NotEqual(Guid.Empty, result);
        }
    }

    //GetAvailableSlots
    [Fact]
    public async Task GetAvailableSlots_ReturnsAllAvailableSlots()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DoctorAvailabilityContext>()
            .UseInMemoryDatabase(databaseName: "AvailableSlotsTestDB")
        .Options;

        using (var context = new DoctorAvailabilityContext(options))
        {
            var slot1 = DoctorSlot.Create(DateTime.Now, Guid.NewGuid(), "Doctor Name 1 ", 100);

            slot1.Reserve();

            context.DoctorSlots.AddRange(
            slot1,
            DoctorSlot.Create(DateTime.Now.AddMinutes(15), Guid.NewGuid(), "Doctor Name 1 ", 100),

            DoctorSlot.Create(DateTime.Now.AddMinutes(30), Guid.NewGuid(), "Doctor Name 3 ", 100)
            );
            await context.SaveChangesAsync();
        }

        using (var context = new DoctorAvailabilityContext(options))
        {
            var repo = new DoctorSlotRepo(context);

            // Act
            var result = await repo.GetAvailableSlots();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count); // Only 2 slots are not reserved

        }
    }



    [Fact]
    public async Task GetAvailableSlots_ReturnsEmptyList_WhenNoSlotsExist()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DoctorAvailabilityContext>()
            .UseInMemoryDatabase(databaseName: "EmptyDatabaseTestDB")
            .Options;

        using (var context = new DoctorAvailabilityContext(options))
        {
            // No slots added
        }

        using (var context = new DoctorAvailabilityContext(options))
        {
            var repo = new DoctorSlotRepo(context);

            // Act
            var result = await repo.GetAvailableSlots();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result); // No slots in the database
        }
    }

    [Fact]
    public async Task GetAvailableSlots_ValidatesReturnedData()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DoctorAvailabilityContext>()
            .UseInMemoryDatabase(databaseName: "ValidateReturnedDataTestDB")
            .Options;

        var expectedSlot = DoctorSlot.Create(DateTime.Now, Guid.NewGuid(), "Doctor Name 3 ", 100);

        using (var context = new DoctorAvailabilityContext(options))
        {
            context.DoctorSlots.Add(expectedSlot);
            await context.SaveChangesAsync();
        }

        using (var context = new DoctorAvailabilityContext(options))
        {
            var repo = new DoctorSlotRepo(context);

            // Act
            var result = await repo.GetAvailableSlots();

            // Assert
            Assert.Single(result); // Only one slot available
            var slot = result.First();

            Assert.Equal(expectedSlot.Date, slot.Date);
            Assert.Equal(expectedSlot.DoctorId, slot.DoctorId);
            Assert.Equal(expectedSlot.DoctorName, slot.DoctorName);
            Assert.Equal(expectedSlot.Cost, slot.Cost);
        }





    }

    //GetSlotsById


    [Fact]
    public async Task GetSlotsById_ReturnsSlotMatchingId()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DoctorAvailabilityContext>()
            .UseInMemoryDatabase(databaseName: "GetSlotByIdDB")
            .Options;

        var expectedSlot = DoctorSlot.Create(DateTime.Now, Guid.NewGuid(), "Doctor Name 3 ", 100);


        using (var context = new DoctorAvailabilityContext(options))
        {
            context.DoctorSlots.Add(expectedSlot);
            await context.SaveChangesAsync();
        }

        using (var context = new DoctorAvailabilityContext(options))
        {
            var repo = new DoctorSlotRepo(context);

            // Act
            var result = await repo.GetSlotsById(expectedSlot.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedSlot.Id, result.Id);
            Assert.Equal(expectedSlot.Date, result.Date);
            Assert.Equal(expectedSlot.DoctorId, result.DoctorId);
            Assert.Equal(expectedSlot.DoctorName, result.DoctorName);
            Assert.Equal(expectedSlot.Cost, result.Cost);
        }
    }

    [Fact]
    public async Task GetSlotsById_ReturnsNull_WhenSlotDoesNotExist()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DoctorAvailabilityContext>()
            .UseInMemoryDatabase(databaseName: "SlotDoesNotExistDB")
            .Options;

        using (var context = new DoctorAvailabilityContext(options))
        {
            var repo = new DoctorSlotRepo(context);

            // Act
            var result = await repo.GetSlotsById(Guid.NewGuid()); // Non-existent ID

            // Assert
            Assert.Null(result);
        }
    }

    [Fact]
    public async Task GetSlotsById_ReturnsNull_WhenDatabaseIsEmpty()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DoctorAvailabilityContext>()
            .UseInMemoryDatabase(databaseName: "EmptyDatabaseDB")
            .Options;

        using (var context = new DoctorAvailabilityContext(options))
        {
            var repo = new DoctorSlotRepo(context);

            // Act
            var result = await repo.GetSlotsById(Guid.NewGuid());

            // Assert
            Assert.Null(result);
        }
    }
    [Fact]
    public async Task GetSlotsById_ValidatesReturnedDataConsistency()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DoctorAvailabilityContext>()
            .UseInMemoryDatabase(databaseName: "DataConsistencyDB")
            .Options;

        var slot = DoctorSlot.Create(DateTime.Now, Guid.NewGuid(), "Doctor Name 3 ", 100);


        using (var context = new DoctorAvailabilityContext(options))
        {
            context.DoctorSlots.Add(slot);
            await context.SaveChangesAsync();
        }

        using (var context = new DoctorAvailabilityContext(options))
        {
            var repo = new DoctorSlotRepo(context);

            // Act
            var result = await repo.GetSlotsById(slot.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(slot.Id, result.Id);
            Assert.Equal(slot.Date, result.Date);
            Assert.Equal(slot.DoctorId, result.DoctorId);
            Assert.Equal(slot.DoctorName, result.DoctorName);
            Assert.Equal(slot.Cost, result.Cost);
        }
    }

}
