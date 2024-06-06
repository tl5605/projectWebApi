
const register = async () => {
    const newUser = {
        email: document.getElementById("email").value,
        password: document.getElementById("password").value,
        firstName: document.getElementById("firstName").value,
        lastName: document.getElementById("lastName").value
    };
    
    const response = await fetch('api/users', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newUser)
    });
    const Register = await response.json();
    console.log('POST Data', Register)
    if (response.status == 400) {
        alert("סיסמה חלשה")
    }
    else {
        if (response.ok) {

            window.location.href = "login.html"
        }
    }

}

const checkStrongPassword = async () => {
    const password = document.getElementById('password').value;
    const progress = document.getElementById("password-strength-progress")

    const response = await fetch('api/users/checkPassword', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(password)
    });

    const strong = await response.json();

    if (response.ok) {
        progress.value = strong;
    }
 }

const login = async () => {
    const loginUser = {
        email: document.getElementById("email").value,
        password: document.getElementById("password").value
    };
    const response = await fetch('api/users/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(loginUser)
    });
    const Login = await response.json();
    console.log('POST Data', Login)
    if (response.ok) {
        console.log(Login.userId)
        sessionStorage.setItem("userId", JSON.stringify(Login.userId))
        window.location.href = "Products.html"
    }
    else {
        
        alert("שם משתמש או הסיסמה אינם נכונים");
    }
}

const updateDetaild = async () => {
    const id = sessionStorage.getItem("userId");

    const updateUser = {
        email: document.getElementById("email").value,
        password: document.getElementById("password").value,
        firstName: document.getElementById("firstName").value,
        lastName: document.getElementById("lastName").value
    };
    const response = await fetch(`api/users/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(updateUser)
    });
    if (response.status == 400) {
        alert("סיסמה חלשה")
    }
    else {
        if (response.ok) {
            alert("פריטם עודכנו בהצלחה!!!")
            window.location.href = "Products.html"
        }
    }
}

