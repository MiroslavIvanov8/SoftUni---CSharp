function lockedProfile() {

    //Add event listener to show more button
    const showMoreBtns = document.querySelectorAll('button');

    function showMoreClickHandler(button) {
        button.addEventListener('click', (e) => {

            const divProfile = e.target.parentElement;
            const checkedRadioBtn = [...divProfile.querySelectorAll('input[type=radio]')]
                .filter((btn) => btn.checked);
                            
            if (checkedRadioBtn[0].value === 'lock') {
                return;
            } else {
                const [email, age] = e.target.parentElement.querySelectorAll('input[type=email]');

                const hiddenDivEl = email.parentElement;
               
                
                if (hiddenDivEl.style.display === 'none' ||
                    hiddenDivEl.style.display === ""
                ) {
                    hiddenDivEl.style.display = 'block';
                    e.target.textContent = 'Hide it';
                } else {
                    hiddenDivEl.style.display = 'none';
                    e.target.textContent = 'Show more';
                }
            }
        })
    }

    showMoreBtns.forEach((button) => showMoreClickHandler(button));

}
