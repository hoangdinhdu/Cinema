using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Giochieu
    {
        [Key]
        [Display(Name =("Giờ chiếu"))]
        public string IDGioChieu { get; set; }
        [Display(Name ="Thời gian chiếu")]
        public string ThoiGianChieu { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}