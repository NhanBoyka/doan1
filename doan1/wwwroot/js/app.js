    // form signup
    function signup(e){
        event.preventDefault();
        var username = document.getElementById(ElementId ="username").value;
        var email = document.getElementById(ElementId ="email").value;
        var password = document.getElementById(ElementId ="password").value;
        var user = {
            username: username,
            email: email,
            password: password,
        };
        if(username == null ||  username ==""){
            alert("tên đăng nhập không được để trống !");
            return false;
        }
        else if(email == null || email==""){
            alert("không được trống email !");
            return false;
        }
        else{
            alert("đăng ký thành công!");
        }
    }
    // form login
    function login(e){
        event.preventDefault();
        var username = document.getElementById(ElementId= "username").value;
        var email = document.getElementById(ElementId= "email").value;
        var password = document.getElementById(ElementId= "password").value;
        var user = localStorage.getItem(key= username);
        var data = JSON.parse(text= user);
        if(username == null){
            alert(message= "Vui lòng nhập username password");
        }
        else if(username == data.username && email == data.email && password == data.password){
            alert(message= "Đăng nhập thất bại ");
        }
        else{
            alert(message= "Đăng nhập thành công ");
        }
    }




    // js-form
    // const btnSignup = document.querySelector('.js-signup')
    // const btnLogin = document.querySelector('.js-login')
    // const modal = document.querySelector('.js-modal')
    // const modalClose = document.querySelector('.js-modal-close')
    // const modalContainer = document.querySelector('.js-modal-container')
    // function showModal() {
    //     modal.classList.add('open')
    // }
    //   btnSignup.addEventListener('click', showModal)
    //   btnLogin.addEventListener('click', showModal)
  
    // function hideModal() {
    //     modal.classList.remove('open')
    // }
    // modalClose.addEventListener('click', hideModal)

    // modal.addEventListener('click', hideModal)

    // modalContainer.addEventListener('click', function (event) {
    //     event.stopPropagation()
    // })

    
  
// show gio hang
let openShopping = document.querySelector('.shopping');
let closeShopping = document.querySelector('.closeShopping');
let list = document.querySelector('.list');
let listCard = document.querySelector('.listCard');
let body = document.querySelector('body');
let total = document.querySelector('.total');
let quantity = document.querySelector('.quantity');


openShopping.addEventListener('click', ()=>{
    body.classList.add('active');
})
closeShopping.addEventListener('click', ()=>{
    body.classList.remove('active');
})

function showmodalCart() {
    body.classList.add('active');
}

const buyBtns = document.querySelectorAll('.cart-button')
function showCart() {
    body.classList.add('active');
}
for (const buyBtn of buyBtns) {
    buyBtn.addEventListener('click', showCart)
}



// Gio hang
let products = [
    {
        id: 1,
        name: 'Nhẫn Bạc Emerald',
        category: 'Xuất Xứ: China',
        image: '1.jpg',
        price: 7800000 
    },
    {
        id: 2,
        name: 'Nhẫn Thanh Dương',
        category: 'Xuất xứ: USA',
        image: '9.jpg',
        price: 1220000
    },
    {
        id: 3,
        name: 'Dây Chuyền Bạc S925',
        category: 'Xuất Xứ: China',
        image: '10.jpg',
        price: 2200000
    },
    {
        id: 4,
        name: 'Nhẫn Bạc S955',
        category: 'Xuất Xứ: Việt Nam',
        image: '4.jpg',
        price: 3900000
    },
    {
        id: 5,
        name: 'Nhẫn Bạc Hatred',
        category: 'Xuất Xứ: Việt Nam',
        image: '5.jpg',
        price: 3200000
    },
    {
        id: 6,
        name: 'Khuyên Tai WayKen',
        category: 'Xuất Xứ: Thái Lan',
        image: '6.jpg',
        price: 1209000
    },
    {
        id: 7,
        name: 'Mặt Lục Bảo',
        category: 'Xuất xứ: RUSSIA',
        image: '7.jpg',
        price: 32000000
    },
    {
        id: 8,
        name: 'khuyên Tai Whell',
        image: '8.jpg',
        category: 'Xuất Xứ: Hồng Kong',
        price: 1200000
    }
];

let listCards  = [];
function initApp(){
    products.forEach((value, key) =>{
        let newDiv = document.createElement('div');
        newDiv.classList.add('item');
        newDiv.innerHTML = `
        <img src="assets/images/${value.image}">
        <div class="title">${value.name}</div>
        <ul>
           
        </ul>     
        <div class="categogy">${value.category}</div>
        <div class="price">${value.price.toLocaleString()}<sup>đ</sup></div>
       
        <button class=" cart-button" onclick="addToCard(${key})">Thêm vào giỏ hàng</button>`;        
        list.appendChild(newDiv);
    })
}
initApp();
function addToCard(key){
    if(listCards[key] == null){
        // copy product form list to list card
        listCards[key] = JSON.parse(JSON.stringify(products[key]));
        listCards[key].quantity = 1;
    }
    reloadCard();
}
function reloadCard(){
    listCard.innerHTML = '';
    let count = 0;
    let totalPrice = 0;
    listCards.forEach((value, key)=>{
        totalPrice = totalPrice + value.price;
        count = count + value.quantity;
        if(value != null){
            let newDiv = document.createElement('li');
            newDiv.innerHTML = `
                <div><img src="assets/images/${value.image}"/></div>
                <div>${value.name}</div>
                <div>${value.price.toLocaleString()}</div>
                <div>
                    <button class="ti-trash" onclick="changeQuantity(${key}, ${value.quantity - 1})"></button>
                    <div class="count">${value.quantity}</div>
                </div>`;
                listCard.appendChild(newDiv);
        }
    })
    total.innerText = totalPrice.toLocaleString();
    quantity.innerText = count;
}
function changeQuantity(key, quantity){
    if(quantity == 0){
        delete listCards[key];
    }else{
        listCards[key].quantity = quantity;
        listCards[key].price = quantity * products[key].price;
    }
    reloadCard();
}







