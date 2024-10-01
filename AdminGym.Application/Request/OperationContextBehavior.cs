﻿using AdminGym.Application.Contracts.Infrastructure;
using AdminGym.Domain.Common;
using MediatR;

namespace AdminGym.Application.Request
{
    public sealed class OperationContextBehavior<TRequest, TResult> : IPipelineBehavior<TRequest, TResult>
    where TRequest : notnull
    {
        private readonly IOperationContextProvider _operationContextProvider;

        public OperationContextBehavior(IOperationContextProvider operationContextProvider)
        {
            _operationContextProvider = operationContextProvider;
        }

        public async Task<TResult> Handle(TRequest request, RequestHandlerDelegate<TResult> next, CancellationToken cancellationToken)
        {
            var requestType = request.GetType();
            var property = requestType.GetProperty("Context");
            if (property is null || property.PropertyType != typeof(OperationContext))
                return await next();

            property.SetValue(request, _operationContextProvider.GetContext());
            return await next();
        }
    }
}
