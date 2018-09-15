using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EarlyBirdScience.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DateModel",
                columns: table => new
                {
                    DateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateModel", x => x.DateId);
                });

            migrationBuilder.CreateTable(
                name: "PostModel",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 30, nullable: false),
                    Subtitle = table.Column<string>(maxLength: 140, nullable: true),
                    Published = table.Column<bool>(nullable: false),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    CommentsEnabled = table.Column<bool>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    DateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostModel", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_PostModel_DateModel_DateId",
                        column: x => x.DateId,
                        principalTable: "DateModel",
                        principalColumn: "DateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommentModel",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Removed = table.Column<bool>(nullable: false),
                    Content = table.Column<string>(maxLength: 1024, nullable: false),
                    DateModelDateId = table.Column<int>(nullable: true),
                    PostModelPostId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentModel", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_CommentModel_DateModel_DateModelDateId",
                        column: x => x.DateModelDateId,
                        principalTable: "DateModel",
                        principalColumn: "DateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentModel_PostModel_PostModelPostId",
                        column: x => x.PostModelPostId,
                        principalTable: "PostModel",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentModel_DateModelDateId",
                table: "CommentModel",
                column: "DateModelDateId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentModel_PostModelPostId",
                table: "CommentModel",
                column: "PostModelPostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostModel_DateId",
                table: "PostModel",
                column: "DateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentModel");

            migrationBuilder.DropTable(
                name: "PostModel");

            migrationBuilder.DropTable(
                name: "DateModel");
        }
    }
}
