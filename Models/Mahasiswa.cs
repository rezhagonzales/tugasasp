using System;
using System.ComponentModel.DataAnnotations;

namespace latihan1.Models
{
    public class Mahasiswa
    {
        [Required(ErrorMessage="Nama Wajib Diisi")]
        public string Nama{get;set;}
        public string Kelas{get;set;}
        [Required(ErrorMessage ="Tempat Lahir Wajib Diisi")]
        [RegularExpression("[a-zA-Z]*$",ErrorMessage ="Tempat Lahir Hanya Huruf")]
        public string TempatLahir{get;set;}
        [DataType(DataType.Date)]
        public DateTime TglLahir{get;set;}
        [Range(100,180,ErrorMessage ="Tinggi Badan Antara 100-180")]
        public int TinggiBadan{get;set;}
        [RegularExpression("^[0-9]*$")]
        public string Hp{get;set;}
    }
}