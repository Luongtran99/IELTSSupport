using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupportingIELTSWriting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Data.Configurations
{
    public class MeaningConfigurations :  IEntityTypeConfiguration<Meaning>
    {
        public void Configure(EntityTypeBuilder<Meaning> builder)
        {
            // change to Global Exception

            return ;
        }
    }
}
