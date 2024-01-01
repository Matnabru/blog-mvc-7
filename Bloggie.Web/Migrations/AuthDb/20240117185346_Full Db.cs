using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Horroras.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class FullDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed9cbfab-68a5-4901-a777-84ebc92da348",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1875e4b3-6237-4dcb-8e8e-dd26c0e5f0a1", "SUPERADMIN@Horroras.COM", "SUPERADMIN@Horroras.COM", "AQAAAAIAAYagAAAAEAD2f+04DaLrB/47FAcAXiADRPYHRFJmb3vtmqqYF4sJ6if9G4wlRdCLsq84k3r1WA==", "173e14e6-dd51-4204-9df6-aa65e328a46b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed9cbfab-68a5-4901-a777-84ebc92da348",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62ce15b4-9b55-49f9-bd5b-758a21de6dcc", "SUPERADMİN@BLOGGİE.COM", "SUPERADMİN@BLOGGİE.COM", "AQAAAAIAAYagAAAAEEZPXhcDS8HbrrKJt6tjOqUT0IIWPqn2AYpclH98QiC2+6uREClR+keV8vQHeaFhhg==", "c374b977-7f2e-4906-9e24-7bfea4de5960" });
        }
    }
}
