import React, { useState } from "react";

function LoginForm({ setToken }) {
  const [Fullname, setFullname] = useState("");
  const [password, setPassword] = useState("");

  const handleLogin = async (e) => {
    e.preventDefault();
      const response = await fetch("https://localhost:57256/api/auth/login", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ Fullname, password }),
    });
    if (response.ok) {
      const data = await response.json();
      setToken(data.token);
    } else {
      alert("Błędne dane logowania");
    }
  };

  return (
    <form onSubmit={handleLogin}>
      <input
        type="text"
        placeholder="Nazwa użytkownika"
        value={Fullname}
        onChange={(e) => setFullname(e.target.value)}
        required
      />
      <input
        type="password"
        placeholder="Hasło"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
        required
      />
      <button type="submit">Zaloguj</button>
    </form>
  );
}

export default LoginForm;
