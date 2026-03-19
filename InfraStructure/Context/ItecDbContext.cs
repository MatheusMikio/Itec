using Domain.entities;
using Domain.entities.baseEntities;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Context;

public partial class ItecDbContext : DbContext
{
    public DbSet<Agendamento> Agendamentos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Fatura> Faturas { get; set; }
    public DbSet<Servico> Servicos { get; set; }
    public DbSet<Tecnico> Tecnicos { get; set; }

    public ItecDbContext(DbContextOptions<ItecDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaseModel>(entity =>
        {
            entity.UseTpcMappingStrategy();
            entity.HasKey(x => x.Id);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("Clientes");
            entity.Property(x => x.Nome).IsRequired();
            entity.Property(x => x.SenhaHash).IsRequired();
            entity.Property(x => x.CPF).IsRequired();
            entity.Property(x => x.Role).IsRequired();

            entity.Ignore(x => x.HistoricoAgendameto);

            entity.OwnsOne(x => x.Contato, contato =>
            {
                contato.Property(c => c.Telefone)
                    .HasColumnName("Telefone")
                    .IsRequired();
                contato.Property(c => c.Email)
                    .HasColumnName("Email")
                    .IsRequired();
            });

            entity.OwnsOne(x => x.Endereco, endereco =>
            {
                endereco.Property(e => e.Rua).HasColumnName("Rua").IsRequired();
                endereco.Property(e => e.Numero).HasColumnName("Numero").IsRequired();
                endereco.Property(e => e.Bairro).HasColumnName("Bairro").IsRequired();
                endereco.Property(e => e.Estado).HasColumnName("Estado").IsRequired();
                endereco.Property(e => e.Pais).HasColumnName("Pais").IsRequired();
            });

            entity.OwnsOne(x => x.FormaPagamento, formaPagamento =>
            {
                formaPagamento.Property(f => f.ChavePix)
                    .HasColumnName("ChavePix");

                formaPagamento.OwnsOne(f => f.Cartao, cartao =>
                {
                    cartao.Property(c => c.Numero)
                        .HasColumnName("CartaoNumero")
                        .IsRequired();
                    cartao.Property(c => c.Bandeira)
                        .HasColumnName("CartaoBandeira")
                        .IsRequired();
                    cartao.Property(c => c.Validade)
                        .HasColumnName("CartaoValidade")
                        .IsRequired();
                });
            });
        });

        modelBuilder.Entity<Tecnico>(entity =>
        {
            entity.ToTable("Tecnicos");
            entity.Property(x => x.Nome).IsRequired();
            entity.Property(x => x.SenhaHash).IsRequired();
            entity.Property(x => x.CpfCnpj).IsRequired();
            entity.Property(x => x.Descricao).IsRequired();
            entity.Property(x => x.Role).IsRequired();

            entity.Ignore(x => x.HistoricoAgendameto);

            entity.OwnsOne(x => x.Contato, contato =>
            {
                contato.Property(c => c.Telefone)
                    .HasColumnName("Telefone")
                    .IsRequired();
                contato.Property(c => c.Email)
                    .HasColumnName("Email")
                    .IsRequired();
            });

            entity.OwnsOne(x => x.Endereco, endereco =>
            {
                endereco.Property(e => e.Rua).HasColumnName("Rua").IsRequired();
                endereco.Property(e => e.Numero).HasColumnName("Numero").IsRequired();
                endereco.Property(e => e.Bairro).HasColumnName("Bairro").IsRequired();
                endereco.Property(e => e.Estado).HasColumnName("Estado").IsRequired();
                endereco.Property(e => e.Pais).HasColumnName("Pais").IsRequired();
            });

            entity.OwnsOne(x => x.FormaPagamento, formaPagamento =>
            {
                formaPagamento.Property(f => f.ChavePix)
                    .HasColumnName("ChavePix");

                formaPagamento.OwnsOne(f => f.Cartao, cartao =>
                {
                    cartao.Property(c => c.Numero)
                        .HasColumnName("CartaoNumero")
                        .IsRequired();
                    cartao.Property(c => c.Bandeira)
                        .HasColumnName("CartaoBandeira")
                        .IsRequired();
                    cartao.Property(c => c.Validade)
                        .HasColumnName("CartaoValidade")
                        .IsRequired();
                });
            });

            entity.HasMany(x => x.Servicos)
                .WithOne(x => x.Tecnico)
                .HasForeignKey(x => x.TecnicoId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Servico>(entity =>
        {
            entity.ToTable("Servicos");
            entity.Property(x => x.Nome).IsRequired();
            entity.Property(x => x.Descricao).IsRequired();
            entity.Property(x => x.MinPreco).HasPrecision(18, 2);
            entity.Property(x => x.MaxPreco).HasPrecision(18, 2);
            entity.Property(x => x.Categoria).IsRequired();
        });

        modelBuilder.Entity<Fatura>(entity =>
        {
            entity.ToTable("Faturas");
            entity.Property(x => x.MesReferencia).IsRequired();
            entity.Property(x => x.DataVencimento).IsRequired();
            entity.Property(x => x.ValorBruto).HasPrecision(18, 2);
            entity.Property(x => x.ValorComissao).HasPrecision(18, 2);
            entity.Property(x => x.Status).IsRequired();

            entity.HasOne(x => x.Tecnico)
                .WithMany()
                .HasForeignKey(x => x.TecnicoId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Agendamento>(entity =>
        {
            entity.ToTable("Agendamentos");
            entity.Property(x => x.Data).IsRequired();
            entity.Property(x => x.Valor).HasPrecision(18, 2);
            entity.Property(x => x.Status).IsRequired();

            entity.HasOne(x => x.Tecnico)
                .WithMany()
                .HasForeignKey(x => x.TecnicoId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.Cliente)
                .WithMany()
                .HasForeignKey(x => x.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.Servico)
                .WithMany()
                .HasForeignKey(x => x.ServicoId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.Fatura)
                .WithMany(x => x.Agendamentos)
                .HasForeignKey(x => x.FaturaId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
