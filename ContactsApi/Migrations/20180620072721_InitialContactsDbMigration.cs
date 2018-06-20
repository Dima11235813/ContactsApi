using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactsApi.Migrations
{
    public partial class InitialContactsDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 70, nullable: false),
                    Company = table.Column<string>(maxLength: 70, nullable: true),
                    ProfileImage = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Birthdate = table.Column<string>(nullable: true),
                    PersonalPhoneNumber = table.Column<string>(nullable: true),
                    WorkPhoneNumber = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
