using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Api.Tables;

[Table("tblfase")]
public class PhaseTbl
{
    public PhaseTbl()
    {
        PhaseProperties = new HashSet<PhasePropertyTbl>();
    }

    [Column("ID_Fase", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("FaseNavn", TypeName = "text")]
    [Required]
    public string Name { get; set; } = null!;

    public virtual ICollection<PhasePropertyTbl> PhaseProperties { get; set; }
}