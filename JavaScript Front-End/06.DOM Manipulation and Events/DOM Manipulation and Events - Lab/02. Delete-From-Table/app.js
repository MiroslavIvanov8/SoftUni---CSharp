function deleteByEmail() {
    
    const inputEl = document.querySelector('input');
    const trEls = document.querySelectorAll('tbody tr');
    let found = false;
    
    trEls.forEach(tr => {
        const email = tr.children[1].textContent;
        if(email === inputEl.value){
            tr.remove();
            found = true;
        }
    })

    const resultEl = document.querySelector('div#result');
    if (found) {
        resultEl.textContent = 'Deleted.';
    } else {
        resultEl.textContent = 'Not found.';
    }    
}
