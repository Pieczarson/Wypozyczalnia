import React, { useState } from "react";

function AddCarForm({ token }) {
  const [brand, setBrand] = useState("");
  const [model, setModel] = useState("");
  // Dodaj inne właściwości samochodu, jeśli są potrzebne

  const handleAddCar = async (e) => {
    e.preventDefault();
      const response = await fetch("https://localhost:57256/api/car", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`
      },
      body: JSON.stringify({ brand, model })
    });
    if (response.ok) {
      alert("Samochód dodany");
    } else {
      alert("Błąd dodawania samochodu");
    }
  };

  return (
    <form onSubmit={handleAddCar}>
      <input
        type="text"
        placeholder="Marka"
        value={brand}
        onChange={(e) => setBrand(e.target.value)}
        required
      />
      <input
        type="text"
        placeholder="Model"
        value={model}
        onChange={(e) => setModel(e.target.value)}
        required
      />
      <button type="submit">Dodaj samochód</button>
    </form>
  );
}

export default AddCarForm;
