using System.Collections.Generic;
using latihan1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace latihan1.Pages
{
    public class MahasiswaModel: PageModel
    {
        private readonly ILogger<MahasiswaModel> _loger;
        public MahasiswaModel(ILogger<MahasiswaModel> loger){
            _loger=loger;
        }
        [BindProperty]
        public Mahasiswa Mhs {get;set;}

        [BindProperty]
        public List<DataMahasiswa> DataMahasiswa {get;set;}
        public IActionResult OnGet()
        {
            koneksiDB conn=new koneksiDB();
            if (conn.CheckConnection()){
                TempData["cekkoneksi"]="Sukses Koneksi DB";
            }else{
                TempData["cekkoneksi"]="Gagal Koneksi DB";
            }
            ProsesMahasiswa proses=new ProsesMahasiswa();
            DataMahasiswa=proses.getMahasiswa();
            return Page();
        }
        public IActionResult OnPost(){
            TempData["namaMahasiswa"]=Mhs.Nama;
            TempData["kelasMahasiswa"]=Mhs.Kelas;
            TempData["tempatMahasiswa"]=Mhs.TempatLahir;
            TempData["tglMahasiswa"]=Mhs.TglLahir;
            TempData["tinggiMahasiswa"]=Mhs.TinggiBadan;
            TempData["hpMahasiswa"]=Mhs.Hp;
            
            return Page();
        }
    }
}