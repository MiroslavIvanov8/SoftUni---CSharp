function colorize() {
    const tableRowElements = document.querySelectorAll('table tbody tr:nth-child(even)');
    
    for (const row of tableRowElements) {
        row.style.backgroundColor = 'teal';
    }
}
