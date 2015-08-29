using System.Data.Entity.ModelConfiguration;
using TC.Ioc.Core.Data;

namespace TC.Ioc.Data.Mapping
{
   public class UserProfileMap : EntityTypeConfiguration<UserProfile>
    {
       public UserProfileMap()
       {
           //key
           HasKey(t => t.ID);
           //properties           
           Property(t => t.firstName).IsRequired().HasMaxLength(100).HasColumnType("nvarchar");
           Property(t => t.lastName).HasMaxLength(100).HasColumnType("nvarchar");
           Property(t => t.address).HasColumnType("nvarchar");
           Property(t => t.createDate).IsRequired();
           Property(t => t.modifiedDate).IsRequired();
           Property(t => t.IP);
           //table
           ToTable("tblUserProfiles");
           //relation          
           HasRequired(t => t.user).WithRequiredDependent(u => u.UserProfile);
       }       
    }
}
