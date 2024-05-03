import React from 'react';
import PaginatedItems from '../../../assets/components/Pagination/Pagination.jsx';
import './Shop.css'; // Import your CSS file if needed

function Shop() {
  return (
    <div className="shop-container">
      <h1>Shop</h1>
      <PaginatedItems itemsPerPage={4} />
    </div>
  );
}

export default Shop;

