using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Api.Tables;

[Table("dicipline_element_junction")]
public class DisciplineRevitCategoryTbl
{
    [Column("disciplineID", TypeName = "int(11)")]
    public int DisciplineId { get; set; }

    [Column("elementID", TypeName = "int(11)")]
    public int RevitCategoryId { get; set; }

    public DisciplineTbl Discipline { get; set; } = null!;
    public RevitCategoryTbl RevitCategory { get; set; } = null!;
}