using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupportingIELTSWriting.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Data.Configurations
{
    public class EssayConfiguration : IEntityTypeConfiguration<Essay>
    {
        public void Configure(EntityTypeBuilder<Essay> builder)
        {
            builder
                .HasOne(p => p.Topic);
                
        }
    }
}
