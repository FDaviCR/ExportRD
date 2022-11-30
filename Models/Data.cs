using System;
using System.Collections.Generic;
using System.Text;

namespace Alfa.Model
{
    internal class Data
    {
        public int total { get; set; }
        public Boolean has_more { get; set; }
        public List<Organizations> organizations { get; set; }
    }
}
