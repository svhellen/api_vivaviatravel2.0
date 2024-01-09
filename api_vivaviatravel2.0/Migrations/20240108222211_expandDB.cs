using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_vivaviatravel2._0.Migrations
{
    public partial class expandDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HospedagemId",
                table: "Reserva",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PacoteId",
                table: "Reserva",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Hospedagem",
                columns: table => new
                {
                    HospedagemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeHotel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localizacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avaliacao = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    PrecoDiaria = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ImagemUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospedagem", x => x.HospedagemId);
                });

            migrationBuilder.CreateTable(
                name: "Pacote",
                columns: table => new
                {
                    PacoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PercentDesconto = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ImagemUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    PassagemId = table.Column<int>(type: "int", nullable: false),
                    HospedagemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacote", x => x.PacoteId);
                    table.ForeignKey(
                        name: "FK_Pacote_Hospedagem_HospedagemId",
                        column: x => x.HospedagemId,
                        principalTable: "Hospedagem",
                        principalColumn: "HospedagemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pacote_Passagem_PassagemId",
                        column: x => x.PassagemId,
                        principalTable: "Passagem",
                        principalColumn: "PassagemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_HospedagemId",
                table: "Reserva",
                column: "HospedagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_PacoteId",
                table: "Reserva",
                column: "PacoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacote_HospedagemId",
                table: "Pacote",
                column: "HospedagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacote_PassagemId",
                table: "Pacote",
                column: "PassagemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Hospedagem_HospedagemId",
                table: "Reserva",
                column: "HospedagemId",
                principalTable: "Hospedagem",
                principalColumn: "HospedagemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Pacote_PacoteId",
                table: "Reserva",
                column: "PacoteId",
                principalTable: "Pacote",
                principalColumn: "PacoteId",
                onDelete: ReferentialAction.NoAction);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Hospedagem_HospedagemId",
                table: "Reserva");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Pacote_PacoteId",
                table: "Reserva");

            migrationBuilder.DropTable(
                name: "Pacote");

            migrationBuilder.DropTable(
                name: "Hospedagem");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_HospedagemId",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_PacoteId",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "HospedagemId",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "PacoteId",
                table: "Reserva");
        }
    }
}
