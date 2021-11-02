using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace BimKrav.Server.Tables;

[Table("tbldiscipline")]
public class DisciplineTbl
{
    public DisciplineTbl()
    {
        DisciplineRevitCategories = new HashSet<DisciplineRevitCategoryTbl>();
    }
    
    [Column("ID_Discipline", TypeName = "int(11)")]

    public int Id { get; set; }
        
    [Column("DisciplineName", TypeName = "text")]
    [DefaultValue("'NULL'")]
    public string? Name { get; set; }

    [Column("DisciplineCode", TypeName = "text")]
    [DefaultValue("'NULL'")]
    public string? Code { get; set; }

    public virtual ICollection<DisciplineRevitCategoryTbl> DisciplineRevitCategories { get; set; } = null!;
}