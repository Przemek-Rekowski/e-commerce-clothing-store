import './App.css';
import Navbar from './assets/components/Navbar/Navbar.jsx';
import Footer from './assets/components/Footer/Footer.jsx';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Home from './assets/pages/Home.jsx';
import About from './assets/pages/About/About.jsx';
import Contact from './assets/pages/Contact/Contact.jsx';
import Shop from './assets/pages/Shop/Shop.jsx';
import ShopByCategory from './assets/pages/ShopByCategory/ShopByCategory.jsx';
import Categories from './assets/pages/Categories/Categories.jsx';
import Product from './assets/pages/Product/Product.jsx';
import LogIn from './assets/pages/LogIn/LogIn.jsx'

function App() {
  return (
    <div>
      <Router>
        <Navbar />
        <div className="content-container">
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/about" element={<About />} />
            <Route path="/contact" element={<Contact />} />
            <Route path="/shop" element={<Shop />} />
            <Route path="/shop/category/:categoryName" element={<ShopByCategory />} />
            <Route path="/shop/category" element={<Categories />} />
            <Route path="/product/:id" element={<Product />} />

            <Route path="/login" element={<LogIn/>} />
          </Routes>
        </div>
      </Router>
    </div>
  );
}

export default App;
