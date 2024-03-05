import React, { useState } from 'react';
import './Navbar.css';

function Navbar() {
  const [isDropdownOpen, setDropdownOpen] = useState(false);

  // Fake categories (replace with actual data from your API)
  const fakeCategories = ['Hoodies', 'Pants', 'Sweatshirts', 'Accessories'];

  const handleDropdownClick = () => {
    setDropdownOpen(!isDropdownOpen);
  };

  return (
    <div className="navbar">
      <div className="logo">
        {/* Your logo content goes here */}
      </div>
      <div className="nav-items">
        <button className="nav-button" onClick={handleDropdownClick}>
          Shop
        </button>
        {isDropdownOpen && (
          <div className="nav-dropdown-content">
            {/* Map through the fake categories and create dropdown links */}
            {fakeCategories.map((category, index) => (
              <a key={index} href={`/shop/${category}`} className="nav-link">
                {category}
              </a>
            ))}
          </div>
        )}
        <a href="/contact" className="nav-link">
          Contact
        </a>
        <div className="nav-icons">
          <a href="/language" className="nav-icon">
            En
          </a>
        </div>
      </div>
    </div>
  );
}

export default Navbar;
