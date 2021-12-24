using latihan1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace latihan1.Pages
{
    public class  MahasiswaaddModel :PageModel
    {
        [BindProperty]
        public DataMahasiswa Mhs{get;set;}
        public IActionResult OnGet(string action,string id){
            if(action!=null && id!=null){
                ProsesMahasiswa proses=new ProsesMahasiswa();
                switch(action.ToUpper()){
                    case "EDIT":
                        Mhs=proses.GetDataMahasiswaById(id);
                        break;
                    case "DELETE":
                        if(proses.deleteMahasiswa(id)){
                            return new RedirectToPageResult("/Mahasiswa");
                        }
                        break;
                    default:
                        break;

                }
            }
            return Page();
        }
        public IActionResult OnPost(){
            ProsesMahasiswa proses=new ProsesMahasiswa();
            if(Mhs.Id!=0){
                if(proses.updateMahasiswa(Mhs)){
                return new RedirectToPageResult("/Mahasiswa");
            }
            
            }else{
                if(proses.saveMahasiswa(Mhs)){
                return new RedirectToPageResult("/Mahasiswa");
            }
            
            }
            return Page();
        }
    }
}