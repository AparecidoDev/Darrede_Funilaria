using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FunilariaDev.Domains;
using Flunt.Notifications;

namespace FunilariaDev.Context
{
    /// <Sumary>
    /// Classe responsável pelo contexto do projeto
    /// faz a cominicação com a Apie e o banco de dados
    /// </Sumary>
    public class FunilariaContext : DbContext
        {

            public DbSet<User> Users { get; set; }

            public DbSet<Car> Cars { get; set; }

            public DbSet<Brand> Brands { get; set; }

            public DbSet<Model> Templates { get; set; }

            public DbSet<Budget> Budgets { get; set; }

            public DbSet<Service> Services { get; set; }

            /// <Sumary>
            /// Define as Opções  de construção do banco de dados 
            /// </Sumary>
            /// <param name="optionsBuilder"> Objeto com as configurações  definidas </param>
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                //Aparecido senai 
             //optionsBuilder.UseSqlServer("Server=DESKTOP-0L2N0T2; Database=FunilariaDEV; user id=sa; pwd=senai@132;");

            //Enzzo 
             optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=FunilariaDEV; user Id=sa;pwd=senai@132;");
            
            //outra opção
           // optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=FunilariaDEV; user id=sa; pwd=senai@132;");
                base.OnConfiguring(optionsBuilder);
            }

             

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {

              //iGNORAMOS que a library de notificações do Flunt seja gerada automaticamente no banco
            modelBuilder.Ignore<Notification>();

            #region Mapeamento da tabela de usuários
            //mudamos o nome das tabelas se necessários
            modelBuilder.Entity<User>().ToTable("Users");

            //Determinar chaves
            modelBuilder.Entity<User>().Property(x => x.IdUser);

            //Nome
            modelBuilder.Entity<User>().Property(c => c.Name).HasMaxLength(40);
            modelBuilder.Entity<User>().Property(x => x.Name).HasColumnType("varchar(40)");
            modelBuilder.Entity<User>().Property(x => x.Name).IsRequired();

            //Email
            modelBuilder.Entity<User>().Property(c => c.Email).HasMaxLength(100);
            modelBuilder.Entity<User>().Property(x => x.Email).HasColumnType("varchar(100)");
            modelBuilder.Entity<User>().Property(x => x.Email).IsRequired();
            modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();

            //Telefone
            modelBuilder.Entity<User>().Property(c => c.Phone).HasMaxLength(11);
            modelBuilder.Entity<User>().Property(x => x.Phone).HasColumnType("BIGINT");
            modelBuilder.Entity<User>().Property(x => x.Phone).IsRequired();
            modelBuilder.Entity<User>().HasIndex(x => x.Phone).IsUnique();

            //Senha
            modelBuilder.Entity<User>().Property(c => c.Password).HasMaxLength(200);
            modelBuilder.Entity<User>().Property(x => x.Password).HasColumnType("varchar(200)");
            modelBuilder.Entity<User>().Property(x => x.Password).IsRequired();

            //ImagemPlaca
            modelBuilder.Entity<User>().Property(c => c.ImagePlate).HasMaxLength(255);
            modelBuilder.Entity<User>().Property(x => x.ImagePlate).HasColumnType("varchar(255)");

            //Placa
            modelBuilder.Entity<User>().Property(c => c.Plate).HasMaxLength(255);
            modelBuilder.Entity<User>().Property(x => x.Plate).HasColumnType("varchar(255)");




            #endregion

            #region Mapeamento de tabelas de Carros
            //mudamos o nome das tabelas se necessários
            modelBuilder.Entity<Car>().ToTable("Cars");

            //Determinar chaves
            modelBuilder.Entity<Car>().Property(x => x.IdCar);

            //Modelo
            modelBuilder.Entity<Car>().Property(c => c.Model).HasMaxLength(70);
            modelBuilder.Entity<Car>().Property(x => x.Model).HasColumnType("varchar(70)");
            modelBuilder.Entity<Car>().Property(x => x.Model).IsRequired();

            //Marca
            modelBuilder.Entity<Car>().Property(c => c.Brand).HasMaxLength(40);
            modelBuilder.Entity<Car>().Property(x => x.Brand).HasColumnType("varchar(40)");
            modelBuilder.Entity<Car>().Property(x => x.Brand).IsRequired();

            //Cor
            modelBuilder.Entity<Car>().Property(c => c.Color).HasMaxLength(30);
            modelBuilder.Entity<Car>().Property(x => x.Color).HasColumnType("varchar(30)");
            modelBuilder.Entity<Car>().Property(x => x.Color).IsRequired();

            //PlacaCarro
            modelBuilder.Entity<Car>().Property(c => c.Plate).HasMaxLength(11);
            modelBuilder.Entity<Car>().Property(x => x.Plate).HasColumnType("varchar(11)");
            modelBuilder.Entity<Car>().Property(x => x.Plate).IsRequired();
            modelBuilder.Entity<Car>().HasIndex(x => x.Plate).IsUnique();

            //Ano
            modelBuilder.Entity<Car>().Property(c => c.Year).HasMaxLength(20);
            modelBuilder.Entity<Car>().Property(x => x.Year).HasColumnType("varchar(20)");
            modelBuilder.Entity<Car>().Property(x => x.Year).IsRequired();

            //Municipio
            modelBuilder.Entity<Car>().Property(c => c.City).HasMaxLength(60);
            modelBuilder.Entity<Car>().Property(x => x.City).HasColumnType("varchar(60)");


            #endregion


            #region Mapeamento da tabela de marcas
            //mudamos o nome das tabelas se necessários
            modelBuilder.Entity<Brand>().ToTable("Brands");

            //Determinar chaves
            modelBuilder.Entity<Brand>().Property(x => x.IdBrand);

            //Marca
            modelBuilder.Entity<Brand>().Property(c => c.NameBrand).HasMaxLength(70);
            modelBuilder.Entity<Brand>().Property(x => x.NameBrand).HasColumnType("varchar(70)");
            modelBuilder.Entity<Brand>().Property(x => x.NameBrand).IsRequired();
            modelBuilder.Entity<Brand>().HasIndex(x => x.NameBrand).IsUnique();

            #endregion

            #region Mapeamento da tabela de modelos
            //mudamos o nome daa tabela se necessário
            modelBuilder.Entity<Model>().ToTable("templates");

            //Determina as chaves ID
            modelBuilder.Entity<Model>().Property(x => x.IdModel);

            //Modelo
            modelBuilder.Entity<Model>().Property(x => x.NameModel).HasMaxLength(100);
            modelBuilder.Entity<Model>().Property(x => x.NameModel).HasColumnType("varchar(100)");
            modelBuilder.Entity<Model>().Property(x => x.NameModel).IsRequired();
            modelBuilder.Entity<Model>().HasIndex(x => x.NameModel).IsUnique();

            #endregion

            #region Mapeamento da tabela de orçamento
            //mudamos o nome daa tabela se necessário
            modelBuilder.Entity<Budget>().ToTable("Budgets");

            //Determina as chaves ID
            modelBuilder.Entity<Budget>().Property(x => x.IdBudget);

            //Modelo
            modelBuilder.Entity<Budget>().Property(x => x.TotalValue).HasColumnType("float");
            modelBuilder.Entity<Budget>().Property(x => x.TotalValue).IsRequired();


            #endregion

            #region Mapeamento da tabela de serviços

            modelBuilder.Entity<Service>().ToTable("Services");

            modelBuilder.Entity<Service>().Property(x => x.IdService);

            modelBuilder.Entity<Service>().Property(x => x.Problem).HasMaxLength(200);
            modelBuilder.Entity<Service>().Property(x => x.Problem).HasColumnType("varchar(200)");
            modelBuilder.Entity<Service>().Property(x => x.Problem).IsRequired();
            modelBuilder.Entity<Service>().HasIndex(x => x.Problem).IsUnique();


            #endregion



            base.OnModelCreating(modelBuilder); 
        }
        }
}
