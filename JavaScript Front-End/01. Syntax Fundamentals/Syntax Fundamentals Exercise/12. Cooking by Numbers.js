function solve(input, cmd1, cmd2, cmd3, cmd4, cmd5){

    let number = parseInt(input);
    let commands = [cmd1, cmd2, cmd3, cmd4, cmd5];

    for (let i = 0; i < commands.length; i++) {

        let currentCommand = commands[i];

        if(currentCommand == 'chop'){

            number = number / 2;
            console.log(number);

        } else if (currentCommand == 'dice'){

            number = Math.sqrt(number);
            console.log(number);

        } else if (currentCommand == 'spice'){

            number = number + 1;
            console.log(number);

        } else if (currentCommand == 'bake'){

            number = number * 3;
            console.log(number);

        } else if (currentCommand == 'fillet'){

            number = number - number* 0.20;
            console.log(number);
        }
    }
}
solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');

