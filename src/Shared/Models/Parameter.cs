﻿using System.Collections.Generic;

namespace BimKrav.Shared.Models
{
    public class Parameter
    {
        public string PropertyName { get; set; }
        public List<string> Categories { get; set; }
        public string Level { get; set; }
        public string RevitPropertyType { get; set; }
    }
}