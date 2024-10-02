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
        private readonly RoleManager<Role> _roleManager;
        private readonly ApplicationDbEFContext _context;

        private IUserRepositoryAsync? _userRepositoryAsync;
        private IPermissionRepositoryAsync? _permissionRepositoryAsync;
        private IRoleRepositoryAsync? _roleRepositoryAsync;

        public UserManagmentUnitOfWork(
            UserManager<User> userManager,
            ApplicationDbEFContext context,
            RoleManager<Role> roleManager
            )
            : base(context)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
        }

        public IUserRepositoryAsync UserRepository =>
              _userRepositoryAsync ??= new UserRepositoryAsync(_context, _userManager);

        public IPermissionRepositoryAsync PermissionRepository =>
            _permissionRepositoryAsync ??= new PermissionRepositoryAsync(_context);

        public IRoleRepositoryAsync RoleRepository =>
            _roleRepositoryAsync ??= new RoleRepositoryAsync(_context, _roleManager);
    }
}
