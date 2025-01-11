using DoctorAvailability.Shared;

namespace AppointmentBooking.Internal.Application.GetAvailableSlots;

internal record GetAvailableSlotsQuery() : IRequest<List<DoctorSlotDto>>;
