using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Account
    {
        [Required]
        [Key]
        [Display(Name ="Tài khoản")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display (Name ="Nhập lại mật khẩu")]
        public string ConfirmPassword { get; set; }
        [StringLength(10)]

        public string RoleID { get; set; }
        
    }
}
