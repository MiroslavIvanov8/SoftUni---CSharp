console.log(formatGrade(2));


function formatGrade(grade){
    let stringResult = '';
    if(grade < 3){
        return `Fail (2)`;
    } else if (grade < 3.50){
        stringResult = 'Poor';
    } else if (grade < 4.50){
        stringResult = 'Good';
    } else if (grade < 5.50){
        stringResult = 'Very good';
    } else {
        stringResult = 'Excellent';
    }

     return `${stringResult} (${grade.toFixed(2)})`

}