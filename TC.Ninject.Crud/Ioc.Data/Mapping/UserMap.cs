using System.Data.Entity.ModelConfiguration;
using TC.Ioc.Core.Data;

namespace TC.Ioc.Data.Mapping
{
   public class UserMap :EntityTypeConfiguration<User> 
    {
       public UserMap()
       {
           //key
           HasKey(t => t.ID);
           //properties
           Property(t => t.name).IsRequired();
           Property(t => t.email).IsRequired();
           Property(t => t.password).IsRequired();
           Property(t => t.createDate).IsRequired();
           Property(t => t.modifiedDate).IsRequired();
           Property(t => t.IP);
           //table
           ToTable("tblUsers");
       }
    }
}
