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
        [Required]
        public int Id { get; set; }

        [Display(Name = "TC No:")]
        [Required(ErrorMessage = "TC No Girilmesi Zorunludur!")]
        [Range(10000000000,100000000000,ErrorMessage ="TC No 11 hane olmalıdır!")]
        public string TcNo { get; set; }

        [Display(Name = "Departman:")]
        public string? Departman { get; set; }

        [Display(Name = "Ad:")]
        [Required(ErrorMessage = "Ad Girilmesi Zorunludur!")]
        public string Ad { get; set; }

        [Display(Name = "Soyad:")]
        [Required(ErrorMessage = "Soyad Girilmesi Zorunludur!")]
        public string Soyad { get; set; }

        [Display(Name = "Telefon:")]
        public string? Telefon { get; set; }


        [Display(Name = "Başlama Tarihi:")]
        public DateTime? BaslamaTarihi { get; set; } = DateTime.Today;

    }
}
