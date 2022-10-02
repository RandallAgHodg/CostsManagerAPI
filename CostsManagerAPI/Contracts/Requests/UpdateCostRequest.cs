﻿namespace CostsCManagerAPI.Contracts.Requests;

public class UpdateCostRequest
{
    public Guid Id { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
    public float Amount { get; init; } = default!;
}