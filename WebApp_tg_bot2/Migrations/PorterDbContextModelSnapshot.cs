﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp_tg_bot2.TgBotCat.Model.Chat;

namespace WebApp_tg_bot2.Migrations
{
    [DbContext(typeof(PorterDbContext_MS))]
    partial class PorterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PorterOfChat.Bot.Model.cChat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
