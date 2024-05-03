import React, { useEffect, useState } from 'react';
import ReactDOM from 'react-dom';
import ReactPaginate from 'react-paginate';
import axios from 'axios'; // Import axios for making API requests

function Items({ currentItems }) {
  return (
    <>
      {currentItems &&
        currentItems.map((item) => (
          <div key={item.id}>
            <h3>Item #{item.id}</h3> {/* Assuming item has an id */}
            {/* Render other item details here */}
          </div>
        ))}
    </>
  );
}

export default function PaginatedItems({ itemsPerPage }) {
  const [currentPage, setCurrentPage] = useState(1);
  const [totalPages, setTotalPages] = useState(0);
  const [productsData, setProductsData] = useState([]);

  useEffect(() => {
    fetchData();
  }, [currentPage]); // Fetch data when currentPage changes

  const fetchData = async () => {
    try {
      const response = await axios.get(`https://localhost:7172/api?PageNumber=${currentPage}&PageSize=${itemsPerPage}`);
      setProductsData(response.data.items);
      setTotalPages(response.data.totalPages);
    } catch (error) {
      console.error("Error fetching products:", error);
    }
  };

  const handlePageClick = (data) => {
    const selectedPage = data.selected + 1; // Pagination starts from 0
    setCurrentPage(selectedPage);
  };

  return (
    <>
      <Items currentItems={productsData} />
      <ReactPaginate
        breakLabel="..."
        nextLabel="next >"
        onPageChange={handlePageClick}
        pageRangeDisplayed={5}
        pageCount={totalPages}
        previousLabel="< previous"
        renderOnZeroPageCount={null}
      />
    </>
  );
}
