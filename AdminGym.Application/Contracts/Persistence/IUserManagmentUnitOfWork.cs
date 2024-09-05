using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminGym.Application.Contracts.Persistence
{
    public interface IUserManagmentUnitOfWork
        : IUnitOfWork
    {
        IUserRepositoryAsync UserRepository { get; }
    }
}
