using DeliveryApp.Models.Common.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Models
{
    public class Merchant
    {

        public int Id { get; set; }
        public string MerchantIdNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        //Status 0 = Inactive , Status 2 = Active , Status 3= Disabled
    }
}
