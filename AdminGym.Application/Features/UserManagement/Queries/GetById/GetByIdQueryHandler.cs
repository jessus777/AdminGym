using AdminGym.Application.Contracts.Persistence;
using AdminGym.Application.Features.UserManagement.Dtos;
using AdminGym.Application.Request;
using AdminGym.Domain.Errors;
using AutoMapper;
using FluentResults;

namespace AdminGym.Application.Features.UserManagement.Queries.GetById;
public sealed class GetByIdQueryHandler
    : ApplicationRequestHandler<GetByIdQuery, UserGetByIdResponseDto>
{
    private readonly IUserManagmentUnitOfWork _userManagmentUnitOfWork;
    private readonly IMapper _mapper;

    public GetByIdQueryHandler(IUserManagmentUnitOfWork userManagmentUnitOfWork, IMapper mapper)
    {
        _userManagmentUnitOfWork = userManagmentUnitOfWork;
        _mapper = mapper;
    }

    protected override async Task<Result<UserGetByIdResponseDto>> HandleAsync(
        GetByIdQuery request,
        CancellationToken cancellationToken
        )
    {
        var userByIdAsync = await _userManagmentUnitOfWork.UserRepository
             .GetByIdAsync(Guid.Parse(request.UserId));

        if (userByIdAsync is null)
        {
            return DomainError.EntityNotFound(request.UserId);
        }

        var userDto = _mapper.Map<UserGetByIdResponseDto>(userByIdAsync);
        return Ok(userDto);
    }
}
