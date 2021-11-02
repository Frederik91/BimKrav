using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Server.Tables;

[Table("tblmasterkrav")]
public class MasterKravTbl
{
    [Column("Id_Main", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("Id_Pset", TypeName = "int(11)")]
    public int PSetId { get; set; }

    [Column("Id_Property", TypeName = "int(11)")]
    public int PropertyId { get; set; }

    [Column("ID_Element", TypeName = "int(11)")]
    public int ElementId { get; set; }

    [Column("PsetName", TypeName = "text")]
    [Required]
    public string PsetName { get; set; }

    [Column("PropertyName", TypeName = "text")]
    [Required]
    public string PropertyName { get; set; }


    [Column("IfcPropertyType", TypeName = "text")]
    [Required]
    public string IfcPropertyType { get; set; }


    [Column("RevitPropertyType", TypeName = "text")]
    [Required]
    public string RevitPropertyType { get; set; }


    [Column("PropertyGroup", TypeName = "text")]
    [Required]
    public string PropertyGroup { get; set; }


    [Column("RevitElement", TypeName = "text")]
    [Required]
    public string RevitCategory { get; set; } = null!;

    [Column("Skisseprosjekt", TypeName = "tinyint(4)")]
    public bool Skisseprosjekt { get; set; }

    [Column("Forprosjekt", TypeName = "tinyint(4)")]
    public bool Forprosjekt { get; set; }

    [Column("Detaljprosjekt", TypeName = "tinyint(4)")]
    public bool Detaljprosjekt { get; set; }

    [Column("Arbeidstegning", TypeName = "tinyint(4)")]
    public bool Arbeidstegning { get; set; }

    [Column("Overlevering", TypeName = "tinyint(4)")]
    public bool Overlevering { get; set; }

    public virtual PropertyTbl Properties { get; set; }
    public virtual PSetTbl PSets { get; set; }
}