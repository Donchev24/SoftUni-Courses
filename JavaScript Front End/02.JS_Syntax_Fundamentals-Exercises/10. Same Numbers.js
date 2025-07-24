function sameNumbers(num) {
    
    let numAsString = String(num);
    let sum = 0;
    let areSame = true;

    for (let i = 0; i < numAsString.length; i++) {

        let currentNum = Number(numAsString[i]);

        sum += currentNum;

        if (i >= 1) {

            let previousNum = Number(numAsString[i - 1]);
            if (currentNum !== previousNum) {
                areSame = false;
            }
        }
    }

    console.log(areSame);
    console.log(sum);
}

sameNumbers(1234);