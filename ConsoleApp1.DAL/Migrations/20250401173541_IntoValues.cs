using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp1.DAL.Migrations
{
    /// <inheritdoc />
    public partial class IntoValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            INSERT INTO Students(Name, Description)
            VALUES ('Ivan', 'text1'),
                   ('Max', 'text2'),
                   ('Andrii', 'text3');
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
