using System;
using System.Collections.Generic;
using System.Text;

namespace Alfa.Model
{
    internal class User
    {
        public string _id { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
