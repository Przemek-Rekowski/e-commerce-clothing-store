import './App.css';
import Navbar from './assets/components/Navbar/Navbar.jsx';
import Footer from './assets/components/Footer/Footer.jsx';

import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Home from './assets/pages/Home.jsx'
import About from './assets/pages/About/About.jsx'
import Contact from './assets/pages/Contact.jsx'
import Shop from './assets/pages/Shop.jsx'

function App() {
  return (
    <div>
        <Router>
          <Navbar/>
          <div className="content-container">
            <Routes>
              <Route path="/" element={Home()} />
              <Route path="/about" element={About()} />
              <Route path="/contact" element={Contact()} />
              <Route path="/shop" element={Shop()} />
            </Routes>
          </div>
          <Footer/>
       </Router>
    </div>
  );
}

export default App;