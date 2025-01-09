using DoctorAvailability.Internal.Models;

namespace DoctorAvailability.UnitTests;

public class DoctorSlotTests
{
    [Fact]
    public void Create_doctorSlot_should_throw_when_date_is_defult()
    {
        // Arrange
        var date = default(DateTime);
        var doctorId = Guid.NewGuid();
        var doctorName = "Doctor Name";
        var cost = 10;
        // Act & Assert
        Assert.Throws<ArgumentException>(() => DoctorSlot.Create(date, doctorId, doctorName, cost));
    }
    [Fact]
    public void Create_doctorSlot_should_throw_when_docotId_is_defult_or_empty()
    {
        // Arrange
        var date = DateTime.Now;
        var doctorId = Guid.Empty;
        var doctorName = "Doctor Name";
        var cost = 10;
        // Act & Assert
        Assert.Throws<ArgumentException>(() => DoctorSlot.Create(date, doctorId, doctorName, cost));
    }

    [Fact]
    public void Create_doctorSlot_should_throw_when_docot_name_is_empty()
    {
        // Arrange
        var date = DateTime.Now;
        var doctorId = Guid.NewGuid();
        var doctorName = "";
        var cost = 10;
        // Act & Assert
        Assert.Throws<ArgumentException>(() => DoctorSlot.Create(date, doctorId, doctorName, cost));
    }
    [Fact]
    public void Create_doctorSlot_should_throw_when_docot_name_is_white_space()
    {
        // Arrange
        var date = DateTime.Now;
        var doctorId = Guid.NewGuid();
        var doctorName = " ";
        var cost = 10;
        // Act & Assert
        Assert.Throws<ArgumentException>(() => DoctorSlot.Create(date, doctorId, doctorName, cost));
    }
    [Fact]
    public void Create_doctorSlot_should_throw_when_docot_name_is_null()
    {
        // Arrange
        var date = DateTime.Now;
        var doctorId = Guid.NewGuid();
        string doctorName = null!;
        var cost = 10;
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => DoctorSlot.Create(date, doctorId, doctorName, cost));
    }
    [Fact]
    public void Create_doctorSlot_should_throw_when_cost_is_zero()
    {
        // Arrange
        var date = DateTime.Now;
        var doctorId = Guid.NewGuid();
        string doctorName = "Doctor Name";
        var cost = 0;
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => DoctorSlot.Create(date, doctorId, doctorName, cost));
    }
    [Fact]
    public void Create_doctorSlot_should_throw_when_cost_is_less_than_zero()
    {
        // Arrange
        var date = DateTime.Now;
        var doctorId = Guid.NewGuid();
        string doctorName = "Doctor Name";
        var cost = -1;
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => DoctorSlot.Create(date, doctorId, doctorName, cost));
    }
    [Fact]
    public void Create_doctorSlot_should_return_new_id()
    {
        // Arrange
        var date = DateTime.Now;
        var doctorId = Guid.NewGuid();
        string doctorName = "Doctor Name";
        var cost = 10;
        // Act
        var slot = DoctorSlot.Create(date, doctorId, doctorName, cost);
        // Assert
        Assert.True(slot.Id != Guid.Empty);
    }
}
