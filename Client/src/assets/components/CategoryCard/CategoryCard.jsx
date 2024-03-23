import React from 'react';
import './CategoryCard.css'; // Import your CSS file for styling

const CategoryCard = ({ category }) => {
  return (
    <div className="category-card">
      <h2 className="category-title">{category}</h2>
    </div>
  );
};

export default CategoryCard;
