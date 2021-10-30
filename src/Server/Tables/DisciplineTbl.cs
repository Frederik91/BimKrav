using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Server.Tables;

[Table("tbldiscipline")]
public class DisciplineTbl
{
    public DisciplineTbl()
    {
        DisciplineRevitCategories = new HashSet<DisciplineRevitCategoryTbl>();
    }

    [Column("ID_Discipline")]

    public int Id { get; set; }
        
    [Column("DisciplineName")]
    public string Name { get; set; }

    [Column("DisciplineCode")]
    public string Code { get; set; }

    public virtual ICollection<DisciplineRevitCategoryTbl> DisciplineRevitCategories { get; set; } = null!;
}