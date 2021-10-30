using System;
using System.Collections.Generic;
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

    [Column("ID_Element")]
    public int Id { get; set; }

    [Column("RevitElement")]
    public string Name { get; set; }

    public virtual ICollection<DisciplineRevitCategoryTbl> DisciplineRevitCategories { get; set; }
    public virtual ICollection<RevitCategoryPropertiesTbl> ElementProperties { get; set; }
}