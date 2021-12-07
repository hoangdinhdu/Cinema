using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [StringLength(20)]
        public string CustomerID { get; set; }
        [StringLength(50)]
        [Display (Name ="Họ và tên")]
        public string CustomerName { get; set; }
       
        [Display(Name = "Số điện thoại")]
        public String CustomerPhone { get; set; }
        [StringLength(50)]
        [Display(Name = "Địa chỉ")]
        public string CustomerAddress { get; set; }
        [StringLength(50)]
        [Display(Name = "Email")]
        public string CustomerEmail { get; set; }
        public string MovieID { get; set; }
        [ForeignKey("MovieID")]
      
        public virtual Movie Movie { get; set; }
        public string hinhthucID { get; set; }
        [ForeignKey("hinhthucID")]

        public virtual HinhThucThanhToan HinhThucThanhToan { get; set; }



    }
}