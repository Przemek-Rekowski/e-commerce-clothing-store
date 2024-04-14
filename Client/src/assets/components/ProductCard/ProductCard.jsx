import React from 'react';
import './ProductCard.css';

const ProductCard = ({ product }) => {
  if (!product) {
    return <div>Loading...</div>;
  }

  const { name, description, SizeDtos, Price } = product;

  return (
    <div className="product-card" style={{ width: '18rem' }}>
      <img className="card-img-top" src="..." alt="Card image cap" />
      <div className="card-body">
        <h5 className="card-title">{name}</h5>
        <p className="card-text">{description}</p>
        <div className="size-list">
          <h6>Sizes:</h6>
          <ul>
            {SizeDtos && Array.isArray(SizeDtos) && SizeDtos.map((size) => (
              <li key={size.Value}>{size.Value}</li>
            ))}
          </ul>
        </div>
        <div className="price">
          <p>{Price}</p>
        </div>
      </div>
    </div>
  );
};

export default ProductCard;
