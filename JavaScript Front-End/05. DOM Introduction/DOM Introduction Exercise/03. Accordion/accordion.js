function toggle() {

    let buttonElement = document.getElementsByClassName('button')[0];
    buttonElement.textContent = buttonElement.textContent === '[Less]' ? '[More]' : '[Less]';

    let extraElement = document.getElementById('extra');
    extraElement.style.display = extraElement.style.display === 'block' ? 'none' : 'block';
}
