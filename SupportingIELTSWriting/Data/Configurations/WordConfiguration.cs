using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupportingIELTSWriting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Data.Configurations
{
    public class WordConfiguration : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder
                .HasMany(p => p.meanings)
                .WithOne(p => p.Word)
                .HasForeignKey(p => p.wordId);
            
        }
    }
}
