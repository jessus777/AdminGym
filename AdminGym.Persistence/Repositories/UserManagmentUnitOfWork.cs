using AdminGym.Application.Contracts.Persistence;
using AdminGym.Domain.Entities;
using AdminGym.Persistence.DbContexts;
using Microsoft.AspNetCore.Identity;

namespace AdminGym.Persistence.Repositories
{
    class UserManagmentUnitOfWork
        : UnitOfWork, IUserManagmentUnitOfWork
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbEFContext _context;



        private IUserRepositoryAsync? _userRepositoryAsync;

        public UserManagmentUnitOfWork(UserManager<User> userManager, ApplicationDbEFContext context)
            : base(context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IUserRepositoryAsync UserRepository =>
              _userRepositoryAsync ??= new UserRepositoryAsync(_context, _userManager);
    }
}
