using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQL.Photos.Api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "CreatedAt", "Name", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 22, 12, 33, 55, 248, DateTimeKind.Local).AddTicks(7997), "Robak, Miklaś and Augustyniak", "https://korneli.com", 7 },
                    { 28, new DateTime(2019, 12, 26, 14, 34, 36, 888, DateTimeKind.Local).AddTicks(3797), "Wasiak, Pietrzak and Niemiec", "https://emilia.org", 8 },
                    { 27, new DateTime(2020, 2, 21, 4, 58, 58, 94, DateTimeKind.Local).AddTicks(7500), "Stanek Inc", "http://cyryl.pl", 10 },
                    { 26, new DateTime(2020, 4, 12, 19, 39, 40, 630, DateTimeKind.Local).AddTicks(7044), "Wiącek, Kogut and Dudziński", "http://joanna.org", 8 },
                    { 25, new DateTime(2020, 2, 13, 8, 38, 5, 136, DateTimeKind.Local).AddTicks(916), "Trzeciak, Kozieł and Szeląg", "https://teodora.com.pl", 4 },
                    { 24, new DateTime(2020, 8, 15, 0, 49, 4, 973, DateTimeKind.Local).AddTicks(9812), "Koza, Stolarski and Kołodziejski", "https://alina.net", 9 },
                    { 23, new DateTime(2020, 10, 5, 6, 18, 49, 179, DateTimeKind.Local).AddTicks(1503), "Białkowski Group", "https://bibianna.com", 9 },
                    { 22, new DateTime(2020, 2, 28, 9, 55, 25, 73, DateTimeKind.Local).AddTicks(8036), "Kujawski - Dobrowolski", "https://serafin.org", 2 },
                    { 21, new DateTime(2020, 10, 3, 11, 9, 42, 864, DateTimeKind.Local).AddTicks(1299), "Jezierski LLC", "https://florian.net", 4 },
                    { 20, new DateTime(2019, 10, 29, 21, 51, 39, 783, DateTimeKind.Local).AddTicks(6787), "Niewiadomski - Raczyński", "https://cyrus.net", 3 },
                    { 19, new DateTime(2019, 12, 14, 23, 53, 49, 311, DateTimeKind.Local).AddTicks(1565), "Sosnowski LLC", "http://maksym.com.pl", 9 },
                    { 18, new DateTime(2020, 2, 3, 10, 22, 10, 627, DateTimeKind.Local).AddTicks(1615), "Wiśniewski, Trzciński and Banaś", "http://ewa.pl", 2 },
                    { 17, new DateTime(2020, 5, 20, 19, 5, 40, 421, DateTimeKind.Local).AddTicks(3372), "Kogut - Rogalski", "http://modest.com", 6 },
                    { 16, new DateTime(2020, 3, 5, 15, 15, 3, 149, DateTimeKind.Local).AddTicks(5053), "Markiewicz - Wiśniewski", "http://konstanty.net", 6 },
                    { 15, new DateTime(2020, 4, 22, 20, 20, 33, 699, DateTimeKind.Local).AddTicks(4357), "Stachowicz Inc", "http://arkadiusz.com.pl", 10 },
                    { 14, new DateTime(2020, 5, 11, 1, 35, 35, 176, DateTimeKind.Local).AddTicks(1290), "Paszkowski, Zabłocki and Urbaniak", "https://paulina.com.pl", 1 },
                    { 13, new DateTime(2019, 12, 21, 19, 42, 29, 638, DateTimeKind.Local).AddTicks(9837), "Mielczarek, Kucharczyk and Kowalewski", "https://wanesa.pl", 4 },
                    { 12, new DateTime(2020, 5, 18, 22, 17, 55, 894, DateTimeKind.Local).AddTicks(266), "Janicki - Jagielski", "https://igor.org", 5 },
                    { 11, new DateTime(2019, 11, 6, 23, 24, 45, 287, DateTimeKind.Local).AddTicks(6751), "Ślusarczyk, Pietrzak and Kowalewski", "http://gertruda.com.pl", 1 },
                    { 10, new DateTime(2020, 9, 4, 6, 3, 33, 446, DateTimeKind.Local).AddTicks(2661), "Kiełbasa, Maciąg and Bąkowski", "https://cecyliusz.org", 7 },
                    { 9, new DateTime(2020, 1, 7, 20, 21, 16, 326, DateTimeKind.Local).AddTicks(1293), "Sobczyk - Broda", "http://apollo.net", 2 },
                    { 8, new DateTime(2020, 5, 19, 0, 19, 53, 925, DateTimeKind.Local).AddTicks(2233), "Strzelczyk, Szewczyk and Przybysz", "http://sylwia.com", 5 },
                    { 7, new DateTime(2020, 9, 7, 14, 39, 34, 699, DateTimeKind.Local).AddTicks(2698), "Skowroński - Banasik", "http://dominik.com", 1 },
                    { 6, new DateTime(2020, 4, 22, 22, 31, 14, 170, DateTimeKind.Local).AddTicks(3679), "Flak, Woś and Wieczorek", "https://harald.pl", 9 },
                    { 5, new DateTime(2020, 9, 17, 19, 30, 59, 750, DateTimeKind.Local).AddTicks(6050), "Wasiak - Pawlicki", "http://regina.pl", 10 },
                    { 4, new DateTime(2020, 2, 20, 13, 44, 17, 785, DateTimeKind.Local).AddTicks(1761), "Gwóźdź LLC", "https://samson.net", 5 },
                    { 3, new DateTime(2019, 11, 4, 18, 51, 39, 624, DateTimeKind.Local).AddTicks(6163), "Adamus, Woliński and Czekaj", "https://wincenty.com.pl", 9 },
                    { 2, new DateTime(2020, 2, 8, 20, 5, 56, 845, DateTimeKind.Local).AddTicks(5416), "Stolarski - Czech", "https://ofelia.net", 6 },
                    { 29, new DateTime(2020, 2, 25, 14, 29, 44, 514, DateTimeKind.Local).AddTicks(5690), "Iwanowski, Kaczorowski and Jagielski", "http://pantaleon.com", 4 },
                    { 30, new DateTime(2020, 8, 16, 6, 29, 4, 137, DateTimeKind.Local).AddTicks(3117), "Lipski LLC", "http://arystarch.com.pl", 9 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");
        }
    }
}
