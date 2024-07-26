function solve() {

  function transformWord(word){
    return word[0].toUpperCase() + word.substring(1).toLowerCase()
  }  

  let text = document.getElementById('text').value;
  const namingConvention = document.getElementById('naming-convention').value;
  let resultElement = document.getElementById('result');

  let result = '';
  const textArr = text.split(' ');
  let currWord = textArr[0];

  if (namingConvention == 'Camel Case') {
    result += currWord.toLowerCase();
  } else if (namingConvention == 'Pascal Case') {
    result += transformWord(currWord);
  } else {
    resultElement.textContent = 'Error!';
    return;
  }

  for (let i = 1; i < textArr.length; i++) {

    let currWord = textArr[i];
    result += transformWord(currWord);

  }

  resultElement.textContent = result;

}
