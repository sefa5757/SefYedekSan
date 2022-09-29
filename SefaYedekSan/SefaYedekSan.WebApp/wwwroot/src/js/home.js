
const typeList = document.querySelector('.type-list');
const brandList = document.querySelector('.brand-list');
const modelList = document.querySelector('.model-list');
const brandSliderContainer = document.querySelector('.brand-slider-container');

let selectedTypeId = 1, selectedBrandId = 1;

window.addEventListener('load', async () => {
    const types = await fetch("/api/carfilter").then(x => x.json());

    types.forEach(type => {
        typeList.innerHTML += `<option value="${type.id}">${type.name}</option>`;
    });
    typeList.addEventListener('change', (e) => {
        selectedTypeId = e.target.value;
        drawBrands();
    });
    brandList.addEventListener('change', (e) => {
        selectedBrandId = e.target.value;
        drawModels();
    });

    function drawBrands() {
        const data = types.find(x => x.id == selectedTypeId).brands;
        if (data.length == 0) { brandList.innerHTML = ""; return };
        brandList.innerHTML = " <option selected> Marka Seçiniz</option>";
        data.forEach(brand => {
            brandList.innerHTML += `<option value="${brand.id}">${brand.name}</option>`;
        })
    }

    function drawModels() {
        const data = types
            .find(x => x.id == selectedTypeId)
            .brands
            .find(x => x.id == selectedBrandId)
            .models;
        if (data.length == 0) { modelList.innerHTML = ""; return };
        modelList.innerHTML = " <option selected> Model Seçiniz</option>";
        data.forEach(model => {
            modelList.innerHTML += `<option value="${model.id}">${model.name}</option>`;
        })
    }

    const histories = await fetch("/api/histories").then(x => x.json());
    histories.forEach(history => {
        brandSliderContainer.innerHTML += `<div class="swiper-slide"> <div class="brand-card"> <div class="brand-card-header "> <img src="/src/assets/brands/${history.image}" alt=""> </div><div class="card px-4"> <h5 class="pt-4 text-center">${history.brand.name}</h5> <hr> <p class='history'>${history.content}</p></div></div></div>`;
    });
});