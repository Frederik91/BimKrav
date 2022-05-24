using System.Collections;
using System.Collections.Generic;

namespace BimKrav.Shared.Models;

public class RevitCategory
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<Discipline> Disciplines { get; set; } = new();
}