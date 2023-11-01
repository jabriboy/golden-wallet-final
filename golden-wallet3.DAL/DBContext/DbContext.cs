using System;
using System.Collections.Generic;
using golden_wallet3.MODEL;
using Microsoft.EntityFrameworkCore;

namespace golden_wallet3.DAL.DBContext;

public partial class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbContext()
    {
    }

    public DbContext(DbContextOptions<DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Conta> Contas { get; set; }

    public virtual DbSet<Transacao> Transacoes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\jabri\\source\\repos\\golden-wallet3\\golden-wallet3.DAL\\database\\Database1.mdf;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Conta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contas__3214EC07836CF1C0");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Conta)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__Contas__id_user__38996AB5");
        });

        modelBuilder.Entity<Transacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transaco__3214EC0719DFD85B");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IdConta).HasColumnName("id_conta");
            entity.Property(e => e.Tipo)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("tipo");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("valor");

            entity.HasOne(d => d.IdContaNavigation).WithMany(p => p.Transacos)
                .HasForeignKey(d => d.IdConta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacoe__id_co__3B75D760");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07C6C32869");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("nome");
            entity.Property(e => e.Senha)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("senha");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
