using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Server.Tables;

[Table("property_regex_junction")]
public class PropertyRegexTbl
{
    [Column("ID_Property")]
    public int? PropertyId { get; set; }

    [Column("ID_Regex")]
    public int? RegexId { get; set; }

    public virtual PropertyTbl Property { get; set; }
    public virtual RegexTbl Regex { get; set; }
}