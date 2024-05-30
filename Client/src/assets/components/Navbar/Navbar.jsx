import React from 'react';
import { Link } from 'react-router-dom'; // Import Link from react-router-dom
import { useMediaQuery } from 'react-responsive';
import { HiSearch, HiMenu, HiX, HiChevronDown } from 'react-icons/hi';
import { useState } from 'react';

import './Navbar.css';
import logo from './logo.svg';
import links from './nav-links';

const reactIconStyle = { width: '20px', height: '20px', color: '#9e9ea7', cursor: 'pointer' };

function DesktopNavbar() {
    return (
        <div className='nav-container'>
            <nav className='nav-desktop'>
                <div className='logo-container'>
                    <Link to="/">
                        <img src={logo} alt="Logo" className='logo' />
                    </Link>
                </div>
                <ul className='desktop-menu'>
                    {links.map((link) => {
                        return <li key={link.name}><a href={link.route}>{link.name}</a></li>
                    })}
                </ul>
            </nav>
            <ul className='desktop-menu-btns'>
                <li><HiSearch style={reactIconStyle} /></li>
                <li><Link to="/signin">Sign in</Link></li>
                <li><Link to="/login">Log In</Link></li>
            </ul>
        </div>
    );
}

function MobileNavbar({ isOpen, setIsOpen }) {
    return (
        <>
            <nav className='nav-mobile'>
                {isOpen ? <HiX onClick={() => setIsOpen(!isOpen)} style={reactIconStyle} /> : <HiMenu onClick={() => setIsOpen(!isOpen)} style={reactIconStyle} />}
                <div className='logo-container'>
                    {/* Wrap logo with Link component */}
                    <Link to="/">
                        <img src={logo} alt="Logo" className='logo' />
                    </Link>
                </div>
                <ul className='desktop-menu-btns'>
                    <li><HiSearch style={reactIconStyle} /></li>
                    <li><Link to="/signin">Sign in</Link></li>
                    <li><Link to="/login"><p>Log In</p></Link></li>
                </ul>
            </nav>
            {isOpen ? (
                <div className='mobile-menu'>
                    <form>
                        <HiSearch style={reactIconStyle} />
                        <input placeholder='Search' />
                    </form>

                    <ul>
                        {links.map(link => {
                            return <li key={link.name}>
                                <a href={link.route}>{link.name}</a>
                                <HiChevronDown style={reactIconStyle} />
                            </li>
                        })}
                    </ul>
                </div>
            ) : (
                null
            )}
        </>
    )
}

export default function Navbar() {
    const notMobile = useMediaQuery({
        query: '(min-width: 1064px)'
    })

    const [isOpen, setIsOpen] = useState(false)
    return (
        <header>
            {notMobile ? <DesktopNavbar /> : <MobileNavbar isOpen={isOpen} setIsOpen={setIsOpen} />}
        </header>
    )
}
