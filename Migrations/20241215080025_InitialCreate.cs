﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InstaChef.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preparation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CuisineType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MealType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CookingDifficulty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreparationTime = table.Column<int>(type: "int", nullable: false),
                    ServingCount = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Accounts_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Status", "Username" },
                values: new object[,]
                {
                    { 1, "marga18nins@gmail.com", "Niña Margarette", "Catubig", "testing", 1, "cuteko" },
                    { 2, "francischavez@gmail.com", "Francis Benedict", "Chavez", "testing2", 1, "benedict" },
                    { 3, "paulabellana@gmail.com", "Paul Thomas", "Abellana", "testing3", 1, "thomas" },
                    { 4, "morielbien@gmail.com", "Moriel", "Bien", "testing4", 1, "bien" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Category", "Name" },
                values: new object[,]
                {
                    { 1, "Baking", "Flour" },
                    { 2, "Baking", "Sugar" },
                    { 3, "Baking", "Yeast" },
                    { 4, "Baking", "Baking Powder" },
                    { 5, "Baking", "Baking Soda" },
                    { 6, "Baking", "Vanilla Extract" },
                    { 7, "Baking", "Cocoa Powder" },
                    { 8, "Baking", "Cornstarch" },
                    { 9, "Vegetables", "Tomatoes" },
                    { 10, "Vegetables", "Carrots" },
                    { 11, "Vegetables", "Spinach" },
                    { 12, "Vegetables", "Potatoes" },
                    { 13, "Vegetables", "Onions" },
                    { 14, "Vegetables", "Garlic" },
                    { 15, "Vegetables", "Peppers" },
                    { 16, "Vegetables", "Cucumber" },
                    { 17, "Fruits", "Apples" },
                    { 18, "Fruits", "Bananas" },
                    { 19, "Fruits", "Oranges" },
                    { 20, "Fruits", "Lemons" },
                    { 21, "Fruits", "Strawberries" },
                    { 22, "Fruits", "Blueberries" },
                    { 23, "Fruits", "Grapes" },
                    { 24, "Fruits", "Pineapple" },
                    { 25, "Meat", "Chicken" },
                    { 26, "Meat", "Beef" },
                    { 27, "Meat", "Pork" },
                    { 28, "Meat", "Lamb" },
                    { 29, "Meat", "Turkey" },
                    { 30, "Meat", "Duck" },
                    { 31, "Meat", "Bacon" },
                    { 32, "Meat", "Ham" },
                    { 33, "Seafood", "Shrimp" },
                    { 34, "Seafood", "Crab" },
                    { 35, "Seafood", "Salmon" },
                    { 36, "Seafood", "Tuna" },
                    { 37, "Seafood", "Lobster" },
                    { 38, "Seafood", "Cod" },
                    { 39, "Seafood", "Mussels" },
                    { 40, "Seafood", "Clams" },
                    { 41, "Dairy", "Milk" },
                    { 42, "Dairy", "Cheese" },
                    { 43, "Dairy", "Yogurt" },
                    { 44, "Dairy", "Cream" },
                    { 45, "Dairy", "Butter" },
                    { 46, "Dairy", "Sour Cream" },
                    { 47, "Dairy", "Whipped Cream" },
                    { 48, "Dairy", "Cottage Cheese" },
                    { 49, "Spices", "Salt" },
                    { 50, "Spices", "Pepper" },
                    { 51, "Spices", "Cinnamon" },
                    { 52, "Spices", "Paprika" },
                    { 53, "Spices", "Cumin" },
                    { 54, "Herbs", "Basil" },
                    { 55, "Herbs", "Oregano" },
                    { 56, "Herbs", "Parsley" },
                    { 57, "Herbs", "Rosemary" },
                    { 58, "Grains", "Rice" },
                    { 59, "Grains", "Pasta" },
                    { 60, "Grains", "Quinoa" },
                    { 61, "Grains", "Oats" },
                    { 62, "Grains", "Bread" },
                    { 63, "Grains", "Tortillas" },
                    { 64, "Grains", "Noodles" },
                    { 65, "Condiments", "Soy Sauce" },
                    { 66, "Condiments", "Hot Sauce" },
                    { 67, "Condiments", "BBQ Sauce" },
                    { 68, "Condiments", "Tamari" },
                    { 69, "Condiments", "Dijon Mustard" },
                    { 70, "Condiments", "Ketchup" },
                    { 71, "Condiments", "Sriracha" },
                    { 72, "Condiments", "Oyster Sauce" },
                    { 73, "Condiments", "Ginger-Garlic Paste" },
                    { 74, "Condiments", "Teriyaki Sauce" },
                    { 75, "Condiments", "Prepared Horseradish" },
                    { 76, "Condiments", "Dark Soy Sauce" },
                    { 77, "Condiments", "Chili Paste" },
                    { 78, "Condiments", "Tamarind Paste" },
                    { 79, "Condiments", "Mustard" },
                    { 80, "Condiments", "Harissa" },
                    { 81, "Condiments", "Worcestershire" },
                    { 82, "Condiments", "Fish Sauce" },
                    { 83, "Condiments", "Wholegrain Mustard" },
                    { 84, "Condiments", "Chili Sauce" },
                    { 85, "Condiments", "Brown Mustard" },
                    { 86, "Condiments", "Wing Sauce" },
                    { 87, "Condiments", "Ginger Paste" },
                    { 88, "Condiments", "Coconut Aminos" },
                    { 89, "Condiments", "Chili-Garlic Sauce" },
                    { 90, "Condiments", "Pomegranate Molasses" },
                    { 91, "Condiments", "Chutney" },
                    { 92, "Condiments", "Green Chutney" },
                    { 93, "Condiments", "Liquid Aminos" },
                    { 94, "Condiments", "Gochujang" },
                    { 95, "Condiments", "Honey Mustard" },
                    { 96, "Condiments", "English Mustard" },
                    { 97, "Condiments", "Kecap Manis" },
                    { 98, "Condiments", "Thai Sweet Chili Sauce" },
                    { 99, "Condiments", "Sweet and Sour Sauce" },
                    { 100, "Condiments", "Hot Pepper Jelly" },
                    { 101, "Condiments", "Tartar Sauce" },
                    { 102, "Condiments", "Mexican Hot Sauce" },
                    { 103, "Condiments", "Green Chili Sauce" },
                    { 104, "Condiments", "Thai Chili Paste" },
                    { 105, "Condiments", "Wasabi" },
                    { 106, "Condiments", "Sambal Oelek" },
                    { 107, "Condiments", "Mango Chutney" },
                    { 108, "Condiments", "Preserved Lemon" },
                    { 109, "Condiments", "Shrimp Paste" },
                    { 110, "Condiments", "Picante Sauce" },
                    { 111, "Condiments", "Chili-Garlic Paste" },
                    { 112, "Condiments", "Bonito Flakes" },
                    { 113, "Condiments", "Red Pepper Jelly" },
                    { 114, "Condiments", "Crispy Onions" },
                    { 115, "Condiments", "Ponzu" },
                    { 116, "Condiments", "Peri Peri" },
                    { 117, "Condiments", "Giardiniera" },
                    { 118, "Condiments", "Duck Sauce" },
                    { 119, "Condiments", "Doubanjiang" },
                    { 120, "Condiments", "Doenjang" },
                    { 121, "Condiments", "Maggi Sauce" },
                    { 122, "Condiments", "Lime Pickle" },
                    { 123, "Condiments", "Chamoy" },
                    { 124, "Condiments", "Green Chili Paste" },
                    { 125, "Condiments", "Red Pepper Relish" },
                    { 126, "Condiments", "Horseradish Mustard" },
                    { 127, "Condiments", "Ginger Chili Paste" },
                    { 128, "Condiments", "Onion Marmalade" },
                    { 129, "Condiments", "Chermoula" },
                    { 130, "Condiments", "Tonkatsu Sauce" },
                    { 131, "Condiments", "Black Soy Sauce" },
                    { 132, "Condiments", "Korean BBQ Sauce" },
                    { 133, "Condiments", "Chinese Mustard" },
                    { 134, "Condiments", "Mushroom Soy Sauce" },
                    { 135, "Condiments", "German Mustard" },
                    { 136, "Condiments", "Banana Ketchup" },
                    { 137, "Condiments", "Hot Pepper Relish" },
                    { 138, "Condiments", "Eel Sauce" },
                    { 139, "Condiments", "Aji Amarillo" },
                    { 140, "Condiments", "Mint Jelly" },
                    { 141, "Condiments", "Mustard Paste" },
                    { 142, "Condiments", "Tamarind Chutney" },
                    { 143, "Condiments", "Yuzu Juice" },
                    { 144, "Condiments", "HP Sauce" },
                    { 145, "Condiments", "Chili Crisp" },
                    { 146, "Condiments", "Karashi" },
                    { 147, "Condiments", "Taucheo" },
                    { 148, "Condiments", "Yuzu Kosho" },
                    { 149, "Condiments", "Remoulade" },
                    { 150, "Condiments", "Guk Ganjang" },
                    { 151, "Vegetables", "Onion" },
                    { 152, "Vegetables", "Bell Pepper" },
                    { 153, "Vegetables", "Tomato" },
                    { 154, "Vegetables", "Avocado" },
                    { 155, "Vegetables", "Carrot" },
                    { 156, "Vegetables", "Red Onion" },
                    { 157, "Vegetables", "Shallot" },
                    { 158, "Vegetables", "Baby Greens" },
                    { 159, "Vegetables", "Asparagus" },
                    { 160, "Vegetables", "Kale" },
                    { 161, "Vegetables", "Corn" },
                    { 162, "Vegetables", "Leek" },
                    { 163, "Vegetables", "Lettuce" },
                    { 164, "Vegetables", "Romaine" },
                    { 165, "Vegetables", "Radish" },
                    { 166, "Vegetables", "Summer Squash" },
                    { 167, "Vegetables", "Parsnip" },
                    { 168, "Vegetables", "Iceberg" },
                    { 169, "Vegetables", "Mashed Potatoes" },
                    { 170, "Vegetables", "Chard" },
                    { 171, "Vegetables", "Scallion" },
                    { 172, "Vegetables", "Celery" },
                    { 173, "Vegetables", "Cherry Tomato" },
                    { 174, "Vegetables", "Sweet Potato" },
                    { 175, "Vegetables", "Pumpkin" },
                    { 176, "Vegetables", "Cabbage" },
                    { 177, "Vegetables", "Eggplant" },
                    { 178, "Vegetables", "Beetroot" },
                    { 179, "Vegetables", "Sun Dried Tomato" },
                    { 180, "Vegetables", "Red Cabbage" },
                    { 181, "Vegetables", "New Potato" },
                    { 182, "Vegetables", "Baby Carrot" },
                    { 183, "Vegetables", "Sweet Pepper" },
                    { 184, "Vegetables", "Watercress" },
                    { 185, "Vegetables", "Hash Browns" },
                    { 186, "Vegetables", "Butter Lettuce" },
                    { 187, "Vegetables", "Spaghetti Squash" },
                    { 188, "Vegetables", "Bok Choy" },
                    { 189, "Vegetables", "Water Chestnut" },
                    { 190, "Vegetables", "Leaf Lettuce" },
                    { 191, "Vegetables", "Okra" },
                    { 192, "Vegetables", "Potato" },
                    { 193, "Vegetables", "Zucchini" },
                    { 194, "Vegetables", "Broccoli" },
                    { 195, "Vegetables", "Cauliflower" },
                    { 196, "Vegetables", "Arugula" },
                    { 197, "Vegetables", "Butternut Squash" },
                    { 198, "Vegetables", "Brussels Sprout" },
                    { 199, "Vegetables", "Fennel" },
                    { 200, "Vegetables", "Artichoke" },
                    { 201, "Vegetables", "Mixed Greens" },
                    { 202, "Vegetables", "Mixed Vegetable" },
                    { 203, "Vegetables", "Green Tomato" },
                    { 204, "Vegetables", "Horseradish" },
                    { 205, "Vegetables", "Pimiento" },
                    { 206, "Vegetables", "Napa Cabbage" },
                    { 207, "Vegetables", "Celeriac" },
                    { 208, "Vegetables", "Corn Cob" },
                    { 209, "Vegetables", "Radicchio" },
                    { 210, "Vegetables", "Cavolo Nero" },
                    { 211, "Vegetables", "Coleslaw" },
                    { 212, "Vegetables", "Turnip" },
                    { 213, "Vegetables", "Acorn Squash" },
                    { 214, "Vegetables", "Pearl Onion" },
                    { 215, "Vegetables", "Tenderstem Broccoli" },
                    { 216, "Vegetables", "Jicama" },
                    { 217, "Vegetables", "French-Fried Onions" },
                    { 218, "Vegetables", "Rutabaga" },
                    { 219, "Vegetables", "Belgian Endive" },
                    { 220, "Vegetables", "Microgreens" },
                    { 221, "Vegetables", "Delicata Squash" },
                    { 222, "Vegetables", "Frisee" },
                    { 223, "Vegetables", "French Fries" },
                    { 224, "Vegetables", "Lamb's Lettuce" },
                    { 225, "Vegetables", "Garlic Scapes" },
                    { 226, "Vegetables", "Plantain" },
                    { 227, "Vegetables", "Corn Husk" },
                    { 228, "Vegetables", "Baby Corn" },
                    { 229, "Vegetables", "Endive" },
                    { 230, "Vegetables", "Kohlrabi" },
                    { 231, "Vegetables", "Yam" },
                    { 232, "Vegetables", "Baby Bok Choy" },
                    { 233, "Vegetables", "Collard Greens" },
                    { 234, "Vegetables", "Daikon" },
                    { 235, "Vegetables", "Potato Flakes" },
                    { 236, "Vegetables", "Broccoli Rabe" },
                    { 237, "Fruits", "Lemon" },
                    { 238, "Fruits", "Raisins" },
                    { 239, "Fruits", "Date" },
                    { 240, "Fruits", "Apple" },
                    { 241, "Fruits", "Orange" },
                    { 242, "Fruits", "Peach" },
                    { 243, "Fruits", "Pear" },
                    { 244, "Fruits", "Grape" },
                    { 245, "Fruits", "Rhubarb" },
                    { 246, "Fruits", "Plum" },
                    { 247, "Fruits", "Prunes" },
                    { 248, "Fruits", "Fio" },
                    { 249, "Fruits", "Banana" },
                    { 250, "Fruits", "Coconut" },
                    { 251, "Fruits", "Watermelon" },
                    { 252, "Fruits", "Kiwi" },
                    { 253, "Fruits", "Mandarin" },
                    { 254, "Fruits", "Grapefruit" },
                    { 255, "Fruits", "Currant" },
                    { 256, "Fruits", "Papaya" },
                    { 257, "Fruits", "Dried Fig" },
                    { 258, "Fruits", "Sultanas" },
                    { 259, "Fruits", "Tamarind" },
                    { 260, "Fruits", "Chestnut" },
                    { 261, "Fruits", "Dried Fruit" },
                    { 262, "Fruits", "Persimmon" },
                    { 263, "Fruits", "Tangerine" },
                    { 264, "Fruits", "Quince" },
                    { 265, "Fruits", "Lime" },
                    { 266, "Fruits", "Mango" },
                    { 267, "Fruits", "Craisins" },
                    { 268, "Fruits", "Pomegranate" },
                    { 269, "Fruits", "Dried Apricot" },
                    { 270, "Fruits", "Apricot" },
                    { 271, "Fruits", "Cantaloupe" },
                    { 272, "Fruits", "Passion Fruit" },
                    { 273, "Fruits", "Nectarine" },
                    { 274, "Fruits", "Meyer Lemon" },
                    { 275, "Fruits", "Clementine" },
                    { 276, "Fruits", "Dried Mango" },
                    { 277, "Fruits", "Banana Chips" },
                    { 278, "Fruits", "Mixed Fruit" },
                    { 279, "Fruits", "Dragon Fruit" },
                    { 280, "Fruits", "Young Coconut" },
                    { 281, "Fruits", "Star Fruit" },
                    { 282, "Fruits", "Pomelo" },
                    { 283, "Fruits", "Prickly Pear" },
                    { 284, "Fruits", "Dried Peach" },
                    { 285, "Fruits", "Kokum" },
                    { 286, "Fruits", "Dried Lemon" },
                    { 287, "Fruits", "Custard-Apple" },
                    { 288, "Fruits", "Freeze-Dried Apple" },
                    { 289, "Fruits", "Dried Tamarind" },
                    { 290, "Fruits", "Physalis" },
                    { 291, "Fruits", "Bitter Orange" },
                    { 292, "Fruits", "Dried Persimmons" },
                    { 293, "Fruits", "Dried Orange Slice" },
                    { 294, "Fruits", "Guava" },
                    { 295, "Fruits", "Jackfruit" },
                    { 296, "Fruits", "Lychee" },
                    { 297, "Fruits", "Green Mango" },
                    { 298, "Fruits", "Dried Pears" },
                    { 299, "Fruits", "Calamansi" },
                    { 300, "Fruits", "Yuzu" },
                    { 301, "Fruits", "Mixed Peel" },
                    { 302, "Fruits", "Tangelo" },
                    { 303, "Fruits", "Young Jackfruit" },
                    { 304, "Fruits", "Sweet Lime" },
                    { 305, "Fruits", "Jujube" },
                    { 306, "Fruits", "Tamarillo" },
                    { 307, "Fruits", "Ice-Apple" },
                    { 308, "Fruits", "Chikoo" },
                    { 309, "Fruits", "Crabapple" },
                    { 310, "Fruits", "Rose Apple" },
                    { 311, "Fruits", "Honeydew Melon" },
                    { 312, "Fruits", "Melon" },
                    { 313, "Fruits", "Dried Apple" },
                    { 314, "Fruits", "Kumquat" },
                    { 315, "Fruits", "Asian Pear" },
                    { 316, "Fruits", "Dried Pineapple" },
                    { 317, "Fruits", "Kaffir Lime" },
                    { 318, "Fruits", "Green Papaya" },
                    { 319, "Fruits", "Chestnut Puree" },
                    { 320, "Fruits", "Apple Chips" },
                    { 321, "Fruits", "Granadilla" },
                    { 322, "Fruits", "Dried Lime" },
                    { 323, "Fruits", "Honey Date" },
                    { 324, "Fruits", "Durian" },
                    { 325, "Fruits", "Dried Watermelon" },
                    { 326, "Dairy", "Buttermilk" },
                    { 327, "Dairy", "Ghee" },
                    { 328, "Dairy", "Custard" },
                    { 329, "Dairy", "Sherbet" },
                    { 330, "Dairy", "Fried Eggs" },
                    { 331, "Dairy", "Quail Egg" },
                    { 332, "Dairy", "Poached Eggs" },
                    { 333, "Dairy", "Sour Milk" },
                    { 334, "Dairy", "Ganache" },
                    { 335, "Dairy", "Salted Egg" },
                    { 336, "Dairy", "Margarine" },
                    { 337, "Dairy", "Milk Powder" },
                    { 338, "Dairy", "Lemon Curd" },
                    { 339, "Dairy", "Liquid Egg Substitute" },
                    { 340, "Dairy", "Kefir" },
                    { 341, "Dairy", "Hung Curd" },
                    { 342, "Dairy", "Buttermilk Powder" },
                    { 343, "Dairy", "Khoya" },
                    { 344, "Dairy", "Clotted Cream" },
                    { 345, "Dairy", "Goat Milk" },
                    { 346, "Dairy", "Ice-Cream Sandwich" },
                    { 347, "Dairy", "Egg White Powder" },
                    { 348, "Dairy", "Raw Milk" },
                    { 349, "Dairy", "Cajeta" },
                    { 350, "Dairy", "Yogurt Starter" },
                    { 351, "Dairy", "Lime Curd" },
                    { 352, "Dairy", "Milkfat" },
                    { 353, "Dairy", "Strawberry Frosting" },
                    { 354, "Dairy", "Honey Butter" },
                    { 355, "Dairy", "Strawberry Cream Cheese" },
                    { 356, "Dairy", "Cookies n' Cream Ice Cream" },
                    { 357, "Dairy", "Century Egg" },
                    { 358, "Dairy", "Orange Curd" },
                    { 359, "Dairy", "Dahi" },
                    { 360, "Dairy", "Chantilly" },
                    { 361, "Dairy", "Ayran" },
                    { 362, "Dairy", "Cuajada" },
                    { 363, "Dairy", "Egg Powder" },
                    { 364, "Dairy", "Peppermint Mocha Creamer" },
                    { 365, "Dairy", "Key Lime Curd" },
                    { 366, "Dairy", "Chocolate Milk Powder" },
                    { 367, "Dairy", "Buffalo Milk" },
                    { 368, "Dairy", "Sheep Milk" },
                    { 369, "Dairy", "Goat Kefir" },
                    { 370, "Dairy", "Greek Yogurt" },
                    { 371, "Dairy", "Shortening" },
                    { 372, "Dairy", "Sweetened Condensed Milk" },
                    { 373, "Dairy", "Ice Cream" },
                    { 374, "Dairy", "Frosting" },
                    { 375, "Dairy", "Thickened Cream" },
                    { 376, "Dairy", "Dulce de Leche" },
                    { 377, "Dairy", "Chocolate Frosting" },
                    { 378, "Dairy", "Chocolate Milk" },
                    { 379, "Dairy", "Whey" },
                    { 380, "Dairy", "Frozen Yogurt" },
                    { 381, "Dairy", "Coffee Creamer" },
                    { 382, "Dairy", "Milk Cream" },
                    { 383, "Dairy", "Scrambled Eggs" },
                    { 384, "Dairy", "Duck Egg" },
                    { 385, "Dairy", "Sky" },
                    { 386, "Dairy", "Pumpkin Spice Coffee Creamer" },
                    { 387, "Dairy", "Honey Greek Yogurt" },
                    { 388, "Dairy", "Powdered Coffee Creamer" },
                    { 389, "Dairy", "Rainbow Sherbet" },
                    { 390, "Dairy", "Amul Butter" },
                    { 391, "Dairy", "Goat Yogurt" },
                    { 392, "Dairy", "Goat Butter" },
                    { 393, "Dairy", "Passionfruit Curd" },
                    { 394, "Dairy", "Sheep-Milk Yogurt" },
                    { 395, "Dairy", "Starter Culture" },
                    { 396, "Dairy", "Cinnamon Sugar Butter Spread" },
                    { 397, "Dairy", "Bulgarian Yogurt" },
                    { 398, "Dairy", "Key Lime Yogurt" },
                    { 399, "Dairy", "Tvorog" },
                    { 400, "Dairy", "Liquid Rennet" },
                    { 401, "Dairy", "Strawberry Milk" },
                    { 402, "Dairy", "Yogurt Drink" },
                    { 403, "Dairy", "Evaporated Goat Milk" },
                    { 404, "Dairy", "Vanilla Milk" },
                    { 405, "Dairy", "Kashk" },
                    { 406, "Dairy", "Ego" },
                    { 407, "Dairy", "Heavy Cream" },
                    { 408, "Meat", "Deli Ham" },
                    { 409, "Meat", "Sweet Italian Sausage" },
                    { 410, "Meat", "Beef Roast" },
                    { 411, "Meat", "Beef Stew Meat" },
                    { 412, "Meat", "Pancetta" },
                    { 413, "Meat", "Ground Lamb" },
                    { 414, "Meat", "Breakfast Sausage" },
                    { 415, "Meat", "Salami" },
                    { 416, "Meat", "Beef Short Ribs" },
                    { 417, "Meat", "Hot Italian Sausage" },
                    { 418, "Meat", "Boneless Lamb" },
                    { 419, "Meat", "Pork Roast" },
                    { 420, "Meat", "Bone-in Ham" },
                    { 421, "Meat", "Lamb Chops" },
                    { 422, "Meat", "Veal Steak" },
                    { 423, "Meat", "Beef Sausage" },
                    { 424, "Meat", "Ham Steak" },
                    { 425, "Meat", "Bratwurst" },
                    { 426, "Meat", "Frozen Meatballs" },
                    { 427, "Meat", "Rabbit" },
                    { 428, "Meat", "Ground Beef" },
                    { 429, "Meat", "Pork Chops" },
                    { 430, "Meat", "Beef Steak" },
                    { 431, "Meat", "Prosciutto" },
                    { 432, "Meat", "Sausage" },
                    { 433, "Meat", "Chorizo" },
                    { 434, "Meat", "Pork Loin" },
                    { 435, "Meat", "Pork Nibs" },
                    { 436, "Meat", "Beef Sirloin" },
                    { 437, "Meat", "Brisket" },
                    { 438, "Meat", "Leg of Lamb" },
                    { 439, "Meat", "Pork Fillet" },
                    { 440, "Meat", "Ground Pork" },
                    { 441, "Meat", "Pepperoni" },
                    { 442, "Meat", "Pork Shoulder" },
                    { 443, "Meat", "Smoked Sausage" },
                    { 444, "Meat", "Hot Dog" },
                    { 445, "Meat", "Kielbasa" },
                    { 446, "Meat", "Pork Belly" },
                    { 447, "Meat", "Andouille" },
                    { 448, "Meat", "Pulled Pork" },
                    { 449, "Meat", "Pork Cutlets" },
                    { 450, "Meat", "Veal Cutlet" },
                    { 451, "Meat", "Mexican Chorizo" },
                    { 452, "Meat", "Country Style Ribs" },
                    { 453, "Meat", "Smoked Ham Hock" },
                    { 454, "Meat", "Raw Chorizo" },
                    { 455, "Meat", "Serrano Ham" },
                    { 456, "Meat", "Hard Salami" },
                    { 457, "Meat", "Veal Shank" },
                    { 458, "Meat", "Lap Cheong" },
                    { 459, "Meat", "Beef Shank" },
                    { 460, "Meat", "Country Ham" },
                    { 461, "Meat", "Gammon Joint" },
                    { 462, "Meat", "Bologna" },
                    { 463, "Meat", "Roast Beef" },
                    { 464, "Meat", "Pork Spare Ribs" },
                    { 465, "Meat", "Lamb Shoulder" },
                    { 466, "Meat", "Canadian Bacon" },
                    { 467, "Meat", "Lamb Shank" },
                    { 468, "Meat", "Venison" },
                    { 469, "Meat", "Mixed Ground Meat" },
                    { 470, "Meat", "Ham Hock" },
                    { 471, "Meat", "Lamb Loin" },
                    { 472, "Meat", "Pork Back Ribs" },
                    { 473, "Meat", "Black Forest Ham" },
                    { 474, "Meat", "Soup Bones" },
                    { 475, "Meat", "Beef Liver" },
                    { 476, "Meat", "Cocktail Sausage" },
                    { 477, "Meat", "Boneless Ham" },
                    { 478, "Meat", "Ground Venison" },
                    { 479, "Meat", "Blood Sausage" },
                    { 480, "Meat", "Fresh Sausage" },
                    { 481, "Meat", "Boneless Beef Short Ribs" },
                    { 482, "Meat", "Cooked Pork" },
                    { 483, "Meat", "Burger Patty" },
                    { 484, "Meat", "Sausage Patty" },
                    { 485, "Meat", "Beef Shoulder" },
                    { 486, "Meat", "Ground Pork Sausage" },
                    { 487, "Meat", "Ground Sausage" },
                    { 488, "Meat", "Bacon Bits" },
                    { 489, "Meat", "Beef Ribs" },
                    { 490, "Meat", "Pork Butt" },
                    { 491, "Meat", "Mutton" },
                    { 492, "Meat", "Oxtail" },
                    { 493, "Meat", "Lamb Leg" },
                    { 494, "Meat", "Pork Jowl" },
                    { 495, "Meat", "Beef Tenderloin" },
                    { 496, "Meat", "Wiener" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CookingDifficulty", "CreatorId", "CuisineType", "DateCreated", "ImageName", "MealType", "Name", "Preparation", "PreparationTime", "ServingCount" },
                values: new object[,]
                {
                    { 1, "Beginner", 1, "American", new DateOnly(2024, 12, 15), null, "Breakfast", "Pancakes", "Mix ingredients and cook on a skillet until golden brown.", 20, 4 },
                    { 2, "Intermediate", 2, "Italian", new DateOnly(2024, 12, 15), null, "Lunch", "Tomato Soup", "Blend tomatoes and simmer with spices.", 30, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_IngredientId",
                table: "RecipeIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CreatorId",
                table: "Recipes",
                column: "CreatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}