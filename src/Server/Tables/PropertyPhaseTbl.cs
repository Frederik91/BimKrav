using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Server.Tables;

[Table("property_fase_flagg_junction")]
public class PropertyPhaseTbl
{
    [Column("ID_Property")]
    public int PropertyId { get; set; }

    [Column("ID_Pset")]
    public int PSetId { get; set; }

    [Column("Skisseprosjekt")]
    public bool Skisseprosjekt { get; set; }

    [Column("Forprosjekt")]
    public bool Forprosjekt { get; set; }

    [Column("Detaljprosjekt")]
    public bool Detaljprosjekt { get; set; }

    [Column("Arbeidstegning")]
    public bool Arbeidstegning { get; set; }

    [Column("Overlevering")]
    public bool Overlevering { get; set; }
}