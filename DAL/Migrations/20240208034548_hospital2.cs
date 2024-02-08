using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class hospital2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InsurancePolicyDateEnf",
                table: "UserAdditionals",
                newName: "InsurancePolicyDateEnd");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "UserAdditionals",
                newName: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InsurancePolicyDateEnd",
                table: "UserAdditionals",
                newName: "InsurancePolicyDateEnf");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "UserAdditionals",
                newName: "Adress");
        }
    }
}
