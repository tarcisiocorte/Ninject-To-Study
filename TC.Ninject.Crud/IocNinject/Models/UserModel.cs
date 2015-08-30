using System;
using System.ComponentModel.DataAnnotations;

namespace TC.Ioc.Web.Models
{
    public class UserModel
    {
        public Int64 ID { get; set; }
        [Display(Name ="First Name")]
        public string firstName { get; set; }
        [Display(Name="Last Name")]
        public string lastName { get; set; }
        public string address { get; set; }
        [Display(Name="User Name")]
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        [Display(Name ="Added Date")]
        public DateTime createDate { get; set; }
    }
}