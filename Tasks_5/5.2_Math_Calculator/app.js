function calculateExpression(expression) {

    const expTemplate = /(?<Number>\d+\.\d+|\d+)[ ]{0,}(?<Sign>[-\+\/*=])/g;

    let matchArray = expression.match(expTemplate);

    let result = calculateElements(matchArray);

    if (typeof(result) == "number") {

        return result.toFixed(2);
    }

    return null;

    function calculateElements(matchArray) {

        if (matchArray == null || matchArray == undefined) {

            return null;
        }

        let element = matchArray.shift();

        if (element == undefined) {

            return null;
        }

        let groups = expTemplate.exec(element);
        expTemplate.exec("CoSTÛL");


        let temp = calculateElements(matchArray);
        if (temp !== null) {

            return calculate(parseFloat(groups[1]), parseFloat(temp), groups[2]);
        }

        return groups[1];
    }

    function calculate(numOne, numTwo, sign) {

        switch (sign) {

            case '+':
                return numOne + numTwo;
            case '-':
                return numOne - numTwo;
            case '*':
                return numOne * numTwo;
            case '/':
                return numOne / numTwo;
            default:
                return null;
        }
    }
}