using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_vivaviatravel2._0.Migrations
{
    public partial class expandDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Hospedagem_HospedagemId",
                table: "Reserva");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Pacote_PacoteId",
                table: "Reserva");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Passagem_PassagemId",
                table: "Reserva");

            migrationBuilder.AlterColumn<int>(
                name: "PassagemId",
                table: "Reserva",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PacoteId",
                table: "Reserva",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HospedagemId",
                table: "Reserva",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Hospedagem_HospedagemId",
                table: "Reserva",
                column: "HospedagemId",
                principalTable: "Hospedagem",
                principalColumn: "HospedagemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Pacote_PacoteId",
                table: "Reserva",
                column: "PacoteId",
                principalTable: "Pacote",
                principalColumn: "PacoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Passagem_PassagemId",
                table: "Reserva",
                column: "PassagemId",
                principalTable: "Passagem",
                principalColumn: "PassagemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Hospedagem_HospedagemId",
                table: "Reserva");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Pacote_PacoteId",
                table: "Reserva");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Passagem_PassagemId",
                table: "Reserva");

            migrationBuilder.AlterColumn<int>(
                name: "PassagemId",
                table: "Reserva",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PacoteId",
                table: "Reserva",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HospedagemId",
                table: "Reserva",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Passagem_PassagemId",
                table: "Reserva",
                column: "PassagemId",
                principalTable: "Passagem",
                principalColumn: "PassagemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
