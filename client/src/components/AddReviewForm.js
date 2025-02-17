import React, { useState } from "react";

function AddReviewForm({ token }) {
  const [carId, setCarId] = useState("");
  const [rating, setRating] = useState("");
  const [comment, setComment] = useState("");

  const handleAddReview = async (e) => {
    e.preventDefault();
      const response = await fetch("https://localhost:57256/api/review", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`
      },
      body: JSON.stringify({ carId, rating, comment })
    });
    if (response.ok) {
      alert("Recenzja dodana");
    } else {
      alert("Błąd dodawania recenzji");
    }
  };

  return (
    <form onSubmit={handleAddReview}>
      <input
        type="text"
        placeholder="ID samochodu"
        value={carId}
        onChange={(e) => setCarId(e.target.value)}
        required
      />
      <input
        type="number"
        placeholder="Ocena (1-5)"
        value={rating}
        onChange={(e) => setRating(e.target.value)}
        required
      />
      <textarea
        placeholder="Komentarz"
        value={comment}
        onChange={(e) => setComment(e.target.value)}
        required
      ></textarea>
      <button type="submit">Dodaj recenzję</button>
    </form>
  );
}

export default AddReviewForm;
