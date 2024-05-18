import React, { useEffect, useState } from 'react';
import ReactPaginate from 'react-paginate';
import axios from 'axios';
import ProductCard from "../ProductCard/ProductCard.jsx";
import './Pagination.css';

export default function PaginatedItems({ itemsPerPage, category }) {
  const [currentPage, setCurrentPage] = useState(1);
  const [totalPages, setTotalPages] = useState(0);
  const [productsData, setProductsData] = useState([]);

  useEffect(() => {
    fetchData();
  }, [currentPage, category, itemsPerPage]);

  const fetchData = async () => {
    try {
      let url = `https://localhost:7172/api?PageNumber=${currentPage}&PageSize=${itemsPerPage}`;
      if (category) {
        url = `https://localhost:7172/api/product/category/${category}?PageNumber=${currentPage}&PageSize=${itemsPerPage}`;
      }
      const response = await axios.get(url);
      setProductsData(response.data.items);
      setTotalPages(response.data.totalPages);
    } catch (error) {
      console.error("Error fetching products:", error);
    }
  };

  const handlePageClick = (data) => {
    const selectedPage = data.selected + 1;
    setCurrentPage(selectedPage);
  };

  return (
    <>
      <div className="products-container">
        {productsData.map((product) => (
          <ProductCard key={product.id} product={product} />
        ))}
      </div>
      <ReactPaginate
        breakLabel="..."
        nextLabel="next >"
        onPageChange={handlePageClick}
        pageRangeDisplayed={5}
        pageCount={totalPages}
        previousLabel="< previous"
        renderOnZeroPageCount={null}
        containerClassName="pagination"
        activeClassName="active"
      />
    </>
  );
}
