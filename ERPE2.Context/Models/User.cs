namespace ERPE2.Context.Models;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int RolId { get; set; }
    public Rol? RolNavigation { get; set; }
}