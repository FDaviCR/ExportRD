using System;
using System.Collections.Generic;
using System.Text;

namespace Alfa.Model
{
    internal class Contacts
    {
        public string name { get; set; }
        public string title { get; set; }
        public string notes { get; set; }
        public string facebook { get; set; }
        public string linkedin { get; set; }
        public string skype { get; set; }
        public string birthday { get; set; }
        public List<Emails> emails { get; set; }
        public List<Phones> phones { get; set; }
    }
}
