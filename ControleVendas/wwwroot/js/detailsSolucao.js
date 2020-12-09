let detes = document.querySelector('.row').children[1];
let listaDetes = document.querySelector('.row').children[5];

document.querySelector('.row').children[5].innerText = localStorage.key(1)
//console.log(detes.innerText)
//console.log(listaDetes.innerText)

listaDetes.innerText = localStorage.getItem(document.querySelector('.row').children[1].innerText)