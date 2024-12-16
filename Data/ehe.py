import pandas as pd
import re

# Load the CSV file
file_path = "Food Ingredients and Recipe Dataset with Image Name Mapping.csv"  # Update with your file path
data = pd.read_csv(file_path)

# Helper functions to infer values
def infer_cuisine(title, ingredients):
    if pd.isna(title) or pd.isna(ingredients):
        return 'Unknown'
    
    cuisines = {
        'Italian': ['pasta', 'pizza', 'risotto', 'parmesan', 'mozzarella', 'Italian'],
        'Korean': ['kimchi', 'bulgogi', 'gochujang', 'bibimbap', 'korean', 'Korean'],
        'Mexican': ['taco', 'burrito', 'quesadilla', 'salsa', 'cilantro', 'Mexican'],
        'Indian': ['curry', 'masala', 'paneer', 'dal', 'tandoori', 'Indian'],
        'Chinese': ['dumpling', 'soy sauce', 'ginger', 'stir-fry', 'noodle', 'Chinese'],
        'Japanese': ['sushi', 'teriyaki', 'miso', 'sashimi', 'udon', 'Japanese'],
        'French': ['croissant', 'ratatouille', 'beurre', 'creme', 'baguette', 'French'],
        'American': ['burger', 'barbecue', 'cornbread', 'mac and cheese', 'American'],
        'Thai': [
            'coconut milk', 'curry paste', 'lemongrass', 'galangal', 
            'thai basil', 'green curry', 'red curry', 'tom yum', 
            'pad thai', 'sticky rice', 'tom kha'
        ],
    }
    
    title_lower = title.lower()
    ingredients_lower = ingredients.lower()
    
    for cuisine, keywords in cuisines.items():
        # Ensure at least 2 unique keywords are matched for Thai
        if cuisine == 'Thai':
            thai_matches = sum(keyword in ingredients_lower for keyword in keywords)
            if thai_matches >= 2:
                return 'Thai'
        else:
            if any(keyword in title_lower for keyword in keywords) or any(keyword in ingredients_lower for keyword in keywords):
                return cuisine
                
    return 'Global'

def infer_meal_type(title):
    if pd.isna(title):
        return 'Dinner'  # Default assumption
    if any(keyword in title.lower() for keyword in ['pancake', 'breakfast', 'toast', 'egg', 'morning', 'waffle', 'cereal', 'omelette', 'bacon']):
        return 'Breakfast'
    elif any(keyword in title.lower() for keyword in ['dinner', 'roast', 'stew', 'casserole', 'gravy', 'meatloaf', 'pot roast']):
        return 'Dinner'
    elif any(keyword in title.lower() for keyword in ['lunch', 'sandwich', 'wrap', 'salad', 'bento', 'snack', 'panini', 'brunch']):
        return 'Lunch'
    else:
        return 'Dinner'  # Default assumption

def infer_difficulty(ingredients, instructions, title):
    if pd.isna(ingredients) or pd.isna(instructions):
        return 'Beginner'
    
    # Check if "easy" is in both the title and instructions
    if "easy" in title.lower() and "easy" in instructions.lower():
        return 'Beginner'
    
    # Count ingredients and steps
    num_ingredients = len(re.findall(r"['\"](.*?)['\"]", ingredients))
    num_steps = len(re.split(r'[.!?]', instructions))  # Split on common sentence delimiters
    
    # Adjusted thresholds for difficulty levels
    if num_ingredients < 7 and num_steps < 5:
        return 'Beginner'
    elif num_ingredients < 15 and num_steps < 15:
        return 'Intermediate'
    else:
        return 'Difficult'

def infer_prep_time(instructions):
    if pd.isna(instructions):
        return 30  # Default placeholder
    num_steps = len(re.split(r'[.!?]', instructions))  # Account for multiple sentence delimiters
    return max(10, num_steps * 5)  # Assuming 5 minutes per step as a baseline

def infer_servings(instructions):
    if pd.isna(instructions):
        return 4  # Default
    match = re.search(r'\bserves? (\d+)', instructions.lower())  # Allow for both "serve" and "serves"
    if match:
        return int(match.group(1))
    return 4  # Default

# Apply inference to each row
data['CuisineType'] = data.apply(lambda row: infer_cuisine(row['Title'], row['Ingredients']), axis=1)
data['MealType'] = data['Title'].apply(infer_meal_type)
data['Cooking Difficulty'] = data.apply(lambda row: infer_difficulty(row['Ingredients'], row['Instructions'], row['Title']), axis=1)
data['PreparationTime'] = data['Instructions'].apply(infer_prep_time)
data['ServingCount'] = data['Instructions'].apply(infer_servings)
data['CreatorId'] = None  # Set to None as required

# Save the updated dataset
output_file_path = "recipes.csv"  # Output file named 'recipes.csv'
data.to_csv(output_file_path, index=False)

print(f"Dataset updated and saved to {output_file_path}")
