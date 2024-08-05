function encodeAndDecodeMessages() {
    
    //Get buttons and attach eventHandlers to them
    const [sendBtn, readBtn] = document.querySelectorAll('button');
    const sendTextareaEl = sendBtn.parentElement.querySelector('textarea');
    const receiveTextareaEl = readBtn.parentElement.querySelector('textarea');
    
    sendBtn.addEventListener('click', (e) => {       
        
        //Get the text from the first textarea, encode it 
        const message = Array.from(sendTextareaEl.value).reduce((acc, curr) => {
            return acc += String.fromCharCode(curr.charCodeAt(curr) + 1);
        },"")
        
        //and send it to the second textarea, clear first one    
        sendTextareaEl.value = '';
        receiveTextareaEl.value = message;     
    })     

    readBtn.addEventListener('click', (e) => {
        
        //Decode the text from the second textarea
        const decodedMessage = Array.from(receiveTextareaEl.value).reduce((acc, curr) => {
            return acc += String.fromCharCode(curr.charCodeAt(curr) - 1);
        },"")
        
        receiveTextareaEl.value = decodedMessage;
    })
    
}
