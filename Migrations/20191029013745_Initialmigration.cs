using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectForHealing.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Fname = table.Column<string>(nullable: true),
                    Lname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Pnumber = table.Column<string>(nullable: true),
                    AdminPassWord = table.Column<string>(nullable: true),
                    ProfilePic = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Editor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Fname = table.Column<string>(nullable: true),
                    Lname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Pnumber = table.Column<string>(nullable: true),
                    EditorPassWord = table.Column<string>(nullable: true),
                    ProfilePic = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    ResourceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrgName = table.Column<string>(nullable: true),
                    OrgNumber = table.Column<string>(nullable: true),
                    OrgEmail = table.Column<string>(nullable: true),
                    OrgAddress = table.Column<string>(nullable: true),
                    OrgZip = table.Column<string>(nullable: true),
                    OrgSte = table.Column<string>(nullable: true),
                    OrgDescription = table.Column<string>(nullable: true),
                    WebsiteUrl = table.Column<string>(nullable: true),
                    IsApproved = table.Column<bool>(nullable: true),
                    Fname = table.Column<string>(nullable: true),
                    Lname = table.Column<string>(nullable: true),
                    RepNumber = table.Column<string>(nullable: true),
                    RepEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.ResourceID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Editor");

            migrationBuilder.DropTable(
                name: "Resource");
        }
    }
}
