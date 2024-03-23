import React from 'react';
import CategoryCard from '../../../assets/components/CategoryCard/CategoryCard.jsx';
import './Categories.css';

const Categories = () => {
  // Define an array of categories
  const categories = ['Hoodies', 'Pants', 'Accessories', 'Shoes', 'Tops'];

  return (
    <div>
      <h1 className="category-header">Categories</h1>
      <div className="category-container">
        {/* Map through categories array and render CategoryCard for each category */}
        {categories.map((category, index) => (
          <CategoryCard key={index} category={category} />
        ))}
      </div>
    </div>
  );
};

export default Categories;
