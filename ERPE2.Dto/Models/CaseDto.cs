namespace ERPE2.Dto;

public class CaseDto
{
    public int Id { get; set; }
    public int Stock { get; set; }
    public int? ModelId { get; set; }
    public int? ColorId { get; set; }
    public int? CaseTypeId { get; set; }
    public ModelDto? ModelNavigation { get; set; }
    public ColorDto? ColorNavigation { get; set; }
    public CaseTypeDto? CaseTyepeNavigation { get; set; }
}