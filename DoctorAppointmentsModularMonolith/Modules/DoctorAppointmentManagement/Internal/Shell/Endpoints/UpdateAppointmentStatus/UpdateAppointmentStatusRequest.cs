using AppointmentBooking.Internal.Domain;

namespace DoctorAppointmentManagement.Internal.Shell.Endpoints.UpdateAppointmentStatus;
internal record UpdateAppointmentStatusRequest(BookingStatus Status, Guid Id);


