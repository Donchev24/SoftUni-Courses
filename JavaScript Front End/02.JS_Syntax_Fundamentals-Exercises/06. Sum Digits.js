function sumDigits(num) {

    let sum = 0;
    let numStr = num.toString();

    for (let i = 0; i < numStr.length; i++) {
        sum += Number(numStr[i]);
    }

    console.log(sum);
}

sumDigits(245678);