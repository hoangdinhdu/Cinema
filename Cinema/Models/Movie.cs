﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    
    public class Movie
    {
        [Key]
        public string MovieID { get; set; }
        [Display(Name = "Tên Phim")]
        public string MovieName { get; set; }
        [Display(Name = "Giờ chiếu phim")]
        public string MovieHour { get; set; }
        [Display(Name = "Tiền vé")]
        public float MovieMoney { get; set; }
        [Display(Name = "Chỗ ngồi")]
        public string MovieSeat { get; set; }


    }
}