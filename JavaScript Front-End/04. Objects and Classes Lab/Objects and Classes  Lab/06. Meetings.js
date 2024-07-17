function printMeetingMessages(input = []){
    let meetings = {};

    input.forEach(entry => {
        let [weekday, person] = entry.split(' ');

        if(!meetings[weekday]){
            meetings[weekday] = person;
            console.log(`Scheduled for ${weekday}`);
        } else{
            console.log(`Conflict on ${weekday}!`);
        }
    });

    for (const key in meetings) {
        console.log(`${key} -> ${meetings[key]}`);
    }
}

printMeetingMessages(['Monday Peter',
    'Wednesday Bill',
    'Monday Tim',
    'Friday Tim']
   );
