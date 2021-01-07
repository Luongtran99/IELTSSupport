﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SupportingIELTSWriting.Data;

namespace SupportingIELTSWriting.Data.Migrations
{
    [DbContext(typeof(DictionaryDbContext))]
    [Migration("20201231102154_InitialDictionaryDBCreation")]
    partial class InitialDictionaryDBCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SupportingIELTSWriting.Models.Definition", b =>
                {
                    b.Property<string>("definitionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("definition");

                    b.Property<string>("example");

                    b.Property<string>("meaningId");

                    b.Property<string>("synonyms");

                    b.HasKey("definitionId")
                        .HasName("PRIMARY_KEY_DEFINITION");

                    b.HasIndex("meaningId");

                    b.ToTable("Definitions");
                });

            modelBuilder.Entity("SupportingIELTSWriting.Models.Meaning", b =>
                {
                    b.Property<string>("meaningId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("partOfSpeech");

                    b.Property<string>("wordId");

                    b.HasKey("meaningId")
                        .HasName("PRIMARY_KEY_MEANING");

                    b.HasIndex("wordId");

                    b.ToTable("Meanings");
                });

            modelBuilder.Entity("SupportingIELTSWriting.Models.Phonetic", b =>
                {
                    b.Property<string>("phoneticId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("audio");

                    b.Property<string>("text");

                    b.Property<string>("wordId");

                    b.HasKey("phoneticId")
                        .HasName("PRIMARY_KEY_PHONETIC");

                    b.HasIndex("wordId");

                    b.ToTable("Phonetics");
                });

            modelBuilder.Entity("SupportingIELTSWriting.Models.Word", b =>
                {
                    b.Property<string>("wordId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("popularCount")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("word")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("wordId")
                        .HasName("PRIMARY_KEY_WORD");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("SupportingIELTSWriting.Models.Definition", b =>
                {
                    b.HasOne("SupportingIELTSWriting.Models.Meaning", "Meaning")
                        .WithMany("definitions")
                        .HasForeignKey("meaningId");
                });

            modelBuilder.Entity("SupportingIELTSWriting.Models.Meaning", b =>
                {
                    b.HasOne("SupportingIELTSWriting.Models.Word", "Word")
                        .WithMany("meanings")
                        .HasForeignKey("wordId");
                });

            modelBuilder.Entity("SupportingIELTSWriting.Models.Phonetic", b =>
                {
                    b.HasOne("SupportingIELTSWriting.Models.Word", "Word")
                        .WithMany("phonetics")
                        .HasForeignKey("wordId");
                });
#pragma warning restore 612, 618
        }
    }
}
