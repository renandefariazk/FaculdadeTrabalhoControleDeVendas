const button = document.querySelector('.btn-primary');
const selec = document.querySelector('#PedidoProdutos');

let guardar = []

button.addEventListener('click', function () {
    //console.log(selec.options.selectedIndex);
    let indexSelec = selec.options.selectedIndex
    //console.log(selec.options);
    //console.log(selec.children[1].innerText)
    let resultados = selec.children[indexSelec].innerText;
    //console.log(resultados)

    guardar.push(resultados)

    //console.log(guardar)

    localStorage.setItem(document.querySelector('#Codigo').value, guardar)
    //console.log(localStorage.getItem(document.querySelector('#Codigo').value))
    //console.log(document.querySelector('#Codigo').value)
})