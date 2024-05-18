import React from 'react';
import { useParams } from 'react-router-dom';
import PaginatedItems from '../../../assets/components/Pagination/Pagination.jsx';
import './ShopByCategory.css';

function ShopByCategory() {
  const { categoryName } = useParams();

  return (
    <div className="shop-container">
      <h1>Shop By Category: {categoryName}</h1>
      <div className="product-grid">
        <PaginatedItems itemsPerPage={4} category={categoryName} />
      </div>
    </div>
  );
}

export default ShopByCategory;
