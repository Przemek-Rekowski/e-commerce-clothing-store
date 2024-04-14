import React, { useState, useEffect } from 'react';
import ProductCard from '../../assets/components/ProductCard/ProductCard.jsx';
import axios from 'axios';

const Products = () => {
  const [productsData, setProductsData] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get("https://localhost:7172/api");
        setProductsData(response.data);
      } catch (error) {
        console.error("Error fetching products:", error);
      }
    };

    fetchData();
  }, []);

  return (
    <div>
      {productsData.map((product, index) => (
        <ProductCard key={index} product={product} />
      ))}
    </div>
  );
}

export default Products;
