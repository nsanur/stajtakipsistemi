using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StajTakip.Data.Entities
{
    public class Stajyer
    {
        [Key]
        [Display(Name = "TC No")]
        public string Id { get; set; }

        public string Departman { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }

        [Display(Name = "Başlama Tarihi")]
        public Nullable<System.DateTime> BaslamaTarihi { get; set; }
    }
}
