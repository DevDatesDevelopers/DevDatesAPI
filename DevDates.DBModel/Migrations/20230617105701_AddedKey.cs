using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

#nullable disable

namespace DevDates.DBModel.Migrations
{
    /// <inheritdoc />
    public partial class AddedKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Genders__3214EC07DA6BD736", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Interest__3214EC07357635C6", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourcesTypes",
               
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Resource__3214EC07FF85144A", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    Bio = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3214EC076D009CCD", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Users__GenderId__1BC821DD",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceURI = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ResourceTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Resource__3214EC071098848C", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Resources__Resou__208CD6FA",
                        column: x => x.ResourceTypeId,
                        principalTable: "ResourcesTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    LikerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LikedId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Likes__50BBFF3E916FCE5A", x => new { x.LikerId, x.LikedId });
                    table.ForeignKey(
                        name: "FK__Likes__LikedId__395884C4",
                        column: x => x.LikedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Likes__LikerId__3864608B",
                        column: x => x.LikerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsersInterests",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UsersInt__7580FE8A3A3E6E5B", x => new { x.UserId, x.InterestId });
                    table.ForeignKey(
                        name: "FK__UsersInte__Inter__3587F3E0",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__UsersInte__UserI__3493CFA7",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsersPreferences",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UsersPre__736A82D3B322C613", x => new { x.UserId, x.GenderId });
                    table.ForeignKey(
                        name: "FK__UsersPref__Gende__31B762FC",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__UsersPref__UserI__30C33EC3",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GendersResources",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GendersR__AAC9F1E186608F56", x => new { x.GenderId, x.ResourceId });
                    table.ForeignKey(
                        name: "FK__GendersRe__Gende__2CF2ADDF",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__GendersRe__Resou__2DE6D218",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InterestsResources",
                columns: table => new
                {
                    InterestId = table.Column<int>(type: "int", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Interest__C46E34712581E9BE", x => new { x.InterestId, x.ResourceId });
                    table.ForeignKey(
                        name: "FK__Interests__Inter__25518C17",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Interests__Resou__2645B050",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsersResources",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UsersRes__F365D45A2520B708", x => new { x.UserId, x.ResourceId });
                    table.ForeignKey(
                        name: "FK__UsersReso__Resou__2A164134",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__UsersReso__UserI__29221CFB",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GendersResources_ResourceId",
                table: "GendersResources",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestsResources_ResourceId",
                table: "InterestsResources",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_LikedId",
                table: "Likes",
                column: "LikedId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ResourceTypeId",
                table: "Resources",
                column: "ResourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GenderId",
                table: "Users",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInterests_InterestId",
                table: "UsersInterests",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPreferences_GenderId",
                table: "UsersPreferences",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersResources_ResourceId",
                table: "UsersResources",
                column: "ResourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GendersResources");

            migrationBuilder.DropTable(
                name: "InterestsResources");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "UsersInterests");

            migrationBuilder.DropTable(
                name: "UsersPreferences");

            migrationBuilder.DropTable(
                name: "UsersResources");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ResourcesTypes");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}
