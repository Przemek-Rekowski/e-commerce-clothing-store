import React from 'react';
import PaginatedItems from '../../../assets/components/Pagination/Pagination.jsx';
import './Shop.css';

function Shop() {
  return (
    <div className="shop-container">
      <h1>Shop</h1>
      <div className="product-grid">
        <PaginatedItems itemsPerPage={4} />
      </div>
    </div>
  );
}

export default Shop;
