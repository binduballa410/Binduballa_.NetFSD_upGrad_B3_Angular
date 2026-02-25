import {
    calculateTotal } from "./cartUtils.js";
    const products = [
        {name: "Laptop", price:50000, quantity: 1 },
        {name: "Mouse", price:600, quantity: 2},
        {name: "Keyboard", price:1500, quantity: 1}
    ];

    const invoiceLines = products.map(product => 
        { return `${product.name} - ₹${product.price} * ${product.quantity} = ₹${product.price * product.quantity}`;
    });
    const totalAmount = calculateTotal(products);
    console.log(`
        --------Shopping Cart Summary--------


        ${invoiceLines.join("\n")}

        Total Amount: ₹${totalAmount}
        `);
