import React from 'react';
import { Link } from 'react-router-dom';
import './ProductCard.css';

const ProductCard = ({ product }) => {
  if (!product) {
    return <div>Loading...</div>;
  }

  const { name, description, price, images } = product;

  return (
    <div className="product">
      <div className="product-images">
        {images && images.length > 0 ? (
          images.map((image, index) => (
            <figure className="product-image" key={index}>
              <img src={image.imageUrl} alt={`Product Image ${index + 1}`} />
            </figure>
          ))
        ) : (
          <figure className="product-image">
            <img src="placeholder_image_url" alt="No Image Available" />
          </figure>
        )}
      </div>

      <div className="product-description">
        <div className="info">
          <h1>{name}</h1>
          <p>{description}</p>
        </div>
        <div className="price">{price}</div>
        <Link to={`product/${product.id}`} className="button">View Details</Link>
      </div>
    </div>
  );
};

export default ProductCard;
