using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Messaging.Events;

namespace AppointmentConfirmation.Internal.EventHandlers;
public class AddAppointmentIntegrationEventHandler
    (ILogger<AddAppointmentIntegrationEventHandler> logger)
    : IConsumer<AddAppointmentIntegrationEvent>
{
    public async Task Consume(ConsumeContext<AddAppointmentIntegrationEvent> context)
    {
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        logger.LogInformation($"Patient {context.Message.PatientName} booking Appointment with Doctor {context.Message.DoctorName} at {context.Message.Date.ToString("dd-MM-yyyy hh:mm t")} ");
        await Task.CompletedTask;
    }



}
