function calculateTicketPrice (typeOfDay, personAge) {

    let ticketPrice = 0;

    if (typeOfDay === `Weekday`) {
        if (personAge >= 0 && personAge <= 18) {
            ticketPrice = 12;
        }
        else if (personAge > 18 && personAge <= 64) {
            ticketPrice = 18;
        }
        else if (personAge > 64 && personAge <= 122) {
            ticketPrice = 12;
        }
        else {
            console.log(`Error!`);
        }
    }
    else if (typeOfDay === `Weekend`) {
        if (personAge >= 0 && personAge <= 18) {
            ticketPrice = 15;
        }
        else if (personAge > 18 && personAge <= 64) {
            ticketPrice = 20;
        }
        else if (personAge > 64 && personAge <= 122) {
            ticketPrice = 15;
        }
        else {
            console.log(`Error!`);
        }
    }
    else {
        if (personAge >= 0 && personAge <= 18) {
            ticketPrice = 5;
        }
        else if (personAge > 18 && personAge <= 64) {
            ticketPrice = 12;
        }
        else if (personAge > 64 && personAge <= 122) {
            ticketPrice = 10;
        }
        else {
            console.log(`Error!`);
        }
    }

    if (ticketPrice != 0) {
        console.log(`${ticketPrice}$`);
    }
}

calculateTicketPrice('Holiday', 15);