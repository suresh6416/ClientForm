using System;
using System.Collections.Generic;

namespace ClientRequest.Entities.Models
{
    public partial class ClientModule
    {
        public int ID { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<int> ModuleID { get; set; }
        public virtual Client Client { get; set; }
        public virtual Module Module { get; set; }
    }
}
