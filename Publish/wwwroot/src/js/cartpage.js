import { get, remove } from './cart.js'
const carts = document.querySelector('.carts');
var cartCounter = document.querySelector('.cartCounter');


window.addEventListener('load', async () => {
    const products = await fetch("/api/products").then(x => x.json());
    function draw() {
        carts.innerHTML = "";
        get().forEach((productId, index) => {
            var product = products.find(x => x.id == productId);
            carts.innerHTML += `<tr> <th scope="row">${index + 1}</th> <td>${product.name}</td><td>${product.price}</td><td> <button class='btn btn-danger deleteProduct' data-id='${product.id}'><i class="fas fa-trash-alt" data-id='${product.id}'></i></button> </td></tr>`;
        })
        document.querySelectorAll('.deleteProduct').forEach(button => {
            button.addEventListener('click', (e) => {
                var id = e.target.dataset.id;
                if (id) {
                    remove(id);
                    draw();
                    cartCounter.innerHTML = get()?.length ?? 0;
                }
            });
        });
    }

    draw();
});


