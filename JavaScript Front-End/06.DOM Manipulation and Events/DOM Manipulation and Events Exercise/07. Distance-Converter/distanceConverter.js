function attachEventsListeners() {

    //Get fromOptionValue
    const [inputDistanceEl, outputDistanceEl] = document.querySelectorAll('input[type=text]');
    outputDistanceEl.removeAttribute('disabled');

    //Get ConvertButton
    //Attach eventlistener to convertButton
    //Calculate
    function toMeters(value, units) {

        switch (units) {
            case 'km':
                return value * 1000;            
            case 'cm':
                return value * 0.01;
            case 'mm':
                return value * 0.001;
            case 'mi':
                return value * 1609.34;
            case 'yrd':
                return value * 0.9144;
            case 'ft':
                return value * 0.3048;
            case 'in':
                return value * 0.0254;
            default:
                return value;
        }
    }

    function convert(value, units) {

        switch (units) {
            case 'km':
                return value / 1000;            
            case 'cm':
                return  value / 0.01;
            case 'mm':
                return  value / 0.001;
            case 'mi':
                return value / 1609.34;
            case 'yrd':
                return value / 0.9144;
            case 'ft':
                return value / 0.3048;
            case 'in':
                return value / 0.0254;
            default:
                return value;
        }
    }
    const convertBtn = inputDistanceEl.parentNode.querySelector('input[type=button]');
    convertBtn.addEventListener('click', (e) => {
        const inputUnits = inputDistanceEl.parentNode.children[2].value;
        const outputUnits = outputDistanceEl.parentElement.children[2].value;

        const value = Number(inputDistanceEl.value);
        const valueInMeters = toMeters(value, inputUnits);
        const convertedValue = convert(valueInMeters, outputUnits);

        outputDistanceEl.value = convertedValue;
    })   
}
