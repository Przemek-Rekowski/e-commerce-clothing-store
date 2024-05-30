import React from 'react';
import './LogIn.css';

function LogIn() {
    return (
        <div className="login-wrapper">
            <div className="login-container">
                <h2>Log In</h2>
                <form action="#" method="POST">
                    <input type="email" name="email" placeholder="Email" required />
                    <input type="password" name="password" placeholder="Password" required />
                    <input type="submit" value="Log In" />
                </form>
            </div>
        </div>
    );
}

export default LogIn;
