namespace ERPE2.Dto;

public class ModelDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int BrandId { get; set; }
    public BrandDto BrandNavigation { get; set; }
}