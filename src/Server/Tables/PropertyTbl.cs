using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Server.Tables;

[Table("tblproperty")]
public class PropertyTbl
{
    public PropertyTbl()
    {
        RevitCategoryProperties = new HashSet<RevitCategoryPropertiesTbl>();
        PhaseProperties = new HashSet<PhasePropertyTbl>();
        PSetProperties = new HashSet<PsetPropertyTbl>();
    }

    [Column("ID_Property", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("PropertyName", TypeName = "text")]
    [Required]
    public string Name { get; set; } = null!;

    [Column("IfcPropertyType", TypeName = "text")]
    [Required]
    public string IfcPropertyType { get; set; } = null!;

    [Column("RevitPropertyType", TypeName = "text")]
    [Required]
    public string RevitPropertyType { get; set; } = null!;

    [Column("TypeInstans", TypeName = "text")]
    [Required]
    [DefaultValue("'''Instans'''")]
    public string TypeInstance { get; set; } = null!;

    [Column("PropertyGroup", TypeName = "text")]
    [Required]
    public string PropertyGroup { get; set; } = null!;

    [Column("PropertyDescription", TypeName = "text")]
    public string? Description { get; set; } = null!;

    [Column("PropertyComment", TypeName = "text")]
    [Required]
    [DefaultValue("'''--'''")]
    public string Comment { get; set; } = null!;

    [Column("Kommer fra 2B", TypeName = "tinyint(4)")]
    [DefaultValue("'NULL'")]
    public bool? HasB2Origin { get; set; }

    [Column("Initiert av", TypeName = "text")]
    [DefaultValue("'NULL'")]
    public string? Initiator { get; set; }

    [Column("PropertyGuid")]
    [DefaultValue("'uuid()'")]
    [MaxLength(36)]
    public Guid? Guid { get; set; }
    
    public virtual ICollection<RevitCategoryPropertiesTbl> RevitCategoryProperties { get; set; } = null!;
    public virtual ICollection<PhasePropertyTbl> PhaseProperties { get; set; } = null!;
    public virtual ICollection<PsetPropertyTbl> PSetProperties { get; set; } = null!;
}