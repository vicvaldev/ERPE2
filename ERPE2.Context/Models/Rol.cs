namespace ERPE2.Context.Models;

public class Rol
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<User>? Users { get; set; }
}