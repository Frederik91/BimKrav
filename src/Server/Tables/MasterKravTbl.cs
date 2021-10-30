using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Server.Tables;

[Table("tblmasterkrav")]
public class MasterKravTbl
{
    [Column("Id_Main")]
    public int Id { get; set; }

    [Column("Id_Pset")]
    public int PSetId { get; set; }

    [Column("Id_Property")]
    public int PropertyId { get; set; }

    [Column("ID_Element")]
    public int ElementId { get; set; }

    public string PsetName { get; set; }
    public string PropertyName { get; set; }
    public string IfcPropertyType { get; set; }
    public string RevitPropertyType { get; set; }
    public string PropertyGroup { get; set; }


    [Column("RevitElement")]
    public string RevitCategory { get; set; }
    public bool Skisseprosjekt { get; set; }
    public bool Forprosjekt { get; set; }
    public bool Detaljprosjekt { get; set; }
    public bool Arbeidstegning { get; set; }
    public bool Overlevering { get; set; }

    public virtual PropertyTbl Properties { get; set; }
    public virtual PSetTbl PSets { get; set; }
}