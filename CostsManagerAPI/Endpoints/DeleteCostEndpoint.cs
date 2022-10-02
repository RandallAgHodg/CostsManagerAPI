﻿using CostsCManagerAPI.Contracts.Requests;
using CostsCManagerAPI.Services;
using FastEndpoints;

namespace CostsManagerAPI.Endpoints;

public class DeleteCostEndpoint : Endpoint<DeleteCostRequest>
{
    private readonly ICostService _costService;

    public DeleteCostEndpoint(ICostService costService)
    {
        _costService = costService;
    }
    
    public override void Configure()
    {
        Delete("costs/{id:guid}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteCostRequest req, CancellationToken ct)
    {
        var deleted = await _costService.DeleteAsync(req.Id);

        if (!deleted)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendNoContentAsync(ct);
    }
}