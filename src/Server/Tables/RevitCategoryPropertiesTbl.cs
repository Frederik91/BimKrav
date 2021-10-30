using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Server.Tables;

[Table("element_property_junction")]
public class RevitCategoryPropertiesTbl
{
    [Column("ID_Element")]
    public int RevitCategoryId { get; set; }

    [Column("ID_Property")]
    public int PropertyId { get; set; }

    [Column("ID_PSet")]
    public int? PSetId { get; set; }

    public virtual RevitCategoryTbl RevitCategory { get; set; } = null!;
    public virtual PropertyTbl Property { get; set; } = null!;
}