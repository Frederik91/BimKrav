using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Server.Tables;

[Table("Tblrevitelement")]
public class RevitCategoryTbl
{
    public RevitCategoryTbl()
    {
        DisciplineRevitCategories = new HashSet<DisciplineRevitCategoryTbl>();
        ElementProperties = new HashSet<RevitCategoryPropertiesTbl>();
    }

    [Column("ID_Element", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("RevitElement", TypeName = "text")]
    [Required]
    public string Name { get; set; } = null!;

    public virtual ICollection<DisciplineRevitCategoryTbl> DisciplineRevitCategories { get; set; }
    public virtual ICollection<RevitCategoryPropertiesTbl> ElementProperties { get; set; }
}