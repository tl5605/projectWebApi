﻿let totalPrice = 0;
let countItem = 0;

const drawProducts = () => {

    const basket = JSON.parse(sessionStorage.getItem("basket")) || [];
    const template = document.getElementById("temp-row");

    basket.forEach((p) => {
        const card = template.content.cloneNode(true)
        card.querySelector('img').src = '../Images/' + p.product.imageUrl
        card.querySelector('.description').textContent = p.product.description
        card.querySelector('.quantity').textContent = p.quantity
        card.querySelector('.price').textContent = p.product.price * p.quantity
        card.querySelector('button').addEventListener('click', () => { removeProductFromBasket(p) });
        //card.querySelector('button').addEventListener('click', event => addToBasket(product))
        document.getElementById("items").appendChild(card)
    });
    updateMessage(basket);
}

const removeProductFromBasket = (product) => {
    let quantity = JSON.parse(sessionStorage.getItem('quantity'));
    quantity -= product.quantity;
    sessionStorage.setItem('quantity', JSON.stringify(quantity));

    let basket = JSON.parse(sessionStorage.getItem('basket'));

    const index = basket.findIndex(p => p.product.productId === product.product.productId);

    basket.splice(index, 1);
    sessionStorage.setItem('basket', JSON.stringify(basket));

    document.getElementById("items").replaceChildren();
  
    drawProducts();
}

const message = () => {
    document.getElementById('totalAmount').textContent = totalPrice;
    document.getElementById('itemCount').textContent = countItem;
}

const updateMessage = (basket) => {
    basket.forEach((p) => {
        totalPrice += p.product.price * p.quantity;
        countItem += p.quantity;
    });
    message();
}

const placeOrder = async () => {

    const basket = JSON.parse(sessionStorage.getItem("basket"));
    const user = JSON.parse(sessionStorage.getItem("userId"));
    const price = JSON.parse(sessionStorage.getItem('price'));

    if (user == null) {
        alert("אינך מחובר");
        window.location.href = "Login.html";
    }
    let orderItems = [];

    basket.forEach((obj) => {
        orderItems.push({ productId: obj.product.productId, quantity: obj.quantity })
    })

    const newOrder = {
        "OrderDate": new Date(),
        "OrderSum": price,
        "UserId": user,
        "OrderItems": orderItems
    }
    
    const response = await fetch('api/Orders', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newOrder)
    });

    if (response.ok) {
        sessionStorage.removeItem('basket');
        sessionStorage.removeItem('price');
        sessionStorage.removeItem('quantity');
        alert("הזמנתך בוצע בהצלחה!!!!!!!");
        window.location.href = "Products.html";
    }
}

drawProducts()
