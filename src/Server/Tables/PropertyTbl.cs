using System;
using System.Collections.Generic;
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
        MasterKrav = new HashSet<MasterKravTbl>();
    }

    [Column("ID_Property")]
    public int Id { get; set; }

    [Column("PropertyName")]
    public string PropertyName { get; set; }

    [Column("IfcPropertyType")]
    public string IfcPropertyType { get; set; }

    [Column("RevitPropertyType")]
    public string RevitPropertyType { get; set; }

    [Column("TypeInstans")]
    public string TypeInstance { get; set; }
        
    [Column("PropertyGroup")]
    public string PropertyGroup { get; set; }

    [Column("PropertyDescription")]
    public string? PropertyDescription { get; set; }

    [Column("PropertyComment")]
    public string PropertyComment { get; set; }

    [Column("KommerFra2b")]
    public int? HasB2Origin { get; set; }

    [Column("InitiertAv")]
    public string? Initiator { get; set; }

    [Column("PropertyGuid")]
    public Guid? PropertyGuid { get; set; }

    public virtual ICollection<RevitCategoryPropertiesTbl> RevitCategoryProperties { get; set; } = null!;
    public virtual ICollection<PhasePropertyTbl> PhaseProperties { get; set; } = null!;
    public virtual ICollection<PsetPropertyTbl> PSetProperties { get; set; } = null!;
    public virtual ICollection<MasterKravTbl> MasterKrav { get; set; } = null!;
}