using System;
using System.Collections.Generic;

namespace ClientRequest.Entities.Models
{
    public partial class Product
    {
        public string ProductName { get; set; }
        public Nullable<int> Price { get; set; }
        public int slNO { get; set; }
        public Nullable<long> productId { get; set; }
        public string ImageUrl { get; set; }
    }
}
