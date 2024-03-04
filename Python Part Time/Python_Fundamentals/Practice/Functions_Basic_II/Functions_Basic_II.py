# 1 - Countdown
def countdown(num):
    result = []
    for i in range(num, -1, -1):
        result.append(i)
    print(result)
    return result

# 2 - Print and Return 
def print_and_return(numbers):
    print(numbers[0])
    return numbers[1]

# 3 - First Plus Length
def first_plus_length(input_list):
    return input_list[0] + len(input_list)

# 4 - Values Greater than Second 
def values_greater_than_second(input_list):
    if len(input_list) < 2:
        return False

    count = 0
    new_list = []

    for value in input_list:
        if value > input_list[1]:
            count += 1
            new_list.append(value)

    print(count)
    return new_list

# 5 - This Length, That Value 
def length_and_value(size, value):
    new_list = []
    for i in range(size):
        new_list.append(value)
    return new_list





