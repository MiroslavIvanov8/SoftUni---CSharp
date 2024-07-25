function extract(content) {

    const text = document.getElementById(content);
    const textContent = text.textContent;
    const pattern = /\(([^)]+)\)/g;

    const matches = textContent.matchAll(pattern);
    const matchesArr = Array.from(matches);

    const extractedContents = matchesArr.map(match => match[1]);
    const result = extractedContents.join('; ');

    console.log(result);
}

