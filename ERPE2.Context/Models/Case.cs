namespace ERPE2.Context.Models;

public class Case
{
    public int Id { get; set; }
    public int Stock { get; set; }
    public int? ModelId { get; set; }
    public int? ColorId { get; set; }
    public int? CaseTypeId { get; set; }
    public Model? ModelNavigation { get; set; }
    public Color? ColorNavigation { get; set; }
    public CaseType? CaseTyepeNavigation { get; set; }
}