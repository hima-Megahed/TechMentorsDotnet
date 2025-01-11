namespace AppointmentBooking.Internal.Application.AddAppointment;

internal record AddAppointmentCommand(Guid SlotId, Guid PatientId, string PatientName) : IRequest<Guid?>;
