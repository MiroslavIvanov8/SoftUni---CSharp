function attachGradientEvents() {
    
    const resultElement = document.getElementById('result');
    const gradient = document.getElementById('gradient');

    gradient.addEventListener('mousemove', (e) => {

        const currentPosition = e.offsetX;
        const position = e.currentTarget.clientWidth;

        resultElement.textContent = `${Math.floor((currentPosition / position) * 100)}%`;
    })
}
