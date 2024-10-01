using AdminGym.Application.Features.UserManagement.Dtos;
using AdminGym.Application.Request;

namespace AdminGym.Application.Features.UserManagement.Queries.GetById;
public sealed class GetByIdQuery
    : ApplicationRequest<UserGetByIdResponseDto>
{
    public GetByIdQuery(string userId)
    {
        UserId = userId;
    }

    public string UserId { get; set; }
}
