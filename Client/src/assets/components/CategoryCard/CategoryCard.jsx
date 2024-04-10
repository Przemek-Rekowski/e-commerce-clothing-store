import React from 'react';
import './CategoryCard.css';

const CategoryCard = ({ category }) => {
  if (!category) {
    return <div>Loading...</div>;
  }

  const { name } = category; 

  return (
    <div className="category-card">
      <h2 className="category-title">{name}</h2>
    </div>
  );
};

export default CategoryCard;