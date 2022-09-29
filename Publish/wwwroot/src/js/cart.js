export const add = (id) => {
    var carts = get();
    carts.push(id);
    set(carts);
}

export const remove = (id) => {
    var carts = get();
    carts = carts.filter(x => x != id);
    set(carts);
}

export const get = () => {
    return JSON.parse(localStorage.getItem('carts') ?? JSON.stringify([]));
}

export const set = (data) => {
    localStorage.setItem('carts', JSON.stringify(data));
}

export const clear = () => {
    set([]);
}
