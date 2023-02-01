//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;

//namespace SLE_System.Models
//{
//    public class RegisterViewModel
//    {
//        [Key]
//        public int Id { get; set; }

//        [Required]
//        [Display(Name = "Your Name")]
//        public string UserName { get; set; }

//        [Required]
//        [Display(Name = "Your PhoneNumber")]
//        public string PhoneNumber { get; set; }

//        [Required]
//        [EmailAddress]
//        public string Email { get; set; }
//        [Required]
//        [DataType(DataType.Password)]
//        public string Password { get; set; }
         
//        [DataType(DataType.Password)]
//        [Display(Name ="Confirm Password")]
//        [Compare("Password",ErrorMessage ="Password and confirmation password not match.")]
//        public string ConfirmPassword { get; set; }


//    }
//}
