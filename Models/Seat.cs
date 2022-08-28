using System;
using System.Collections.Generic;

#nullable disable

namespace EFProject.Models
{
    public partial class Seat
    {
        public int passId { get; set; }
        public int purchaseId { get; set; }

        public int seatId {get; set;}
        public string Class { get; set; }
       
    }
}
