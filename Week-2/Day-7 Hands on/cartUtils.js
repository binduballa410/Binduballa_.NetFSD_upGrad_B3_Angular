export const calculateTotal = (products) => {
    return products.reduce((total, products) =>{
        return total + (products.price * products.quantity);
    }, 0);
};