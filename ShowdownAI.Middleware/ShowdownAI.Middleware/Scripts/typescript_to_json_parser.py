# parses typescript file to json
# entry function is parse_text which will read each line of the file

# once the start of an object is found the closing line will be found
# and the lines in between will be passed to create_object which will 
# convert types and return an object

import json


pokemon_moves = {}
pokemon_moves["moves"] = []

sourceFile = "..\MoveData\move_data.ts"
destinationFile = "..\MoveData\move_data.json"



def try_string_to_bool(value):
    value = True if value == "true" else value
    value = False if value == "false" else value    
    return value


def try_string_to_none(value):
    return None if value == "null" else value


def try_string_to_int(value):
    val = value.lstrip("-")
    negative = False
    if "-" in value and value.lstrip("-").isdecimal():            
        negative = True
    val = int(val) if val.isdecimal() else val
    if isinstance(val, int):
        return val if not negative else val - (val * 2)
    return value


def ignore_line(text):
    things_to_ignore = ["export"]
    if text == "" or any(item_to_ignore in text for item_to_ignore in things_to_ignore) or text.strip().startswith("//"):
        return True
    return False


def trim(text):
    return text.strip().replace("\t", "").replace("\n", "").replace('"', "").replace("'", "")


def find_closing_line(text, startLine, initial_brackets = 0):
    # use initial brackets incase of same line
    additional_open_brackets = -initial_brackets
    for index in range(startLine, len(text)):
        line = text[index]
        
        if "{" in line:
            additional_open_brackets += 1
        
        if "}" in line:
            if additional_open_brackets == 0 or (additional_open_brackets == 1 and "}, {" in line):
                return index
            additional_open_brackets -= 1


def convert_string_to_type(value):
    # throws exception when checking for int if value is an object so try is used
    try:
        # check if array
        if "[" in value and "]" in value:
            arr = value.split("]")[0].replace("[", "").replace("]", "").split(",")
            value = []
            for val in arr:
                value.append(convert_string_to_type(trim(val)))

        # remove trailing comma
        value = value[:-1] if value[len(value)-1] == "," else value

        value = try_string_to_int(value)
        value = try_string_to_none(value)
        value = try_string_to_bool(value)
        
        return value
    except:
        return value


def is_a_function(line):
    func_symbols = ["(", ")", "{"]
    if all(symbol in line for symbol in func_symbols):
        return True
    return False


def convert_one_line_object(value):
    if '{}' in value:
        return {}
    obj = {}
    pairs = value.split(",")
    for pair in pairs:
        if ":" not in pair:
            continue
        [nested_key, nested_value] = pair.split(":", 1)
        if "{" in nested_value and "}" in nested_value:
            nested_value = convert_one_line_object(nested_value[:len(nested_value)-1])
        obj[nested_key.replace("{", "").strip()] = convert_string_to_type(nested_value.replace("}", "").strip()) if type(nested_value) != dict else nested_value
    return obj


# reads the lines passed in and returns an object
def create_object(lines):
    move_properties = {}
    index = 0
    while index < len(lines):
        line = lines[index]
        line = line.split("//")[0]
        if ignore_line(line):
            index += 1
            continue
        if is_a_function(line):
            closing_line = find_closing_line(lines, index+1)
            index = closing_line+1
            continue
        # ignore closing bracket lines and empty lines
        if "}," == line.strip() or "]," == line.strip() or "" == line.strip():
            index += 1
            continue
        
        # multiple attributes on one line
        if line.count(":") > 1 and "}" not in line:
            for pair in line.split(","):
                if trim(pair) == "":
                    continue
                [key, value] = pair.split(":")
                [key, value] = [trim(key), trim(value)]
                move_properties[key] = convert_string_to_type(value)
            index += 1
            continue
            
        [key, value] = line.split(":", 1)
        [key, value] = [trim(key), trim(value)]
        # multiline array
        array_prop = []
        if '[' in value and ']' not in value:
            # array of objects
            while "{" in lines[index+1]:
                value, line_count = parse_text(lines[index:], True)
                array_prop.append(value)
                index += line_count+1
            value = array_prop
        # start of nested object
        if '{' in value:
            # 1 line object
            if '}' in value:
                value = convert_one_line_object(value)
            else:
                value, line_count = parse_text(lines[index:], True)
                index += line_count

        move_properties[key] = convert_string_to_type(value)

        index += 1
    return move_properties


def parse_text(fileContents, nested):
    startLine = 0
    stopLine = 0
    index = 0
    while index < len(fileContents):
        line = trim(fileContents[index])

        if ignore_line(line):
            index += 1
            continue
        
        # start of object
        if "{" in line:
            startLine = index+1
            id = line.split(":")[0].strip()
            stopLine = find_closing_line(fileContents, startLine)
            move_obj = create_object(fileContents[startLine:stopLine])            
            index = stopLine
            if nested:
                line_count = stopLine - startLine
                return move_obj, line_count
            else:
                pokemon_moves["moves"].append({id: move_obj})
        
        index += 1
        



with open(sourceFile) as file:
    fileContents = file.readlines()

parse_text(fileContents, False)
with open(destinationFile, "w", encoding='utf-8') as file:
    json.dump(pokemon_moves, file, ensure_ascii=False, indent=4)