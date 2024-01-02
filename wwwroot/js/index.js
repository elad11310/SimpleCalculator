
const resultTextArea = document.getElementById('resultTextArea');


// This funciton runs whenever the page loads for making api request to get all operations.
document.addEventListener('DOMContentLoaded', async function () {

    try {
        var response = await makeApiRequest("/api/operations/getalloperations")
        if (!response.ok) {
            throw new Error('Network response was not ok.');
        }
        const data = await response.json();

        const selectList = document.getElementById('OperationSelectList');

        // Loop through the data and create options
        data.data.forEach(value => {
            // Making sure the first letter is capitalized
            const capitalizedValue = value.charAt(0).toUpperCase() + value.slice(1);
            const option = document.createElement('option');
            option.value = capitalizedValue;
            option.text = capitalizedValue;
            selectList.appendChild(option);
        })

    } catch (error) {

        appendResult(resultTextArea, error);


    }



});


const calculateBtn = document.getElementById('CalculateBtn');
calculateBtn.addEventListener('click', async () => {

    const fieldOne = document.getElementById('FieldOne')?.value;
    const fieldTwo = document.getElementById('FieldSecond')?.value;
    const operation = document.getElementById('OperationSelectList')?.value;
    const selectElement = document.getElementById('OperationSelectList');
    const selectedOption = selectElement.value;
    let errorMsg;


    // Checking that each field is not empty and not contains only spaces
    if (!fieldOne || fieldOne.trim() === '' || !fieldTwo || fieldTwo.trim() === '') {
        errorMsg = "Please fill the fields";
        appendResult(resultTextArea, errorMsg);
        return;
    }

    // If an option is selected
    if (selectedOption !== '--Operation--') {

        const request = {
            OperandA: fieldOne,
            operation: operation,
            OperandB: fieldTwo
        };

        try {
            let response = await makeApiRequest("/api/operations/execute", "POST", JSON.stringify(request));
            const res = await response.json();
            if (!response.ok) {
                appendResult(resultTextArea, res.errorMessage);
            }
            else {

                // Check if the result is a number to round the result only five numbers after the dot
                if (!isNaN(res.data) && checkArithmeticAction(request.operation)) {
                    let roundedNumber = parseFloat(res.data).toFixed(5);
                    appendResult(resultTextArea, roundedNumber);
                } else {
                    appendResult(resultTextArea, res.data);
                }


                // Trying to get historic data
                await getHistoricData(request.operation);
            }

        }
        catch (error) {
            appendResult(resultTextArea, error);
        }


    } else {
        errorMsg = "Please select an opreation.";
        appendResult(resultTextArea, errorMsg);
    }




});

function checkArithmeticAction(operation) {
    return operation === 'Addition' || operation === 'Subtraction' || operation === 'Power'
        || operation === 'Multiplication' || operation === 'Division' || operation === 'Modulus';
}

async function getHistoricData(operation) {

    try {
        response = await makeApiRequest(`/api/operations/gethistoricdata?operation=${operation}`);
        if (!response.ok) {
            appendResult(resultTextArea, response.statusText);
        }
        else {
            const res = await response.json();
            Object.keys(res.data).forEach(key => {
                appendResult(resultTextArea, res.data[key], key);
            });

        }
    }
    catch (error) {
        appendResult(resultTextArea, error);
    }

}

function appendResult(textArea, data, specificValue = null) {

    if (specificValue) {
        textArea.value += '\n';
        textArea.value += specificValue + ': '
        if (isObject(data)) {
            Object.entries(data).forEach(([key, value]) => {
                textArea.value += `${isObject(value) ? JSON.stringify(value) : value}\n`;
            });
        }
        else {
            textArea.value += data + '\n';
        }
    }
    else {
        textArea.value = "";
        textArea.value += `Result: ${data}`;

    }




}
function isObject(data) {
    return data !== null && typeof data === 'object';
}
function makeApiRequest(url, method = "GET", body = null) {
    let headers = {};

    let options = {
        method: method,
        headers: headers
    };
    if (body) {
        options['body'] = body;
        headers['Content-Type'] = 'application/json';
    }
    return fetch(url, options);
}


