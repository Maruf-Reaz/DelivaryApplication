using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Models
{
    public class PickUpRequest
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime PickUpDate { get; set; }
        public string RequestId { get; set; }
        public string Details { get; set; }
        public int LocationFromId { get; set; }
        public Location LocationFrom { get; set; }
        public int? PickUpDeliveryManId { get; set; }
        public DeliveryMan PickUpDeliveryMan { get; set; }

        public int MerchantId { get; set; }
        public Merchant Merchant { get; set; }

        public int Status { get; set; }


        public List<Package> Packages { get; set; }
    }
}
