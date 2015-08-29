using System;
namespace TC.Ioc.Core
{
    public abstract class EntityBase
    {
      public Int64 ID { get; set; }
      public DateTime createDate { get; set; }
      public DateTime modifiedDate { get; set; }
      public string IP { get; set; }
    }
}
