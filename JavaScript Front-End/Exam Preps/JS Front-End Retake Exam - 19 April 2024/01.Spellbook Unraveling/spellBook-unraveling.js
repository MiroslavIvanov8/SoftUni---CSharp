function solve(input) {

    let spell = input.shift();

    const commands = {
        RemoveEven() {
            let changedSpell = '';
            for (let i = 0; i < spell.length; i++) {
                if (i % 2 === 0) {
                    changedSpell += spell[i];
                }
            }

            console.log(changedSpell);
            spell = changedSpell;

        },
        TakePart(args) {
            const from = args[0];
            const to = args[1];
            let changedSpell = '';

            changedSpell = spell.substring(from, to);

            console.log(changedSpell);
            spell = changedSpell;

        },
        Reverse(args) {
            let substring = args[0];
            if (spell.includes(substring)) {
                spell = spell.replace(substring, '');
                substring = substring.split('').reverse().join('');

                spell += substring;
                console.log(spell);
            } else {
                console.log('Error');
            }

        },

    }

    let commandLine = input.shift();
    while (commandLine !== 'End') {

        const [command, ...args] = commandLine.split('!');
        if (commands[command]) {
            commands[command](args);
        }

        commandLine = input.shift();
    }

    console.log(`The concealed spell is: ${spell}`);

}

solve((["hZwemtroiui5tfone1haGnanbvcaploL2u2a2n2i2m",
    "TakePart!31!42",
    "RemoveEven",
    "Reverse!anim",
    "Reverse!sad",
    "End"])
);
