using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class DatVe
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string MovieID { get; set; }
        [ForeignKey("MovieID")]
        public virtual Movie Movie { get; set; }
    }
}