using System;
using System.Collections.Generic;

namespace ClientRequest.Entities.Models
{
    public partial class Request
    {
        public Request()
        {
            this.RequestStatus = new List<RequestStatu>();
        }

        public int ID { get; set; }
        public string Number { get; set; }
        public Nullable<int> ModuleID { get; set; }
        public Nullable<int> JobNatureID { get; set; }
        public Nullable<int> ClientID { get; set; }
        public string Description { get; set; }
        public string Assessment { get; set; }
        public string RequestedBy { get; set; }
        public Nullable<System.DateTime> RequestedOn { get; set; }
        public string AssignedTo { get; set; }
        public string CRW { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public virtual Client Client { get; set; }
        public virtual JobNature JobNature { get; set; }
        public virtual Module Module { get; set; }
        public virtual ICollection<RequestStatu> RequestStatus { get; set; }
    }
}
