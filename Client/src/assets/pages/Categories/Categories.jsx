import React, { useState, useEffect } from 'react';
import CategoryCard from '../../../assets/components/CategoryCard/CategoryCard.jsx';
import './Categories.css';
import axios from 'axios';

const Categories = () => {
  const [categoryData, setCategoryData] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get("https://localhost:7172/api/category");
        setCategoryData(response.data);
      } catch (error) {
        console.error("Error fetching categories:", error);
      }
    };

    fetchData();
  }, []);

  return (
    <div className="categories-container">
      {categoryData.map((category, index) => (
        <CategoryCard key={index} category={category} />
      ))}
    </div>
  );
};

export default Categories;