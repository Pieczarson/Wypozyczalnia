function login() {
    const role = document.getElementById("userRole").value;
    localStorage.setItem("userRole", role);
    alert(`Zalogowano jako: ${role}`);

    // Pokaż ukryte sekcje
    document.getElementById("login").style.display = "none";
    document.getElementById("cars").style.display = "block";

    // Jeśli użytkownik to Wynajmujący lub Admin → może dodawać auta
    if (role === "owner" || role === "admin") {
        document.getElementById("addCarBtn").style.display = "inline-block";
    }

    getCars();
}

function logout() {
    localStorage.removeItem("userRole");
    location.reload();
}

function getUserRole() {
    return localStorage.getItem("userRole") || "guest";
}
