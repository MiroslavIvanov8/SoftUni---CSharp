function printEmployees(input){
    let register = {};

    input.forEach(entry => {
        let name = entry;
        let personalNumber = name.length;

        register[name] = personalNumber;
    })

    for (const key in register) {
        console.log(`Name: ${key} -- Personal Number: ${register[key]}`);
    }
}

printEmployees([
    'Samuel Jackson',
    'Will Smith',
    'Bruce Willis',
    'Tom Holland'
    ]
    );
