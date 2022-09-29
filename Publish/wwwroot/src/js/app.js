window.addEventListener('load', async () => {
    const categories = await fetch("/api/categories").then(x => x.json());
    const parentCategoriesContainer = document.querySelector('.parent-categories');
    const subCategoriesContainer = document.querySelector('.sub-categories');


    let selectedParentCategoryId = categories[0].id;

    categories.forEach(category => {
        parentCategoriesContainer.innerHTML += `<li class="parent-category list-group-item d-flex justify-content-between align-items-center" data-id='${category.id}'> <div class="me-auto"> ${category.name} </div></li>`;
    });
    drawSubCategories();

    function drawSubCategories() {
        const category = categories.find(x => x.id == selectedParentCategoryId);
        const data = category.categories;
        if (!data) return;
        let content = '';
        data.forEach(category => {
            var subData = category.categories;
            if (!subData) return;
            content += `<h6 class="my-1">${category.name}</h6> <hr class="my-0"> <div class="row">`;
            subData.forEach(subCategory => {
                let count = subCategory.products.length;
                content += `<div class="col-6 col-sm-4"><a class='link-secondary text-decoration-none' href='/Default/products?id=${subCategory.id}'><small>${subCategory.name} (${count})</small></a></div>`;
            });
            content += `</div>`;
        });
        subCategoriesContainer.innerHTML = content;

    }

    document.querySelectorAll('.parent-category').forEach(pc => {
        pc.addEventListener('mouseover', (e) => {
            const id = e.target.dataset.id;
            if (id && id != selectedParentCategoryId) {
                selectedParentCategoryId = id;
                drawSubCategories();
            }
        });
    });

});



// Hamburger menu
document.addEventListener('click', function (e) {
    if (e.target.classList.contains('hamburger-toggle')) {
        e.target.children[0].classList.toggle('active');
    }
})


import { get } from './cart.js';
var cartCounter = document.querySelector('.cartCounter');
cartCounter.innerHTML = get()?.length ?? 0;