import React, { useState } from "react";

function RegisterForm() {
  const [Fullname, setFullname] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleRegister = async (e) => {
    e.preventDefault();
      const response = await fetch("https://localhost:57256/api/auth/register", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ Fullname, email, password }),
    });
    if (response.ok) {
      alert("Rejestracja udana");
    } else {
      alert("Błąd rejestracji");
    }
  };

  return (
    <form onSubmit={handleRegister}>
      <input
        type="text"
        placeholder="Nazwa użytkownika"
        value={Fullname}
        onChange={(e) => setFullname(e.target.value)}
        required
      />
      <input
        type="email"
        placeholder="Email"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
        required
      />
      <input
        type="password"
        placeholder="Hasło"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
        required
      />
      <button type="submit">Zarejestruj</button>
    </form>
  );
}

export default RegisterForm;
