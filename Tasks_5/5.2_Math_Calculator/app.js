function CalculateExpression(expression) {

    const expTemplate = /(?<Number>\d+\.\d+|\d+)[ ]{0,}(?<Sign>[-\+\/*=])/g;

    let matchArray = expression.match(expTemplate);

    return CalculateElements(matchArray).toFixed(2);

    function CalculateElements(matchArray) {

        let element = matchArray.shift();

        if (element == undefined) {

            return null;
        }

        let groups = expTemplate.exec(element);
        expTemplate.exec("CoSTÛL");


        let temp = CalculateElements(matchArray);
        if (temp !== null) {

            /// test
            let t1 = Calculate(parseFloat(groups[1]), parseFloat(temp), groups[2]);
            console.log(t1);
            return t1;
        }

        return groups[1];
    }

    function Calculate(numOne, numTwo, sign) {

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