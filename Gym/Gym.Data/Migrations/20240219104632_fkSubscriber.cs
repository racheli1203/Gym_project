using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.Data.Migrations
{
    public partial class fkSubscriber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subscribers_Staffs_trainerIdworkerNumber",
                table: "subscribers");

            migrationBuilder.RenameColumn(
                name: "trainerIdworkerNumber",
                table: "subscribers",
                newName: "trainerId");

            migrationBuilder.RenameIndex(
                name: "IX_subscribers_trainerIdworkerNumber",
                table: "subscribers",
                newName: "IX_subscribers_trainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_subscribers_Staffs_trainerId",
                table: "subscribers",
                column: "trainerId",
                principalTable: "Staffs",
                principalColumn: "workerNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subscribers_Staffs_trainerId",
                table: "subscribers");

            migrationBuilder.RenameColumn(
                name: "trainerId",
                table: "subscribers",
                newName: "trainerIdworkerNumber");

            migrationBuilder.RenameIndex(
                name: "IX_subscribers_trainerId",
                table: "subscribers",
                newName: "IX_subscribers_trainerIdworkerNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_subscribers_Staffs_trainerIdworkerNumber",
                table: "subscribers",
                column: "trainerIdworkerNumber",
                principalTable: "Staffs",
                principalColumn: "workerNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
