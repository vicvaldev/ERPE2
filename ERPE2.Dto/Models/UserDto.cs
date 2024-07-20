namespace ERPE2.Dto;

public class UserDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public int RolId { get; set; }
    public RolDto? RolNavigation { get; set; }
}