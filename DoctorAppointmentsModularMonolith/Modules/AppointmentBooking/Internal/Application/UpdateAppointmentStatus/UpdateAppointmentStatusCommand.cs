namespace AppointmentBooking.Internal.Application.AddAppointment;

internal record UpdateAppointmentStatusCommand(BookingStatus Status, Guid Id) : IRequest<bool>;
