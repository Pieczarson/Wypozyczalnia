import React, { useState } from "react";
import LoginForm from "./components/LoginForm";
import RegisterForm from "./components/RegisterForm";
import AddCarForm from "./components/AddCarForm";
import AddReviewForm from "./components/AddReviewForm";

function App() {
  const [token, setToken] = useState("");

  return (
    <div className="App">
      <h1>Wypożyczalnia – Aplikacja</h1>
      {!token ? (
        <div>
          <h2>Logowanie</h2>
          <LoginForm setToken={setToken} />
          <h2>Rejestracja</h2>
          <RegisterForm />
        </div>
      ) : (
        <div>
          <h2>Dodaj samochód</h2>
          <AddCarForm token={token} />
          <h2>Dodaj recenzję</h2>
          <AddReviewForm token={token} />
        </div>
      )}
    </div>
  );
}

export default App;
