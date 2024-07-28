function solve() {
  
    const text = document.getElementById('input')
                         .value
                         .trim()
                         .split('.')
                         .slice(0,this.length - 1);

    let outputElement = document.getElementById('output');                     
    
    //debugger;
    let paragraphText = '';
    let cnt = 0;
    for (let i = 0; i < text.length; i++) {
      paragraphText += text[i] + '.';
      cnt++;

      if (cnt % 3 === 0 || i === text.length - 1) {
          const pElement = document.createElement('p');
          pElement.textContent = paragraphText.trim();
          outputElement.appendChild(pElement);
          paragraphText = '';
      }
  }
}

