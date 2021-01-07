using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupportingIELTSWriting.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(u => u.Essays)
                .WithOne(m => m.User)
                .HasForeignKey(m => m.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
