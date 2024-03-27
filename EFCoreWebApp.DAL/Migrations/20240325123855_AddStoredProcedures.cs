using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreWebApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddStoredProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var proc1 = @"
            IF OBJECT_ID('GetPersonsByState','P') IS NOT NULL
            DROP PROC UpdateProfileCountry
            GO

            CREATE PROCEDURE [dbo].[GetPersonsByState]
                @State varchar(255)
            AS
            BEGIN
                SELECT p.*
                FROM Persons p
                INNER JOIN Addresses a on p.Id = a.PersonId
                WHERE a.State = @State
            END";

            var proc2 = @"
            IF OBJECT_ID('AddLookUpItem','P') IS NOT NULL
            DROP PROC AddLookUpItem
            GO

            CREATE PROCEDURE [dbo].[AddLookUpItem]
                @Code varchar(255),
                @Description varchar(255),
                @LookUpTypeId int
            AS
            BEGIN
               INSERT INTO LookUps (Code, Description, LookUpType) VALUES (@Code, @Description, @LookUpTypeId)
            END";

            migrationBuilder.Sql(proc1);
            migrationBuilder.Sql(proc2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROC GetPersonsByState");
            migrationBuilder.Sql(@"DROP PROC AddLookUpItem");
        }
    }
}