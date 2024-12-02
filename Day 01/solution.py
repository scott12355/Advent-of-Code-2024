# Define file path
file_path = "lists.txt"

# Initialize two empty lists
list1 = []
list2 = []

# Open the file and read line by line
with open(file_path, 'r') as file:
    for line in file:
        # Split the line into two parts and strip any whitespace
        parts = line.strip().split()
        if len(parts) == 2:  # Ensure there are exactly two numbers on the line
            # Convert parts to integers and append to respective lists
            list1.append(int(parts[0]))
            list2.append(int(parts[1]))


left_sorted = sorted(list1)
right_sorted = sorted(list2)
# print("List 1:", left_sorted)
# print("List 2:", right_sorted)
# Order the lists
# Compute the total distance
total_distance = sum(abs(l - r) for l, r in zip(left_sorted, right_sorted))
print(total_distance)


product_sum = 0
for l_value in left_sorted:
   product_sum += l_value * right_sorted.count(l_value)
print(product_sum)