using System;
using System.Collections.Generic;

namespace ClientRequest.Entities.Models
{
    public partial class JobNature
    {
        public JobNature()
        {
            this.Requests = new List<Request>();
        }

        public int ID { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
