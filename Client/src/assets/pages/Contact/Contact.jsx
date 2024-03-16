// Contact.jsx

import React from 'react';
import ContactForm from '../../../assets/components/ContactForm/ContactForm.jsx';
import './Contact.css';

const Contact = () => {
  return (
    <div className="contact-container">
      <h1 className="contact-header">Contact Us</h1>
      <div className="contact-form-container">
        <ContactForm />
      </div>
    </div>
  );
};

export default Contact;
