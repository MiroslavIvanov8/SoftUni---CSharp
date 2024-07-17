function printJSONObject(input){
    let object = JSON.parse(input);
    for (const key in object) {
        console.log(`${key}: ${object[key]}`);
    }
}

printJSONObject('{"name": "George", "age": 40, "town": "Sofia"}');
