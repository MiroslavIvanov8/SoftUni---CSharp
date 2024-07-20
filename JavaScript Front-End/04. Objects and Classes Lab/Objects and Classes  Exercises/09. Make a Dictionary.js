function printDictionary(input){
    
    let dictionary = {};
    input.forEach(jsonString => {
        const parsedObject = JSON.parse(jsonString);

        Object.assign(dictionary, parsedObject);
    })

    let entries = Object.entries(dictionary);
    entries = entries.sort((a, b) => a[0].localeCompare(b[0]));
    const sortedDictionary = Object.fromEntries(entries);

    for (const term in sortedDictionary) {
        console.log(`Term: ${term} => Definition: ${sortedDictionary[term]}`);
    }
}

printDictionary([
    '{"Coffee":"A hot drink made from the roasted and ground seeds (coffee beans) of a tropical shrub."}',
    '{"Bus":"A large motor vehicle carrying passengers by road, typically one serving the public on a fixed route and for a fare."}',
    '{"Boiler":"A fuel-burning apparatus or container for heating water."}',
    '{"Tape":"A narrow strip of material, typically used to hold or fasten something."}',
    '{"Microphone":"An instrument for converting sound waves into electrical energy variations which may then be amplified, transmitted, or recorded."}'
    ]
    );

