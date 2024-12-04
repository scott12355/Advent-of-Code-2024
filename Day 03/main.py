import re
# Open the file and read line by line
file_path = "memory.txt"

corruptMemory = ""

with open(file_path, "r") as file:
    corruptMemory = file.read().replace("\n", "")


pattern = r"mul\((\d{1,3}),(\d{1,3})\)"
# pattern = r"mul\(\d{1,3},\d{1,3}\)"
matches = re.findall(pattern, corruptMemory)
# print(matches)

sums = [(int(a)*int(b)) for a, b in matches]
# print(sums)

#get total of  sums array
total_sum = sum(sums)
print(total_sum)


#part 2
corruptMemory = ""
with open(file_path, "r") as file:
    corruptMemory = file.read().replace("\n", "")

# Regex patterns
mul_pattern = r"mul\((\d{1,3}),(\d{1,3})\)"  # Match mul(X, Y), only takes x and y values
control_pattern = r"(do\(\)|don't\(\))"       # Match do() or don't()

# Split memory into instructions
instructions = re.findall(f"{control_pattern}|{mul_pattern}", corruptMemory)
print(instructions)
# Process instructions
mul_enabled = True  # Initially, mul instructions are enabled
total_sum = 0

for instruction in instructions:
    if instruction[0]:  # Control instruction (do() or don't())
        if instruction[0] == "do()":
            mul_enabled = True
        elif instruction[0] == "don't()":
            mul_enabled = False
    elif instruction[1] and instruction[2]:  # mul(X, Y)
        if mul_enabled:
            x, y = int(instruction[1]), int(instruction[2])
            total_sum += x * y

# Output the total sum
print(total_sum)