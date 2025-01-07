namespace AppointmentBooking.Internal.Endpoints.AddAppointment;
internal record AddAppointmentRequest(Guid SlotId, Guid PatientId, string PatientName);
