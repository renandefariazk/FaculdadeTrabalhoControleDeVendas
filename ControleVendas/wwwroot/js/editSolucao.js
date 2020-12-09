const inputCodigos = document.querySelector('#Codigo');
const oldCodigo = inputCodigos.value;
console.log(oldCodigo);
const buttonSubmit = document.querySelector('.btn');
const produto = localStorage.getItem(oldCodigo)

buttonSubmit.addEventListener('click', () => {
    localStorage.setItem(inputCodigos.value,produto)
});
