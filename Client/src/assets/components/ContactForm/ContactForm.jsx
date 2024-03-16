// ContactForm.jsx

import React from 'react';
import './ContactForm.css'

const ContactForm = () => {
  return (
    <form className="contact-form">
      <input type="text" placeholder="Name" />
      <input type="email" placeholder="Email" />
      <textarea placeholder="Message" rows="6"></textarea>
      <button type="submit">Submit</button>
    </form>
  );
};

export default ContactForm;
