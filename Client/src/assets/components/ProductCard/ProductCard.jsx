// ProductCard.jsx
import React from 'react';
import './ProductCard.css';

const ProductCard = ({ product }) => {
  if (!product) {
    return <div>Loading...</div>;
  }

  const { name, description, sizeDtos, price } = product;

  return (
<div class="card">
  <div class="card-img">
    <img src="..." alt="Product image" />
  </div>
  <div class="card-info">
    <p class="text-title">{name}</p>
    <p class="text-body">{description}</p>
    <div class="size-list">
      <h6>Sizes:</h6>
      <ul>
        {sizeDtos && Array.isArray(sizeDtos) && sizeDtos.map((size) => (
          <li key={size.value}>
            <img src={size.image} alt={size.value} /> {/* Assuming size has an image property */}
          </li>
        ))}
      </ul>
    </div>
  </div>
  <div class="card-footer">
    <span class="text-title">{price}</span>
    <div class="card-button">
      <svg class="svg-icon" viewBox="0 0 20 20">
        {/* Your SVG paths here */}
      </svg>
    </div>
  </div>
</div>

  );
};

export default ProductCard;
