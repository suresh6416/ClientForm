using System;
using System.Collections.Generic;

namespace ClientRequest.Entities.Models
{
    public partial class RequestStatu
    {
        public int ID { get; set; }
        public string Number { get; set; }
        public Nullable<int> RequestID { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<int> WorkLocationID { get; set; }
        public string Narration { get; set; }
        public string Note { get; set; }
        public string FromHours { get; set; }
        public string ToHours { get; set; }
        public string ToMinutes { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public virtual Request Request { get; set; }
        public virtual StatusLookup StatusLookup { get; set; }
        public virtual WorkLocationLookup WorkLocationLookup { get; set; }
    }
}
