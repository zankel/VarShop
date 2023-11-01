﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VarShop.Models.Context;

#nullable disable

namespace VarShop.Migrations
{
    [DbContext(typeof(MySQLContext))]
    partial class MySQLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("VarShop.Models.Carrinho", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<long>("ClienteId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Data_Pedido")
                        .HasMaxLength(256)
                        .HasColumnType("datetime(6)");

                    b.Property<float>("Valor_Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.ToTable("Carrinhos");
                });

            modelBuilder.Entity("VarShop.Models.Cliente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("VarShop.Models.Item_Carrinho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<long>("CarrinhoId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProdutoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Quantidade")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Total")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CarrinhoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Itens_Carrinho");
                });

            modelBuilder.Entity("VarShop.Models.Produto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Preco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<long>("VendedorId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("VendedorId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("VarShop.Models.Vendedor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("varchar(18)");

                    b.Property<int>("Comissao")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)");

                    b.Property<string>("Nome_Fantasia")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)");

                    b.Property<string>("Razao_Social")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Vendedores");
                });

            modelBuilder.Entity("VarShop.Models.Carrinho", b =>
                {
                    b.HasOne("VarShop.Models.Cliente", "Cliente")
                        .WithOne("Carrinho")
                        .HasForeignKey("VarShop.Models.Carrinho", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("VarShop.Models.Item_Carrinho", b =>
                {
                    b.HasOne("VarShop.Models.Carrinho", "Carrinho")
                        .WithMany("ItensCarrinho")
                        .HasForeignKey("CarrinhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VarShop.Models.Produto", "Produto")
                        .WithMany("ItensCarrinho")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrinho");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("VarShop.Models.Produto", b =>
                {
                    b.HasOne("VarShop.Models.Vendedor", "Vendedor")
                        .WithMany("Produtos")
                        .HasForeignKey("VendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vendedor");
                });

            modelBuilder.Entity("VarShop.Models.Carrinho", b =>
                {
                    b.Navigation("ItensCarrinho");
                });

            modelBuilder.Entity("VarShop.Models.Cliente", b =>
                {
                    b.Navigation("Carrinho")
                        .IsRequired();
                });

            modelBuilder.Entity("VarShop.Models.Produto", b =>
                {
                    b.Navigation("ItensCarrinho");
                });

            modelBuilder.Entity("VarShop.Models.Vendedor", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
