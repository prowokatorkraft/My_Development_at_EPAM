function removeRepeatingChars(str) {

    if (typeof (str) != "string") {

        return null;
    }

    let arrayChar = new Array(0);

    findRepeatingChar();

    return deletedChars();

    function isRepeatingChar(ch, world, reiteration) {

        for (let i in world) {

            if (ch === world[i]) {

                reiteration--;

                if (reiteration <= -1) {

                    return true;
                }
            }
        }

        return false;
    }

    function findRepeatingChar() {

        let strArray = str.split(" ");

        for (let world in strArray) {

            for (let ch in strArray[world]) {

                if (isRepeatingChar(strArray[world][ch], strArray[world], 1)) {

                    if (-1 == arrayChar.findIndex((value, index, array) => value === strArray[world][ch])) {

                        arrayChar.push(strArray[world][ch]);
                    }
                }
            }
        }
    }

    function deletedChars() {

        let newStr = "";

        for (let iCh = 0; iCh < str.length; iCh++) {

            if (arrayChar.findIndex((value, index, array) => value === str[iCh]) == -1) {

                newStr += str[iCh];
            }
        }

        return newStr;
    }
}