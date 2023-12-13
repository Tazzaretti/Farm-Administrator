import React from 'react';
import { Link } from 'react-router-dom';
import '../styles/NavBar.css';

const NavBar = ({ showLoginButton, showSignupButton, showPlotsButton }) => {
  return (
    <nav className="navbar">
      <Link to="/" className="logo">
        Admin Agro
      </Link>
      <div className="nav-links">
        {showLoginButton && <a href="/login">Iniciar Sesión</a>}
        {showSignupButton && <a href="/register">Registrarse</a>}
        {showPlotsButton && <a href="/plots">Plots</a>}
        {/* Agrega más enlaces según sea necesario */}
      </div>
    </nav>
  );
};

export default NavBar;