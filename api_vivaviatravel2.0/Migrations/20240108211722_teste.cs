using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_vivaviatravel2._0.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Cliente_ClienteId",
                table: "Reserva");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Passagem_PassagemId",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "ReservaId",
                table: "Passagem");

            migrationBuilder.DropColumn(
                name: "ReservaId",
                table: "Cliente");

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
                name: "ClienteId",
                table: "Reserva",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImagemUrl",
                table: "Passagem",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Cliente_ClienteId",
                table: "Reserva",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Passagem_PassagemId",
                table: "Reserva",
                column: "PassagemId",
                principalTable: "Passagem",
                principalColumn: "PassagemId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Cliente_ClienteId",
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
                name: "ClienteId",
                table: "Reserva",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ImagemUrl",
                table: "Passagem",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservaId",
                table: "Passagem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservaId",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Cliente_ClienteId",
                table: "Reserva",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Passagem_PassagemId",
                table: "Reserva",
                column: "PassagemId",
                principalTable: "Passagem",
                principalColumn: "PassagemId");
        }
    }
}
