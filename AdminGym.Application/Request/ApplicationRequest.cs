using AdminGym.Domain.Common;
using FluentResults;
using MediatR;
using System.Text.Json.Serialization;

namespace AdminGym.Application.Request;
public abstract class ApplicationRequest<TResult> : IRequest<Result<TResult>>
{
    [JsonIgnore]
    public OperationContext Context { get; internal set; } = null!;
}

public abstract class ApplicationRequest : IRequest<Result>
{
    [JsonIgnore]
    public OperationContext Context { get; internal set; } = null!;
}
