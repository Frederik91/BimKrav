using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Server.Tables;

[Table("tblregex")]
public class RegexTbl
{
    [Column("ID_Regex")]
    public int Id { get; set; }

    [Column("RegexString")]
    public string RegexString { get; set; }
}