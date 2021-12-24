using System.ComponentModel.DataAnnotations;

namespace latihan1.Models
{
    public class User{
        public int ID{get;set;}
        [Required]
        [EmailAddress]
        public string Email{get;set;}
        [DataType(DataType.Password)]
        public string Password{get;set;}
        public string message{get;set;}
    }
    

    } //end namespace