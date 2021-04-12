using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Models.ViewModels
{
    public class PublicViewModel
    {
        public int Status { get; set; }
        public string PackageCatagory { get; set; }
        public string Merchant { get; set; }
        public string LocationFrom { get; set; }
        public string LocationTo { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }
    }
}
