function hLine() {
    console.log('------------');
}

function printHeader() {
    console.log('~~~-   {@}   -~~~');
    console.log('~- Certificate -~');
    console.log('~~~-  ~---~  -~~~');
}

function printMain() {
    console.log('Main INformation');
}

function printDocument() {
    printHeader();
    hLine();
    printMain();
}

function getFullName(names) {
    return `${names[0]} ${names[1]}`;
}

function formatGrade(grade) {
    let result = '';

    if (grade < 3) {
        result = 'Fail';
    } else if (grade < 3.5) {
        result = 'Poor';
    } else if (grade < 4.5) {
        result = 'Good';
    } else if (grade < 5.5) {
        result = 'Very good';
    } else if (grade <= 6) {
        result = 'Excellent';
    }

    console.log(`${result} (${grade < 3 ? 2 : grade.toFixed(2)})`);
}

function passGrade(grade) {
    return grade >= 3;
}

function printCertificate(grade, names) {
    if (passGrade(grade)) {
        printHeader();
        console.log(getFullName(names));
        formatGrade(grade);
    } else {
        console.log(`${getFullName(names)} does not qualify`);
    }
}

printCertificate(5.25, ['Peter', 'Carter']);
