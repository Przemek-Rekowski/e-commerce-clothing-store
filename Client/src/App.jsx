import './App.css';
import Navbar from './assets/components/Navbar/Navbar.jsx';
import Footer from './assets/components/Footer/Footer.jsx';
import { BrowserRouter as Router, Route, Link } from 'react-router-dom';

function App() {
  return (
    <Router>
      <div>
        <Navbar />
        <Footer />
      </div>
    </Router>
  );
}

export default App;
