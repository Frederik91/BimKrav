using System;
using System.Collections.Generic;
using BimKrav.Shared.Models;

namespace BimKrav.Client.ViewModels;

public class PropertyViewModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string IfcPropertyType { get; set; } = null!;

    public string RevitPropertyType { get; set; } = null!;

    public string TypeInstance { get; set; } = null!;

    public string PropertyGroup { get; set; } = null!;

    public string? Description { get; set; }

    public PSet? PSet { get; set; }
    public string Comment { get; set; } = null!;

    public Guid? Guid { get; set; }

    public List<RevitCategory> RevitCategories { get; set; } = null!;
    public bool ShowCategories { get; set; }


    public int CategoryPage { get; set; }
}