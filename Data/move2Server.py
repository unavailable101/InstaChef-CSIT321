import sqlite3
import pyodbc
import random  # For random category generation

# Connect to the SQLite database
sqlite_conn = sqlite3.connect("recipes.db")
sqlite_cursor = sqlite_conn.cursor()

# Connect to SQL Server
sql_server_conn = pyodbc.connect('DRIVER={ODBC Driver 17 for SQL Server};Server=laptop-7sj2g4a6;Database=InstaChefDb;Trusted_Connection=yes;')
sql_server_cursor = sql_server_conn.cursor()

# Retrieve data from SQLite
sqlite_cursor.execute("SELECT id, title, ingredients, instructions, image_name, cuisine_type, meal_type, cooking_difficulty, preparation_time, serving_count FROM recipes")
rows = sqlite_cursor.fetchall()

# Insert data into SQL Server with column mapping
for row in rows:
    title = row[1]  # row[1] is the 'title' field from SQLite
    
    # Skip if title is NULL or empty
    if not title:
        print(f"Skipping record with ID {row[0]} due to empty or NULL title.")
        continue

    # Check if the 'title' from SQLite already exists in SQL Server 'ChefRecipes' table
    sql_server_cursor.execute("""
        SELECT COUNT(*) FROM ChefRecipes WHERE Name = ?
    """, (title,))  # row[1] is the 'title' field from SQLite

    if sql_server_cursor.fetchone()[0] == 0:  # If no rows are found, insert
        category = random.randint(1, 5)  # Randomize category between 1 and 5
        
        # Check if the 'instructions' field is NULL or empty
        preparation = row[3] if row[3] else "No instructions provided"
        
        # Insert the data into SQL Server
        sql_server_cursor.execute("""
            INSERT INTO ChefRecipes (
                Name, Description, Preparation, ImageName, CuisineType, MealType, CookingDifficulty, PreparationTime, ServingCount, Category
            )
            VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
        """, (
            title,  # title -> Name
            row[2],  # ingredients -> Description
            preparation,  # instructions -> Preparation
            row[4],  # image_name -> ImageName
            row[5],  # cuisine_type -> CuisineType
            row[6],  # meal_type -> MealType
            row[7],  # cooking_difficulty -> CookingDifficulty
            row[8],  # preparation_time -> PreparationTime
            row[9],  # serving_count -> ServingCount
            category  # Randomized Category value
        ))

# Commit changes to SQL Server
sql_server_conn.commit()

# Close both SQLite and SQL Server connections
sqlite_cursor.close()
sqlite_conn.close()
sql_server_cursor.close()
sql_server_conn.close()

print("Data successfully transferred from SQLite to SQL Server.")
