using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SupportingIELTSWriting.Models;
using SupportingIELTSWriting.Models.Entities;
using SupportingIELTSWriting.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Data
{
    public class DictionaryDbContext : IdentityDbContext<User>
    {
        const char[] valudefaultCharacters = (char[])null;
        private IConvertorServices convertor;
        public DictionaryDbContext(DbContextOptions<DictionaryDbContext> options, IConvertorServices cv) : base(options)
        {
            convertor = cv;
        }

        public DbSet<Word> Words { get; set; }
        public DbSet<Phonetic> Phonetics { get; set; }
        public DbSet<Meaning> Meanings { get; set; }
        public DbSet<Definition> Definitions { get; set; }
        public DbSet<History> Histories { get; set; }
        //public DbSet<EssayErrors> EssayErrors { get; set; }
        public DbSet<Essay> Essays { get; set; }

        // apply configure
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // set configuration
            modelBuilder.Entity<User>()
                .HasMany(p => p.Histories)
                .WithOne(e => e.User)
                .HasForeignKey(p => p.userId);

            modelBuilder.Entity<User>()
                .HasMany(p => p.Essays)
                .WithOne(e => e.User)
                .HasForeignKey(p => p.userId);

            modelBuilder.Entity<Essay>()
                .HasMany(p => p.History)
                .WithOne(e => e.Essay)
                .HasForeignKey(p => p.essayId);

            

            // set primary key
            modelBuilder.Entity<Word>()
                .HasKey(p => p.wordId)
                .HasName("PRIMARY_KEY_WORD");

            modelBuilder.Entity<Word>()
                .HasMany(p => p.meanings)
                .WithOne(e => e.Word)
                .HasForeignKey(p => p.wordId);

            modelBuilder.Entity<Word>()
                .HasMany(p => p.phonetics)
                .WithOne(e => e.Word)
                .HasForeignKey(p => p.wordId);

            modelBuilder.Entity<Meaning>()
                .HasMany(p => p.definitions)
                .WithOne(e => e.Meaning)
                .HasForeignKey(p => p.meaningId);

            modelBuilder.Entity<Meaning>()
                .HasKey(p => p.meaningId)
                .HasName("PRIMARY_KEY_MEANING");

            modelBuilder.Entity<Definition>()
                .HasKey(p => p.definitionId)
                .HasName("PRIMARY_KEY_DEFINITION");

            modelBuilder.Entity<Phonetic>()
                .HasKey(p => p.phoneticId)
                .HasName("PRIMARY_KEY_PHONETIC");

            // convert audio to base64
            modelBuilder.Entity<Phonetic>()
                .Property(e => e.audio)
                .HasConversion(
                v => convertor.ConvertFileToBase64(v),
                v => v);

            // list string to string insert to database
            modelBuilder.Entity<Definition>()
                .Property(e => e.synonyms)
                .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));


            // add foreign key and value
           
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
