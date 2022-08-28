using System;
using System.Collections.Generic;

#nullable disable

namespace EFProject.Models
{

    public class Payment
    {
     
        public int PurchaseId { get; set; }


        public int passId { get; set; }
        public decimal Amount { get; set; }

       
        Passenger Paseengers { get; set; }
    }

}
