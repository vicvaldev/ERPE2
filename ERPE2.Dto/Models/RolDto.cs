namespace ERPE2.Dto;

public class RolDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<UserDto>? Users { get; set; }
}