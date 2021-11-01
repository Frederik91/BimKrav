using System;
using System.Collections.Generic;

namespace BimKrav.Shared.Models
{
    public class Property
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string IfcPropertyType { get; set; } = null!;

        public string RevitPropertyType { get; set; } = null!;

        public string TypeInstance { get; set; } = null!;

        public string PropertyGroup { get; set; } = null!;

        public string? Description { get; set; }

        public List<PSet> PSets { get; set; }

        public string Comment { get; set; } = null!;

        public Guid? Guid { get; set; }

        public List<RevitCategory> RevitCategories { get; set; } = null!;
    }
}