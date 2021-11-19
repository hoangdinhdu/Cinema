using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Reservation
    {
        [Key]
        public string ReservationID { get; set; }
        public string CustomerID { get; set; }
        public string MovieID { get; set; }
    }
}