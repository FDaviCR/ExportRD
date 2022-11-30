using System;
using System.Collections.Generic;
using System.Text;

namespace Alfa.Model
{
    internal class Organizations
    {
        public string _id { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string resume { get; set; }
        public string url { get; set; }
        public string address { get; set; }
        public int won_count { get; set; }
        public int lost_count { get; set; }
        public int opened_count { get; set; }
        public int paused_count { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<OrganizationSegments> organization_segments { get; set; }
        public List<User> users { get; set; }
        public List<Contacts> contacts { get; set; }
    }
}
