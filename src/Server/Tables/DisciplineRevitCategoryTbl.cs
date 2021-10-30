using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Server.Tables;

[Table("dicipline_element_junction")]
public class DisciplineRevitCategoryTbl
{
    [Column("disciplineID")]
    public int DisciplineId { get; set; }

    [Column("elementID")]
    public int RevitCategoryId { get; set; }

    public DisciplineTbl Discipline { get; set; } = null!;
    public RevitCategoryTbl RevitCategory { get; set; } = null!;
}