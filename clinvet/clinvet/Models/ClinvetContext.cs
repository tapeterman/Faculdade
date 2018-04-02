using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace clinvet.Models
{
    public partial class ClinvetContext : DbContext
    {
        public virtual DbSet<AgendamentoConsulta> AgendamentoConsulta { get; set; }
        public virtual DbSet<Anamnese> Anamnese { get; set; }
        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<ContasAPagar> ContasAPagar { get; set; }
        public virtual DbSet<FichaAnimal> FichaAnimal { get; set; }
        public virtual DbSet<FormaDePagamento> FormaDePagamento { get; set; }
        public virtual DbSet<Fornecedor> Fornecedor { get; set; }
        public virtual DbSet<FornecedorProdutoServico> FornecedorProdutoServico { get; set; }
        public virtual DbSet<Funcionario> Funcionario { get; set; }
        public virtual DbSet<ProdutoServico> ProdutoServico { get; set; }
        public virtual DbSet<ProdutoServicoAgendamentoConsultas> ProdutoServicoAgendamentoConsultas { get; set; }
        public virtual DbSet<ProdutoServicoVendaServico> ProdutoServicoVendaServico { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }
        public virtual DbSet<TipoDeConta> TipoDeConta { get; set; }
        public virtual DbSet<TiposDeVacina> TiposDeVacina { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Vacina> Vacina { get; set; }
        public virtual DbSet<VendaServico> VendaServico { get; set; }
        public virtual DbSet<VendaServicoFormaDePagamento> VendaServicoFormaDePagamento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-RJDVFQT\SQLEXPRESS;Initial Catalog=clinvet;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgendamentoConsulta>(entity =>
            {
                entity.ToTable("agendamento_consulta");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataDeAgendamento)
                    .HasColumnName("data_de_agendamento")
                    .HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Estatus)
                    .IsRequired()
                    .HasColumnName("estatus")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.AgendamentoConsulta)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("agendamento_consulta_1_fk");
            });

            modelBuilder.Entity<Anamnese>(entity =>
            {
                entity.ToTable("anamnese");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Anamnese1)
                    .IsRequired()
                    .HasColumnName("anamnese")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Diagnostico)
                    .IsRequired()
                    .HasColumnName("diagnostico")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.IdFichaAnimal).HasColumnName("id_ficha_animal");

                entity.Property(e => e.Medicamentos)
                    .IsRequired()
                    .HasColumnName("medicamentos")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ProcedimentosRealizados)
                    .IsRequired()
                    .HasColumnName("procedimentos_realizados")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFichaAnimalNavigation)
                    .WithMany(p => p.Anamnese)
                    .HasForeignKey(d => d.IdFichaAnimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("anamnese_1_fk");
            });

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.ToTable("animal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("data_nascimento")
                    .HasColumnType("date");

                entity.Property(e => e.Espécie)
                    .IsRequired()
                    .HasColumnName("espécie")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PesoOuPorte)
                    .IsRequired()
                    .HasColumnName("peso_ou_porte")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Raça)
                    .IsRequired()
                    .HasColumnName("raça")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasColumnName("sexo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Animal)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("animal_1_fk");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("bairro")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("cep")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("cpf")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasColumnName("numero")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasColumnName("rua")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnName("telefone")
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ContasAPagar>(entity =>
            {
                entity.ToTable("contas_a_pagar");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.IdFornecedor).HasColumnName("id_fornecedor");

                entity.Property(e => e.IdTipoDeConta).HasColumnName("id_tipo_de_conta");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("numeric(15, 2)");

                entity.HasOne(d => d.IdFornecedorNavigation)
                    .WithMany(p => p.ContasAPagar)
                    .HasForeignKey(d => d.IdFornecedor)
                    .HasConstraintName("contas_a_pagar_1_fk");

                entity.HasOne(d => d.IdTipoDeContaNavigation)
                    .WithMany(p => p.ContasAPagar)
                    .HasForeignKey(d => d.IdTipoDeConta)
                    .HasConstraintName("contas_a_pagar_2_fk");
            });

            modelBuilder.Entity<FichaAnimal>(entity =>
            {
                entity.ToTable("ficha_animal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdAnimal).HasColumnName("id_animal");

                entity.Property(e => e.PesoPorteAntesDosProcedimentos)
                    .IsRequired()
                    .HasColumnName("peso_porte_antes_dos_procedimentos")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAnimalNavigation)
                    .WithMany(p => p.FichaAnimal)
                    .HasForeignKey(d => d.IdAnimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ficha_animal_1_fk");
            });

            modelBuilder.Entity<FormaDePagamento>(entity =>
            {
                entity.ToTable("forma_de_pagamento");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Fornecedor>(entity =>
            {
                entity.ToTable("fornecedor");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("bairro")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("cep")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("cnpj")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasColumnName("nome_fantasia")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasColumnName("numero")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasColumnName("razao_social")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasColumnName("rua")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnName("telefone")
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FornecedorProdutoServico>(entity =>
            {
                entity.HasKey(e => new { e.IdFornecedor, e.IdProduto });

                entity.ToTable("fornecedor_produto_servico");

                entity.Property(e => e.IdFornecedor).HasColumnName("id_fornecedor");

                entity.Property(e => e.IdProduto).HasColumnName("id_produto");

                entity.HasOne(d => d.IdFornecedorNavigation)
                    .WithMany(p => p.FornecedorProdutoServico)
                    .HasForeignKey(d => d.IdFornecedor)
                    .HasConstraintName("fornecedor_produto_servico_1_fk");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.FornecedorProdutoServico)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("fornecedor_produto_servico_2_fk");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.ToTable("funcionario");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("bairro")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("cep")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("cpf")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Funcao)
                    .IsRequired()
                    .HasColumnName("funcao")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasColumnName("id_usuario")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasColumnName("numero")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Pis)
                    .IsRequired()
                    .HasColumnName("pis")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasColumnName("rg")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasColumnName("rua")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnName("telefone")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.TituloDeEleitor)
                    .IsRequired()
                    .HasColumnName("titulo_de_eleitor")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Funcionario)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("funcionario_fk_1");
            });

            modelBuilder.Entity<ProdutoServico>(entity =>
            {
                entity.ToTable("produto_servico");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdTipo).HasColumnName("id_tipo");

                entity.Property(e => e.Lote)
                    .IsRequired()
                    .HasColumnName("lote")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasColumnName("marca")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrecoDeCompra)
                    .HasColumnName("preco_de_compra")
                    .HasColumnType("numeric(15, 2)");

                entity.Property(e => e.PrecoDeVenda)
                    .HasColumnName("preco_de_venda")
                    .HasColumnType("numeric(15, 2)");

                entity.Property(e => e.Validade)
                    .HasColumnName("validade")
                    .HasColumnType("date");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.ProdutoServico)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("produto_servico_1_fk");
            });

            modelBuilder.Entity<ProdutoServicoAgendamentoConsultas>(entity =>
            {
                entity.HasKey(e => new { e.IdProdutoServico, e.IdAgendamentoConsulta });

                entity.ToTable("produto_servico_agendamento_consultas");

                entity.Property(e => e.IdProdutoServico).HasColumnName("id_produto_servico");

                entity.Property(e => e.IdAgendamentoConsulta).HasColumnName("id_agendamento_consulta");

                entity.HasOne(d => d.IdAgendamentoConsultaNavigation)
                    .WithMany(p => p.ProdutoServicoAgendamentoConsultas)
                    .HasForeignKey(d => d.IdAgendamentoConsulta)
                    .HasConstraintName("produto_serviço_agendamento_consultas_2_fk");

                entity.HasOne(d => d.IdProdutoServicoNavigation)
                    .WithMany(p => p.ProdutoServicoAgendamentoConsultas)
                    .HasForeignKey(d => d.IdProdutoServico)
                    .HasConstraintName("produto_serviço_agendamento_consultas_1_fk");
            });

            modelBuilder.Entity<ProdutoServicoVendaServico>(entity =>
            {
                entity.HasKey(e => new { e.IdProdutoServico, e.IdVendaServico });

                entity.ToTable("produto_servico_venda_servico");

                entity.Property(e => e.IdProdutoServico).HasColumnName("id_produto_servico");

                entity.Property(e => e.IdVendaServico).HasColumnName("id_venda_servico");

                entity.Property(e => e.QuantidadeProduto).HasColumnName("quantidade_produto");

                entity.Property(e => e.ValorProduto)
                    .HasColumnName("valor_produto")
                    .HasColumnType("numeric(15, 2)");

                entity.HasOne(d => d.IdProdutoServicoNavigation)
                    .WithMany(p => p.ProdutoServicoVendaServico)
                    .HasForeignKey(d => d.IdProdutoServico)
                    .HasConstraintName("produto_servico_venda_servico_1_fk");

                entity.HasOne(d => d.IdVendaServicoNavigation)
                    .WithMany(p => p.ProdutoServicoVendaServico)
                    .HasForeignKey(d => d.IdVendaServico)
                    .HasConstraintName("produto_servico_venda_servico_2_fk");
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.ToTable("tipo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoDeConta>(entity =>
            {
                entity.ToTable("tipo_de_conta");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposDeVacina>(entity =>
            {
                entity.ToTable("tipos_de_vacina");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Login);

                entity.ToTable("usuario");

                entity.Property(e => e.Login)
                    .HasColumnName("login")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vacina>(entity =>
            {
                entity.ToTable("vacina");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Custo)
                    .HasColumnName("custo")
                    .HasColumnType("numeric(15, 2)");

                entity.Property(e => e.Fornecedor)
                    .IsRequired()
                    .HasColumnName("fornecedor")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdFichaAnimal).HasColumnName("id_ficha_animal");

                entity.Property(e => e.IdTiposDeVacina).HasColumnName("id_tipos_de_vacina");

                entity.Property(e => e.Lote)
                    .IsRequired()
                    .HasColumnName("lote")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasColumnName("marca")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Validade)
                    .HasColumnName("validade")
                    .HasColumnType("date");

                entity.HasOne(d => d.IdFichaAnimalNavigation)
                    .WithMany(p => p.Vacina)
                    .HasForeignKey(d => d.IdFichaAnimal)
                    .HasConstraintName("vacina_1_fk");

                entity.HasOne(d => d.IdTiposDeVacinaNavigation)
                    .WithMany(p => p.Vacina)
                    .HasForeignKey(d => d.IdTiposDeVacina)
                    .HasConstraintName("vacina_2_fk");
            });

            modelBuilder.Entity<VendaServico>(entity =>
            {
                entity.ToTable("venda_servico");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataServico)
                    .HasColumnName("data_servico")
                    .HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdFuncionario).HasColumnName("id_funcionario");

                entity.Property(e => e.ValorTotal)
                    .HasColumnName("valor_total")
                    .HasColumnType("numeric(15, 2)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.VendaServico)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("venda_servico_2_fk");

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.VendaServico)
                    .HasForeignKey(d => d.IdFuncionario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("venda_servico_1_fk");
            });

            modelBuilder.Entity<VendaServicoFormaDePagamento>(entity =>
            {
                entity.HasKey(e => new { e.IdFormaDePagamento, e.IdVendaServico });

                entity.ToTable("venda_servico_forma_de_pagamento");

                entity.Property(e => e.IdFormaDePagamento).HasColumnName("id_forma_de_pagamento");

                entity.Property(e => e.IdVendaServico).HasColumnName("id_venda_servico");

                entity.HasOne(d => d.IdFormaDePagamentoNavigation)
                    .WithMany(p => p.VendaServicoFormaDePagamento)
                    .HasForeignKey(d => d.IdFormaDePagamento)
                    .HasConstraintName("venda_servico_forma_de_pagamento_2_fk");

                entity.HasOne(d => d.IdVendaServicoNavigation)
                    .WithMany(p => p.VendaServicoFormaDePagamento)
                    .HasForeignKey(d => d.IdVendaServico)
                    .HasConstraintName("venda_servico_forma_de_pagamento_1_fk");
            });
        }
    }
}
