import React from 'react';
import { Link } from 'react-router-dom';
import './CategoryCard.css';

const CategoryCard = ({ category }) => {
  if (!category) {
    return <div>Loading...</div>;
  }

  const { name } = category; 

  return (
    <div className="category-card">
      <Link to={`/shop/category/${name.toLowerCase()}`} className="category-link">
        <h2 className="category-title">{name}</h2>
      </Link>
    </div>
  );
};

export default CategoryCard;
