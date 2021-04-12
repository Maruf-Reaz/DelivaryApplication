using DeliveryApp.Models.Common.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Models
{
    public class DeliveryMan
    {
        public int Id { get; set; }
        public string DeliveryManIdNo { get; set; }
        //[NotMapped]
        //public string UserName { get; set; }
         [NotMapped]
        public string Email { get; set; }
        public string Name { get; set; }
        public string NIDNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        
        //public string ApplicationUserId { get; set; }
        //public ApplicationUser ApplicationUser { get; set; }

    }
}
