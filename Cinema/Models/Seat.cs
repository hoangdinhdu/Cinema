using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Seat
    {
        [Key]
        [StringLength(30)]
        public string SeatID { get; set; }
        [StringLength(30)]
        [Display(Name ="Số phòng")]
        public string SeatRoom { get; set; }
        [StringLength(50)]
        [Display(Name ="Chỗ ngồi")]
        public string SeatName { get; set; }



    }
}