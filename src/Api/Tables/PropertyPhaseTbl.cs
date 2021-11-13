using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BimKrav.Api.Tables;

[Table("property_fase_flagg_junction")]
[Keyless]
public class PropertyPhaseTbl
{
    [Column("ID_Property", TypeName = "int(11)")]
    public int PropertyId { get; set; }

    [Column("ID_Pset", TypeName = "int(11)")]
    public int PSetId { get; set; }

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
}