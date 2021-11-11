using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    
    public class Movie:Customer
    {
        [Key]
        public string MovieID { get; set; }
        public string MovieName { get; set; }
        public string MovieHour { get; set; }
        public float MovieMoney { get; set; }


    }
}