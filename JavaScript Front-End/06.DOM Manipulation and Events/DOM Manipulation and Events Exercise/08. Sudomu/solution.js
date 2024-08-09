function solve() {

    //Get button elements
    const [checkBtn, clearBtn] = document.querySelectorAll('button');
    const checkMsg = document.getElementById('check');
    //Get table element and each tr
    const trEls = document.querySelectorAll('tbody tr');

    //create a boolean method that checks the validity of each row 
    function checkRowsValidity() {
        let check = true;

        for (const tr of trEls) {
            for (const td of tr.children) {
                const inputEl = td.children[0];

                const min = Number(inputEl.min);
                const max = Number(inputEl.max);
                const value = Number(inputEl.value);

                if (value < min || value > max) {
                    check = false;  
                    break; 
                }
            }

            if (!check) {
                break;
            }
        }
        return check;
    }
    function checkSudoku(){
        let rows = [...trEls].map((tr) => tr);
        debugger;
        //Start from here, create a method that iterated through and checks rows and columns validity
        
        
        console.log(cols);
        

    }
    function clearInputFields(e) {
        trEls.forEach((tr) => {
            [...tr.children].forEach((td) => {
                td.children[0].value = '';
            })
        })
        checkMsg.children[0].textContent = '';
    }

    //attach clear button event listener to clear the table
    clearBtn.addEventListener('click', clearInputFields);

    //attach check button event listener to check te table
    checkBtn.addEventListener('click', (e) => {
        const rowsValidity = checkRowsValidity()
        const sudokuSolved = checkSudoku();

    })
    
    // create a boolean method that checks the validity of each column 
    //based on their return decide output action
}
