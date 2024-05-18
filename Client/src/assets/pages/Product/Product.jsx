import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import './Product.css';

function Product() {
  const [currentImageIndex, setCurrentImageIndex] = useState(0);
  const [selectedSize, setSelectedSize] = useState(null);
  const [product, setProduct] = useState(null);
  const { id } = useParams();

  useEffect(() => {
    fetch(`https://localhost:7172/api/product/${id}`)
      .then(response => response.json())
      .then(data => setProduct(data))
      .catch(error => console.error('Error fetching product:', error));
  }, [id]);

  const nextImage = () => {
    setCurrentImageIndex(prevIndex => (prevIndex === product.images.length - 1 ? 0 : prevIndex + 1));
  };

  const previousImage = () => {
    setCurrentImageIndex(prevIndex => (prevIndex === 0 ? product.images.length - 1 : prevIndex - 1));
  };

  const handleSizeClick = size => {
    setSelectedSize(size);
  };

  if (!product) {
    return <div>Loading...</div>;
  }

  return (
    <div className="product-container">
      <div className="image-container">
        {product.images && product.images.length > 0 && (
          <>
            <button onClick={previousImage}>Previous</button>
            <img src={product.images[currentImageIndex]?.imageUrl} alt="Product" />
            <button onClick={nextImage}>Next</button>
          </>
        )}
      </div>
      <div className="info-container">
        <h2>{product.name}</h2>
        <p>Price: ${product.price}</p>
        <p className="description">Description: {product.description}</p>
        <div className="sizes-container">
          <p>Sizes:</p>
          <div className="sizes-and-button">
            {product.sizeDtos.map(size => (
              <span
                key={size.value}
                className={`size ${selectedSize === size.value ? 'selected' : ''}`}
                onClick={() => handleSizeClick(size.value)}
              >
                {size.value}
              </span>
            ))}
          </div>
        </div>
      </div>
    </div>
  );
}

export default Product;
