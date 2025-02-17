const apiBaseUrl = "http://localhost:57257/api/cars";

// Pobierz listę aut
function getCars() {
    fetch(apiBaseUrl)
        .then(response => response.json())
        .then(data => {
            console.log('Dane z API:', data);  // Sprawdź, co zwraca API
            let container = document.getElementById("cars-container");
            container.innerHTML = "<h2>🚗 Lista dostępnych aut</h2>";
            if (data.length === 0) {
                container.innerHTML += "<p>Brak dostępnych samochodów.</p>";
            }
            data.forEach(car => {
                container.innerHTML += `
                    <p onclick="showCarDetails('${car.make}', '${car.model}', ${car.dailyRate})">
                        <strong>${car.make} ${car.model}</strong> - ${car.dailyRate} PLN/dzień
                    </p>
                `;
            });
        })
        .catch(error => {
            console.error("Błąd pobierania aut:", error);
            let container = document.getElementById("cars-container");
            container.innerHTML = "<p>Błąd pobierania danych z serwera.</p>";
        });
}

// Pokaż szczegóły auta
function showCarDetails(make, model, dailyRate) {
    alert(`🚗 Szczegóły auta:\nMarka: ${make}\nModel: ${model}\nCena: ${dailyRate} PLN/dzień`);
}

// Dodaj nowe auto (tylko dla Wynajmujących/Adminów)
function addCar() {
    const role = getUserRole();
    if (role !== "owner" && role !== "admin") {
        alert("Nie masz uprawnień do dodawania aut!");
        return;
    }

    const make = document.getElementById("make").value;
    const model = document.getElementById("model").value;
    const dailyRate = document.getElementById("dailyRate").value;

    const car = {
        make: make,
        model: model,
        dailyRate: parseFloat(dailyRate),
        isPrivate: false,
        rating: 0
    };

    fetch(apiBaseUrl, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(car)
    })
    .then(response => response.text())
    .then(message => {
        alert(message);
        getCars();  // Odśwież listę samochodów po dodaniu
    })
    .catch(error => console.error("Błąd dodawania auta:", error));
}
