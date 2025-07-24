function calculatePrice(fruit, grams, pricePerKg) {
    
    let pricePerGram = pricePerKg / 1000;
    let money = pricePerGram * grams;
    let weight = grams / 1000;
    console.log(`I need $${money.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${fruit}.`);
    
}

calculatePrice('apple', 1563, 2.35);