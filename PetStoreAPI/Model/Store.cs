using System;

namespace PetStoreAPI
{
    public partial class Store
    {
        public long Id { get; set; }
        public long PetId { get; set; }
        public long Quantity { get; set; }
        public DateTime ShipDate { get; set; }
        public string Status { get; set; }
        public bool Complete { get; set; }
    }
}
