﻿using Carter;
using DoctorAvailability.Internal.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace DoctorAvailability.Shared;
public class AddSlotEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/AddSlot", async (DoctorSlotRequest request, DoctorSlotServcie servcie) =>
        {

            return Results.Ok(await servcie.AddSlot(request));
        }).WithTags("DoctorAvailability");
    }
}
