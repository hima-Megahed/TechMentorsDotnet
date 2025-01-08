using AppointmentBooking.Shared;

namespace AppointmentBooking.Internal.Application.AddAppointment;

internal class UpdateAppointmentStatusHandler(IUpdateAppointmentStatusService updateAppointmentStatus) : IRequestHandler<UpdateAppointmentStatusCommand, bool>
{


    public async Task<bool> Handle(UpdateAppointmentStatusCommand command, CancellationToken cancellationToken)
    {
        //validation

        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }
        return await updateAppointmentStatus.UpdateAppointmentStatus(command.Status, command.Id);
    }
}
