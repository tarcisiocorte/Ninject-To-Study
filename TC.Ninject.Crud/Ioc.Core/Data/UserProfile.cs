using System;
namespace TC.Ioc.Core.Data
{
  public class UserProfile : EntityBase
    {
      public string firstName { get; set; }
      public string lastName { get; set; }
      public string address { get; set; }      
      public virtual User user { get; set; }
    }
}
