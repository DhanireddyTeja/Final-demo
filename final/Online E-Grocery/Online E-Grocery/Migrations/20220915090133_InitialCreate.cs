using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_E_Grocery.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    ItemId = table.Column<int>(name: "Item Id", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(nullable: false),
                    ItemName = table.Column<string>(name: "Item Name", nullable: true),
                    ItemPrice = table.Column<int>(name: "Item Price", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    orderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemName = table.Column<string>(nullable: true),
                    orderPlace = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.orderId);
                });

            migrationBuilder.CreateTable(
                name: "rating",
                columns: table => new
                {
                    ratingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(nullable: false),
                    RatingItem = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rating", x => x.ratingId);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    userId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    passWord = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.userId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "item");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "rating");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
