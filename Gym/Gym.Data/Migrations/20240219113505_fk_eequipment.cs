using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.Data.Migrations
{
    public partial class fk_eequipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StaffgymEquipment",
                columns: table => new
                {
                    equipmentInCategoryid = table.Column<int>(type: "int", nullable: false),
                    staffsworkerNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffgymEquipment", x => new { x.equipmentInCategoryid, x.staffsworkerNumber });
                    table.ForeignKey(
                        name: "FK_StaffgymEquipment_equipments_equipmentInCategoryid",
                        column: x => x.equipmentInCategoryid,
                        principalTable: "equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffgymEquipment_Staffs_staffsworkerNumber",
                        column: x => x.staffsworkerNumber,
                        principalTable: "Staffs",
                        principalColumn: "workerNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StaffgymEquipment_staffsworkerNumber",
                table: "StaffgymEquipment",
                column: "staffsworkerNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaffgymEquipment");
        }
    }
}
