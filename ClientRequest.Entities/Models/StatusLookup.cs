using System;
using System.Collections.Generic;

namespace ClientRequest.Entities.Models
{
    public partial class StatusLookup
    {
        public StatusLookup()
        {
            this.RequestStatus = new List<RequestStatu>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public virtual ICollection<RequestStatu> RequestStatus { get; set; }
    }
}
