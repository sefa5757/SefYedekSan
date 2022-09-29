import { subsubCategoryies, products } from './db.js';
import { add } from './cart.js';
const urlParams = new URLSearchParams(window.location.search);
let categoryId = urlParams.get('id');
categoryId = parseInt(categoryId);
if (categoryId === null || isNaN(categoryId))
    window.location.href = window.location.origin;
else {
    window.addEventListener('load', async  ()=> {
        const found = await fetch(`/api/categories/${categoryId}`).then(x => x.json());
        if (!found)
            window.location.href = window.location.origin;
        else {
            const productsList = document.querySelector('.products');
            var list = found.products;
            list.forEach(item => {
                productsList.innerHTML += `<div class="col-12 col-sm-6 col-md-4 mt-4"> <div class="card"> <div class="card-body"> <img class="img-fluid" src="/src/assets/products/${item.image}" alt=""> <h6>${item.name}</h6> <p>${item.price}₺</p><div class="form-group d-flex justify-content-around"> <button class="btn btn-outline-secondary"> Ürünü İncele</button> <button class="btn btn-outline-success addCart" data-id='${item.id}'> Sepete Ekle</button> </div></div></div></div>`;
            });
            document.querySelectorAll('.addCart').forEach(button => {
                button.addEventListener('click', (e) => {
                    var id = e.target.dataset.id;
                    if (id) {
                        add(id);
                        window.location.reload();
                    }
                });
            });
        }
    });
}

