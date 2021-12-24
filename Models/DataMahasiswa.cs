using System.ComponentModel.DataAnnotations;

namespace latihan1.Models
{
    public class DataMahasiswa
    {
        public int Id {get;set;}
        [Required(ErrorMessage="Nim Wajib Diisi")]
        public string Nim{get;set;}
        public string Nama{get;set;}
        public string Kelas{get;set;}
        public string Jurusan{get;set;}
    }
}