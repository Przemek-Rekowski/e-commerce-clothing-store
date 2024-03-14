import React from 'react';
import { Link } from 'react-router-dom';
import './About.css';
import image from '../../../assets/images/vampire-teeth.png';
import { useMediaQuery } from 'react-responsive';

function DesktopAbout() {
  return (
    <div className="about-container">
      <div className="about-text">
        <div className="about-header">
          <h2>About</h2>
        </div>
        <div className="about-content">
          <p>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam nec est nec enim hendrerit rutrum. Duis eget ex non justo tempus convallis ut vel libero. Integer ut mi sed dolor placerat finibus.
          </p>
          <p>
            Sed pulvinar fermentum nisi, eget tristique velit tempor at. Sed eleifend turpis ac quam facilisis, vel rutrum nunc ullamcorper. Proin tempor, libero sed suscipit consectetur, risus purus elementum mauris, non fermentum elit magna ac ligula.
          </p>
          <p>
            Integer id fermentum neque. Nam ac augue odio. Mauris sit amet quam et nulla bibendum volutpat. Donec nec justo felis. Cras a malesuada nulla, non efficitur ex.
          </p>
        </div>
      </div>
      <div className="about-image">
        <Link to="/"> 
          <img src={image} alt="About" />
        </Link>
      </div>
    </div>
  );
}

function MobileAbout() {
  return (
    <div>
      <div className="about-text">
        <div className="about-header">
          <h2>About</h2>
        </div>
        <div className="about-content">
          <p>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam nec est nec enim hendrerit rutrum. Duis eget ex non justo tempus convallis ut vel libero. Integer ut mi sed dolor placerat finibus.
          </p>
          <p>
            Sed pulvinar fermentum nisi, eget tristique velit tempor at. Sed eleifend turpis ac quam facilisis, vel rutrum nunc ullamcorper. Proin tempor, libero sed suscipit consectetur, risus purus elementum mauris, non fermentum elit magna ac ligula.
          </p>
          <p>
            Integer id fermentum neque. Nam ac augue odio. Mauris sit amet quam et nulla bibendum volutpat. Donec nec justo felis. Cras a malesuada nulla, non efficitur ex.
          </p>
        </div>
      </div>
      <div className="about-image">
        <Link to="/"> 
          <img src={image} alt="About" />
        </Link>
      </div>
    </div>
  );
}

export default function About() {
    const notMobile = useMediaQuery({
        query: '(min-width: 1064px)'
      })
     
    return(
        <header>
                {notMobile ? <DesktopAbout /> : <MobileAbout/>}
        </header>
    )
}
