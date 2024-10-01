using AdminGym.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminGym.Application.Contracts.Infrastructure;
public interface IOperationContextProvider
{
    void SetContext(OperationContext operationContext);
    OperationContext GetContext();
}
