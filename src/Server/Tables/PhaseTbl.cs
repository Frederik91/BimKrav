using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Server.Tables;

[Table("tblfase")]
public class PhaseTbl
{
    public PhaseTbl()
    {
        PhaseProperties = new HashSet<PhasePropertyTbl>();
    }

    [Column("ID_Fase")]
    public int Id { get; set; }

    [Column("FaseNavn")]
    public string Name { get; set; }

    public virtual ICollection<PhasePropertyTbl> PhaseProperties { get; set; }
}