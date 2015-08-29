using System;
namespace TC.Ioc.Core.Data
{
   public class User : EntityBase
    {
       public string name { get; set; }
       public string email { get; set; }
       public string password { get; set; }
       public virtual UserProfile UserProfile { get; set; }
    }
}
