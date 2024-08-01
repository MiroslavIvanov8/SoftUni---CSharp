function focused() {
    const inputEls = document.querySelectorAll('input[type=text]');

    inputEls.forEach((el) => el.addEventListener('focus', (e) => {
            e.currentTarget.parentElement.classList.add('focused');
    }))

    inputEls.forEach((el) => el.addEventListener('blur' , (e) => {
            e.currentTarget.parentElement.classList.remove('focused');
    }))
    
}
