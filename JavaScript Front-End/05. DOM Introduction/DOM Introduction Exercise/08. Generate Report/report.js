function generateReport() {
    

    const thEls = document.querySelectorAll('thead tr th');
    const tbodyRows = document.querySelectorAll('tbody tr');

    const checkedInputEls = [...thEls]
    .map((x, i) =>({input: x.children[0], index: i}))
    .filter((x) => x.input.checked);


    console.log(checkedInputEls);
    debugger;
    
    const outputData = [...tbodyRows].map((tr) => {
       return checkedInputEls.reduce((acc, curr) => {
            acc[curr.input.name] = tr.children[curr.index].textContent
            
            return acc;
        }, {})
    });

    document.querySelector('#output').value = JSON.stringify(outputData);
}
