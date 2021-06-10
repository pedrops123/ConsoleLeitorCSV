using System;
using Microsoft.EntityFrameworkCore;
using Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using LeitorJSON;

namespace ContextDB {
    public class ContextoDB : DbContext {
        public ContextoDB(){}

        // DB Sets
        public DbSet<tblCliente> tabelaCliente { get; set; }
        public DbSet<tblPais> tabelaPais { get; set; }
        public DbSet<tblPedido> tabelaPedido { get; set; }
        public DbSet<tblQuestao> tabelaQuestao { get; set; }
        public DbSet<tblQuestaoOpcao> tabelaQuestaoOpcao { get; set; }
        public DbSet<tblResposta> tabelaResposta { get; set; }
        public DbSet<tblSexo> tabelaSexo { get; set; }

        // Configuration - usa conection strings
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(LeitorJson.GetParametersJson().ConnectionString);
        }

        // Mapeamento do BD
        protected override void OnModelCreating(ModelBuilder builder) {

            //Configuration Sexo
            builder.Entity<tblSexo>(e => {
                 e.HasKey(r => r.CodSexo);
                 e.HasMany(r=>r.clientes).WithOne(r=>r.sexo);
                 e.ToTable("tblSexo");
            });

             //Configuration Pais
            builder.Entity<tblPais>(e => {
                 e.HasKey(r => r.CodPais);
                 e.HasMany(r => r.clientes)
                 .WithOne( r=> r.pais);
                 e.ToTable("tblPais");
            });

           //Configuration Cliente
            builder.Entity<tblCliente>(e => {

                 e.HasKey(r => r.CodCliente);
                 
                 e.HasOne(r => r.pais )
                 .WithMany(r => r.clientes)
                 .HasForeignKey(r => r.CodPais);

                 e.HasOne(r => r.sexo)
                 .WithMany( r => r.clientes)
                 .HasForeignKey(r=>r.CodSexo);

                 e.HasMany(r=>r.pedidos)
                 .WithOne(r => r.cliente);

                 e.HasMany(r=>r.respostas).WithOne(r => r.cliente);
                 e.ToTable("tblCliente");
            });

            //Configuration Pedido
            builder.Entity<tblPedido>(r=>{
                r.HasKey(r=>r.CodPedido);
                r.HasOne(r => r.cliente)
                .WithMany(r=>r.pedidos)
                .HasForeignKey(r=>r.CodCliente);
                r.ToTable("tblPedido");
            });


            //Configuration Questao
            builder.Entity<tblQuestao>(r=>{
                r.HasKey(r => r.CodQuestao);
                r.HasMany(r => r.opcoes)
                .WithOne(r =>r.questao);
                r.ToTable("tblQuestao");
            });
            
            //Configuration Questao Opção
            builder.Entity<tblQuestaoOpcao>(r=>{
                r.HasKey(r => r.CodQuestaoOpcao);
                r.HasOne(r => r.questao)
                .WithMany(r => r.opcoes)
                .HasForeignKey(r=>r.CodQuestao);
                r.ToTable("tblQuestaoOpcao");
            });


            //Configuration Resposta
            builder.Entity<tblResposta>(r=>{
                r.HasKey(r=>r.CodResposta);

                r.HasOne(r=>r.cliente)
                .WithMany(r => r.respostas)
                .HasForeignKey(r=>r.CodCliente);
                r.ToTable("tblResposta");
            });


        }

    }

}