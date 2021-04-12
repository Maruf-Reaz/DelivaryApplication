using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Models
{
    public class Tarrif
    {
        public int Id { get; set; }

        public int PackageCatagoryId { get; set; }
        public PackageCatagory PackageCatagory { get; set; }

        public int LocationFromId { get; set; }
        public Location LocationFrom { get; set; }
        public int LocationToId { get; set; }
        public Location LocationTo { get; set; }


        public double Weight { get; set; }

        public double Amount { get; set; }

        public int Status { get; set; }



    }
}
