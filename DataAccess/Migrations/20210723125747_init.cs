using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dokter",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nama = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pasien",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NIK = table.Column<string>(nullable: false),
                    Nama = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasien", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registrasi",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NoRegistrasi = table.Column<string>(nullable: true),
                    Jadwal = table.Column<DateTime>(nullable: false),
                    IdPasien = table.Column<Guid>(nullable: false),
                    IdDokter = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrasi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registrasi_Dokter_IdDokter",
                        column: x => x.IdDokter,
                        principalTable: "Dokter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrasi_Pasien_IdPasien",
                        column: x => x.IdPasien,
                        principalTable: "Pasien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diagnosa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Keterangan = table.Column<string>(nullable: false),
                    IdRegistrasi = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagnosa_Registrasi_IdRegistrasi",
                        column: x => x.IdRegistrasi,
                        principalTable: "Registrasi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tindakan",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Keterangan = table.Column<string>(nullable: false),
                    IdRegistrasi = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tindakan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tindakan_Registrasi_IdRegistrasi",
                        column: x => x.IdRegistrasi,
                        principalTable: "Registrasi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosa_IdRegistrasi",
                table: "Diagnosa",
                column: "IdRegistrasi");

            migrationBuilder.CreateIndex(
                name: "IX_Pasien_NIK",
                table: "Pasien",
                column: "NIK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registrasi_IdDokter",
                table: "Registrasi",
                column: "IdDokter");

            migrationBuilder.CreateIndex(
                name: "IX_Registrasi_IdPasien",
                table: "Registrasi",
                column: "IdPasien");

            migrationBuilder.CreateIndex(
                name: "IX_Registrasi_NoRegistrasi",
                table: "Registrasi",
                column: "NoRegistrasi",
                unique: true,
                filter: "[NoRegistrasi] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tindakan_IdRegistrasi",
                table: "Tindakan",
                column: "IdRegistrasi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diagnosa");

            migrationBuilder.DropTable(
                name: "Tindakan");

            migrationBuilder.DropTable(
                name: "Registrasi");

            migrationBuilder.DropTable(
                name: "Dokter");

            migrationBuilder.DropTable(
                name: "Pasien");
        }
    }
}
