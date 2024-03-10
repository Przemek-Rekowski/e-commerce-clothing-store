import React from 'react';
import { Link } from 'react-router-dom';
import './footer.css';
import tiktok from './tiktok-icon.svg';
import facebook from './facebook-icon.svg';
import instagram from './instagram-icon.svg';

const year = new Date().getFullYear();

const Footer = () => {
  const customerServiceLinks = [
    { name: 'About Us', route: '/about' },
    { name: 'FAQ', route: '/faq' },
    { name: 'Returns', route: '/returns' },
    { name: 'Sizes', route: '/sizes' },
    { name: 'Privacy', route: '/privacy' },
  ];

  return (
    <footer className="site-footer">
      <div className="footer-section">
        <h4> ©{year} Yveantte</h4>
      </div>

      <div className="footer-section">
        <h4>Meet Us</h4>
        <p>Connect with us on different platforms and stay updated!</p>
        <div className="social-icons">
          <a href="#" target="_blank" rel="noopener noreferrer">
            <img src={tiktok} alt="TikTok" />
          </a>
          <a href="#" target="_blank" rel="noopener noreferrer">
            <img src={facebook} alt="Facebook" />
          </a>
          <a href="#" target="_blank" rel="noopener noreferrer">
            <img src={instagram} alt="Instagram" />
          </a>
        </div>
      </div>

      <div className="footer-section">
        <h4>Customer Service</h4>
        <ul>
          {customerServiceLinks.map((link) => (
            <li key={link.name}>
              <Link to={link.route}>{link.name}</Link>
            </li>
          ))}
        </ul>
      </div>
    </footer>
  );
};

export default Footer;
