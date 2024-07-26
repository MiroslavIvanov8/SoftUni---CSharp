function extract(content) {

    const text = document.getElementById(content);
    const pattern = /\(([^)]+)\)/g;

    const matches = text.textContent.matchAll(pattern);
    const result = Array.from(matches).map(match => match[1]).join(';')

    return result;
}

