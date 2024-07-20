namespace ERPE2.Context.Models;

public class Model
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int BrandId { get; set; }
    public Brand BrandNavigation { get; set; }
}