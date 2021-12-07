using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class HinhThucThanhToan
    {
        [Key]
        [Display(Name = ("Hình thức thanh toán"))]
        public string hinhthucID { get; set; }
        [Display(Name = ("Loại hinh thức thanh toán"))]

        public string LoaiHinhThuc { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}