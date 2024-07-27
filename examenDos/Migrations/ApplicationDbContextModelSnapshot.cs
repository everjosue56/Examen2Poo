﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using examenDos.DataBase;

#nullable disable

namespace examenDos.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("examenDos.DataBase.Entities.AmortizationDetailEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<int>("Days")
                        .HasColumnType("int")
                        .HasColumnName("days");

                    b.Property<int>("InstallmentNumber")
                        .HasColumnType("int")
                        .HasColumnName("installmentNumber");

                    b.Property<decimal>("Interest")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("interest");

                    b.Property<decimal>("LevelPaymentWithSVSD")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("levelPaymentWithSVSD");

                    b.Property<decimal>("LevelPaymentWithoutSVSD")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("levelPaymentWithoutSVSD");

                    b.Property<Guid>("LoanId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("loanId");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("paymentDate");

                    b.Property<decimal>("Principal")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("principal");

                    b.Property<decimal>("PrincipalBalance")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("principalBalance");

                    b.HasKey("Id");

                    b.HasIndex("LoanId");

                    b.ToTable("AmortizationDetails");
                });

            modelBuilder.Entity("examenDos.DataBase.Entities.CustomersEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<decimal>("CommissionRate")
                        .HasMaxLength(100)
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("commissionRate");

                    b.Property<DateTime>("DisbursemenDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("disbursementDate");

                    b.Property<DateTime>("FirstPayment")
                        .HasColumnType("datetime2")
                        .HasColumnName("firstPaymentDate");

                    b.Property<int>("InteresRate")
                        .HasColumnType("int")
                        .HasColumnName("interesRate");

                    b.Property<int>("Term")
                        .HasColumnType("int")
                        .HasColumnName("term");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("customers", "dbo");
                });

            modelBuilder.Entity("examenDos.DataBase.Entities.LoanEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("amount");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("customerId");

                    b.Property<DateTime>("DisbursementDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("disbursementDate");

                    b.Property<decimal>("InterestRate")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("interestRate");

                    b.Property<int>("Term")
                        .HasColumnType("int")
                        .HasColumnName("term");

                    b.HasKey("Id");

                    b.ToTable("loans", "dbo");
                });

            modelBuilder.Entity("examenDos.DataBase.Entities.AmortizationDetailEntity", b =>
                {
                    b.HasOne("examenDos.DataBase.Entities.LoanEntity", "Loan")
                        .WithMany()
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Loan");
                });
#pragma warning restore 612, 618
        }
    }
}
