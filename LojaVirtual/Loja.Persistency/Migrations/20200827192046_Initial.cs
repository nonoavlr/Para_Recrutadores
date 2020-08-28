using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Loja.Persistency.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserID = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    isAdmin = table.Column<bool>(nullable: false),
                    isActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddressType = table.Column<string>(nullable: true),
                    AddressName = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Complemention = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    ClientID = table.Column<int>(nullable: false),
                    isActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Address_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    ClientID = table.Column<int>(nullable: false),
                    isActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Product_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypePayment = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    AddressID = table.Column<int>(nullable: false),
                    ClientID = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Order_Address_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Client_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Databases",
                columns: table => new
                {
                    DatabaseID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    ProductID = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Databases", x => x.DatabaseID);
                    table.ForeignKey(
                        name: "FK_Databases_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockSize",
                columns: table => new
                {
                    StockSizeID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Stock = table.Column<int>(nullable: false),
                    Size = table.Column<string>(nullable: true),
                    ProductID = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockSize", x => x.StockSizeID);
                    table.ForeignKey(
                        name: "FK_StockSize_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_Item_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_Product_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientID", "BirthDate", "CPF", "CreatedOn", "Email", "LastModified", "LastName", "Name", "Password", "UserID", "isActive", "isAdmin" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@loja.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Admin", "TESTE", null, true, true });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductID", "ClientID", "CreatedOn", "Description", "Gender", "LastModified", "Name", "Price", "Title", "Type", "isActive" },
                values: new object[] { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ótima lavagem, longa duração", "Fem", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Calça Jeans Strech", 50.899999999999999, "Calça Jeans Super Pure Strech", "Calça", true });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductID", "ClientID", "CreatedOn", "Description", "Gender", "LastModified", "Name", "Price", "Title", "Type", "isActive" },
                values: new object[] { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Impermeável", "Masc", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blusa Ultra Dry", 70.5, "Blusa de Manga Longa", "Blusa", true });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductID", "ClientID", "CreatedOn", "Description", "Gender", "LastModified", "Name", "Price", "Title", "Type", "isActive" },
                values: new object[] { 3, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alta Costura", "Both", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jaqueta Minimalista Limited Edition", 110.09999999999999, "Jaqueta Minimalista", "Calça", true });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductID", "ClientID", "CreatedOn", "Description", "Gender", "LastModified", "Name", "Price", "Title", "Type", "isActive" },
                values: new object[] { 4, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ultra weight", "Both", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tennis Vintage 90'", 190.5, "Tennis Vintage", "Calcado", true });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductID", "ClientID", "CreatedOn", "Description", "Gender", "LastModified", "Name", "Price", "Title", "Type", "isActive" },
                values: new object[] { 5, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Confort Plus", "Fem", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sapatilha Confort Plus", 170.90000000000001, "Sapatilha Confortável", "Calcado", true });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductID", "ClientID", "CreatedOn", "Description", "Gender", "LastModified", "Name", "Price", "Title", "Type", "isActive" },
                values: new object[] { 6, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ecological", "Masc", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sapato Social Vegan-Weather", 150.90000000000001, "Sapato Social Vegano", "Calcado", true });

            migrationBuilder.InsertData(
                table: "Databases",
                columns: new[] { "DatabaseID", "CreatedOn", "LastModified", "Link", "ProductID", "Type" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.imgur.com/oSriV6C.png", 1, null });

            migrationBuilder.InsertData(
                table: "Databases",
                columns: new[] { "DatabaseID", "CreatedOn", "LastModified", "Link", "ProductID", "Type" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.imgur.com/iO8v42u.png", 1, null });

            migrationBuilder.InsertData(
                table: "Databases",
                columns: new[] { "DatabaseID", "CreatedOn", "LastModified", "Link", "ProductID", "Type" },
                values: new object[] { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.imgur.com/bBwzdcR.png", 6, null });

            migrationBuilder.InsertData(
                table: "Databases",
                columns: new[] { "DatabaseID", "CreatedOn", "LastModified", "Link", "ProductID", "Type" },
                values: new object[] { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.imgur.com/fx3YY5M.png", 6, null });

            migrationBuilder.InsertData(
                table: "Databases",
                columns: new[] { "DatabaseID", "CreatedOn", "LastModified", "Link", "ProductID", "Type" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.imgur.com/8z9xS93.png", 2, null });

            migrationBuilder.InsertData(
                table: "Databases",
                columns: new[] { "DatabaseID", "CreatedOn", "LastModified", "Link", "ProductID", "Type" },
                values: new object[] { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.imgur.com/3w7RZNV.png", 2, null });

            migrationBuilder.InsertData(
                table: "Databases",
                columns: new[] { "DatabaseID", "CreatedOn", "LastModified", "Link", "ProductID", "Type" },
                values: new object[] { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.imgur.com/ggv0I4H.png", 3, null });

            migrationBuilder.InsertData(
                table: "Databases",
                columns: new[] { "DatabaseID", "CreatedOn", "LastModified", "Link", "ProductID", "Type" },
                values: new object[] { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.imgur.com/QfJf0m3.png", 3, null });

            migrationBuilder.InsertData(
                table: "Databases",
                columns: new[] { "DatabaseID", "CreatedOn", "LastModified", "Link", "ProductID", "Type" },
                values: new object[] { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.imgur.com/1NbHdF5.png", 5, null });

            migrationBuilder.InsertData(
                table: "Databases",
                columns: new[] { "DatabaseID", "CreatedOn", "LastModified", "Link", "ProductID", "Type" },
                values: new object[] { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.imgur.com/UL2OVc8.png", 5, null });

            migrationBuilder.InsertData(
                table: "Databases",
                columns: new[] { "DatabaseID", "CreatedOn", "LastModified", "Link", "ProductID", "Type" },
                values: new object[] { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.imgur.com/3axAbbW.png", 4, null });

            migrationBuilder.InsertData(
                table: "Databases",
                columns: new[] { "DatabaseID", "CreatedOn", "LastModified", "Link", "ProductID", "Type" },
                values: new object[] { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.imgur.com/v9NVCwN.png", 4, null });

            migrationBuilder.InsertData(
                table: "StockSize",
                columns: new[] { "StockSizeID", "CreatedOn", "LastModified", "ProductID", "Size", "Stock" },
                values: new object[] { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "37", 8 });

            migrationBuilder.InsertData(
                table: "StockSize",
                columns: new[] { "StockSizeID", "CreatedOn", "LastModified", "ProductID", "Size", "Stock" },
                values: new object[] { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "41", 3 });

            migrationBuilder.InsertData(
                table: "StockSize",
                columns: new[] { "StockSizeID", "CreatedOn", "LastModified", "ProductID", "Size", "Stock" },
                values: new object[] { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "43", 7 });

            migrationBuilder.InsertData(
                table: "StockSize",
                columns: new[] { "StockSizeID", "CreatedOn", "LastModified", "ProductID", "Size", "Stock" },
                values: new object[] { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "XXG", 7 });

            migrationBuilder.InsertData(
                table: "StockSize",
                columns: new[] { "StockSizeID", "CreatedOn", "LastModified", "ProductID", "Size", "Stock" },
                values: new object[] { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "44", 2 });

            migrationBuilder.InsertData(
                table: "StockSize",
                columns: new[] { "StockSizeID", "CreatedOn", "LastModified", "ProductID", "Size", "Stock" },
                values: new object[] { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "M", 5 });

            migrationBuilder.InsertData(
                table: "StockSize",
                columns: new[] { "StockSizeID", "CreatedOn", "LastModified", "ProductID", "Size", "Stock" },
                values: new object[] { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "P", 5 });

            migrationBuilder.InsertData(
                table: "StockSize",
                columns: new[] { "StockSizeID", "CreatedOn", "LastModified", "ProductID", "Size", "Stock" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "G", 12 });

            migrationBuilder.InsertData(
                table: "StockSize",
                columns: new[] { "StockSizeID", "CreatedOn", "LastModified", "ProductID", "Size", "Stock" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "46", 3 });

            migrationBuilder.InsertData(
                table: "StockSize",
                columns: new[] { "StockSizeID", "CreatedOn", "LastModified", "ProductID", "Size", "Stock" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "42", 9 });

            migrationBuilder.InsertData(
                table: "StockSize",
                columns: new[] { "StockSizeID", "CreatedOn", "LastModified", "ProductID", "Size", "Stock" },
                values: new object[] { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "38", 3 });

            migrationBuilder.InsertData(
                table: "StockSize",
                columns: new[] { "StockSizeID", "CreatedOn", "LastModified", "ProductID", "Size", "Stock" },
                values: new object[] { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "38", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Address_ClientID",
                table: "Address",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Databases_ProductID",
                table: "Databases",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Item_OrderID",
                table: "Item",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ClientID",
                table: "Product",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_StockSize_ProductID",
                table: "StockSize",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Databases");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "StockSize");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
