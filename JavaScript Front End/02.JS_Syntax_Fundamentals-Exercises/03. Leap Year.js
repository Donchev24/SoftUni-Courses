function leapYear(year) {
    if ((year % 400 === 0) || (year % 4 === 0 && year % 100 !== 0) ) {
        console.log(`yes`);
    }
    else {
        console.log(`no`);
    }
}

leapYear(2000);