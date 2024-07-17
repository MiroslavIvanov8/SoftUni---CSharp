function printObjectToJson(firstName, lastName, hairColor){

    let person = {
        name : firstName,
        lastName,
        hairColor,
    };

    console.log(JSON.stringify(person));

}

printObjectToJson('George', 'Jones', 'Brown');
