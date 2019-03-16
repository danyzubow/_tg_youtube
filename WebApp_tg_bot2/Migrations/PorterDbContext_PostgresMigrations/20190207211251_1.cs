using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebApp_tg_bot2.Migrations.PorterDbContext_PostgresMigrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    Id_tg = table.Column<long>(nullable: false),
                    DatePidor = table.Column<string>(nullable: true),
                    Pidor = table.Column<string>(nullable: true),
                    FullPidor = table.Column<string>(nullable: true),
                    Dad = table.Column<string>(nullable: true),
                    FullDad = table.Column<string>(nullable: true),
                    DateDad = table.Column<string>(nullable: true),
                    CountMembers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    CountPidor = table.Column<int>(nullable: false),
                    CountDad = table.Column<int>(nullable: false),
                    Id_tg = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    GenderFemale = table.Column<bool>(nullable: false),
                    cChatId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_chats_cChatId",
                        column: x => x.cChatId,
                        principalTable: "chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MessagesLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    chatId = table.Column<int>(nullable: true),
                    userId = table.Column<int>(nullable: true),
                    id_tg = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessagesLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessagesLogs_chats_chatId",
                        column: x => x.chatId,
                        principalTable: "chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MessagesLogs_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MessagesLogs_chatId",
                table: "MessagesLogs",
                column: "chatId");

            migrationBuilder.CreateIndex(
                name: "IX_MessagesLogs_userId",
                table: "MessagesLogs",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_users_cChatId",
                table: "users",
                column: "cChatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessagesLogs");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "chats");
        }
    }
}
