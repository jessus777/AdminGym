namespace AdminGym.Application.Features.UserManagement.Dtos;
public class CreateUserCommandDto
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string PaternalSurname { get; set; }
    public string MaternalSurname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
}
