using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using API_Mockada.Domains;

#nullable disable

namespace API_Mockada.Contexts
{
    public partial class MockadaContext : DbContext
    {
        public MockadaContext()
        {
        }

        public MockadaContext(DbContextOptions<MockadaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carro> Carros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS; initial catalog=API_MOCKADA; user Id=sa; pwd=senai@132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Carro>(entity =>
            {
                entity.HasKey(e => e.IdCarro)
                    .HasName("PK__Carros__6C9FE07BB6859429");

                entity.HasIndex(e => e.Placa, "UQ__Carros__8310F99DD927F81F")
                    .IsUnique();

                entity.Property(e => e.Cor)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Municipio)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Placa)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
