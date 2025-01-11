using DoctorAvailability.Shared;

namespace AppointmentBooking.Internal.Application.GetAvailableSlots;

internal class AddAppointmentHandler(ISlotFsadService availableSlotsService) : IRequestHandler<GetAvailableSlotsQuery, List<DoctorSlotDto>>
{

    public async Task<List<DoctorSlotDto>> Handle(GetAvailableSlotsQuery query, CancellationToken cancellationToken)
    {
        return await availableSlotsService.GetAvailableSlots();
    }


}
