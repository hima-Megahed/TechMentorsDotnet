using DoctorAvailability.Business.Repositories;
using DoctorAvailability.Business.Services.DoctorSlot;
using DoctorAvailability.Data.DbContext;
using DoctorAvailability.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorAvailability.UnitTests.RepositoriesTests
{
    public class DoctorSlotRepoTests
    {
        private readonly DbContextOptions<DoctorAvailabilityContext> _dbContextOptions;
        public DoctorSlotRepoTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<DoctorAvailabilityContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }
        private DoctorAvailabilityContext GetDbContext()
        {
            return new DoctorAvailabilityContext(_dbContextOptions);
        }

        [Fact]
        public async Task GetDoctorAvailableSlots_ShouldReturnAvailableSlots()
        {
            // Arrange
            var context = GetDbContext();
            var doctorSlotRepo = new DoctorSlotRepo(context);

            // Prepare test data
            var doctorSlots = new List<DoctorSlot>
        {
            new DoctorSlot { Id = Guid.NewGuid(), IsReserved = false },
            new DoctorSlot { Id = Guid.NewGuid(), IsReserved = true },
            new DoctorSlot { Id = Guid.NewGuid(), IsReserved = false }
        };
            context.DoctorSlots.AddRange(doctorSlots);
            await context.SaveChangesAsync();

            // Act
            var availableSlots = await service.GetDoctorAvailableSlots();

            // Assert
            Assert.Equal(2, availableSlots.Count); // Expect 2 available slots
        }

        [Fact]
        public async Task AddSlot_ShouldAddNewSlot()
        {
            // Arrange
            var context = GetDbContext();
            var service = new DoctorSlotService(context);

            var newSlot = new DoctorSlot
            {
                Id = Guid.NewGuid(),
                IsReserved = false
            };

            // Act
            var addedSlotId = await service.AddSlot(newSlot);

            // Assert
            var addedSlot = await context.DoctorSlots.FindAsync(addedSlotId);
            Assert.NotNull(addedSlot);
            Assert.Equal(newSlot.Id, addedSlot.Id);
        }

        [Fact]
        public async Task GetMySlots_ShouldReturnAllSlots()
        {
            // Arrange
            var context = GetDbContext();
            var service = new DoctorSlotService(context);

            var doctorSlots = new List<DoctorSlot>
        {
            new DoctorSlot { Id = Guid.NewGuid(), IsReserved = false },
            new DoctorSlot { Id = Guid.NewGuid(), IsReserved = true }
        };
            context.DoctorSlots.AddRange(doctorSlots);
            await context.SaveChangesAsync();

            // Act
            var slots = await service.GetMySlots();

            // Assert
            Assert.Equal(2, slots.Count); // Expect 2 slots in the list
        }

        [Fact]
        public async Task GetSlotById_ShouldReturnCorrectSlot()
        {
            // Arrange
            var context = GetDbContext();
            var service = new DoctorSlotService(context);

            var slotId = Guid.NewGuid();
            var slot = new DoctorSlot { Id = slotId, IsReserved = false };
            context.DoctorSlots.Add(slot);
            await context.SaveChangesAsync();

            // Act
            var fetchedSlot = await service.GetSlotById(slotId);

            // Assert
            Assert.NotNull(fetchedSlot);
            Assert.Equal(slotId, fetchedSlot?.Id);
        }
    }
}
