﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApp_tg_bot2.TgBotCat.Model.Chat;

namespace WebApp_tg_bot2.Migrations.PorterDbContext_PostgresMigrations
{
    [DbContext(typeof(PorterDbContext_Postgres))]
    [Migration("20190207211251_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("PorterOfChat.Bot.Model.cChat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountMembers");

                    b.Property<string>("Dad");

                    b.Property<string>("DateDad");

                    b.Property<string>("DatePidor");

                    b.Property<string>("FullDad");

                    b.Property<string>("FullPidor");

                    b.Property<long>("Id_tg");

                    b.Property<string>("Name");

                    b.Property<string>("Pidor");

                    b.HasKey("Id");

                    b.ToTable("chats");
                });

            modelBuilder.Entity("PorterOfChat.Bot.Model.cUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountDad");

                    b.Property<int>("CountPidor");

                    b.Property<string>("FullName");

                    b.Property<bool>("GenderFemale");

                    b.Property<int>("Id_tg");

                    b.Property<string>("Name");

                    b.Property<int?>("cChatId");

                    b.HasKey("Id");

                    b.HasIndex("cChatId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("WebApp_tg_bot2.TgBotCat.Model.MessageLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Date");

                    b.Property<string>("FullName");

                    b.Property<string>("Text");

                    b.Property<int?>("chatId");

                    b.Property<int>("id_tg");

                    b.Property<int?>("userId");

                    b.HasKey("Id");

                    b.HasIndex("chatId");

                    b.HasIndex("userId");

                    b.ToTable("MessagesLogs");
                });

            modelBuilder.Entity("PorterOfChat.Bot.Model.cUser", b =>
                {
                    b.HasOne("PorterOfChat.Bot.Model.cChat", "cChat")
                        .WithMany("users")
                        .HasForeignKey("cChatId");
                });

            modelBuilder.Entity("WebApp_tg_bot2.TgBotCat.Model.MessageLog", b =>
                {
                    b.HasOne("PorterOfChat.Bot.Model.cChat", "chat")
                        .WithMany()
                        .HasForeignKey("chatId");

                    b.HasOne("PorterOfChat.Bot.Model.cUser", "user")
                        .WithMany()
                        .HasForeignKey("userId");
                });
#pragma warning restore 612, 618
        }
    }
}
