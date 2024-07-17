function printAddressBook(input){

    let addressBook = {};
    input.forEach(entry => {
        let [name,address] = entry.split(":");
        addressBook[name] = address;
    });
    

    let addressBookArr = Object.entries(addressBook);    
    addressBookArr.sort((a, b) => a[0].localeCompare(b[0]));

    addressBook = Object.fromEntries(addressBookArr);

    for (const key in addressBook) {
        console.log(`${key} -> ${addressBook[key]}`);
    }
}

printAddressBook(['Bob:Huxley Rd',
    'John:Milwaukee Crossing',
    'Peter:Fordem Ave',
    'Bob:Redwing Ave',
    'George:Mesta Crossing',
    'Ted:Gateway Way',
    'Bill:Gateway Way',
    'John:Grover Rd',
    'Peter:Huxley Rd',
    'Jeff:Gateway Way',
    'Jeff:Huxley Rd']
    );
