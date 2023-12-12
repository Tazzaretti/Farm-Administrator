import React, { useState } from 'react';
import '../styles/AuthCard.css';

const AuthCard = () => {
  const [activeTab, setActiveTab] = useState('login');

  const handleTabChange = (tab) => {
    setActiveTab(tab);
  };

  return (
    <div className="auth-card-container">
      <div className="auth-card">
        <div className="auth-tabs">
          <div
            className={`auth-tab ${activeTab === 'login' ? 'active' : ''}`}
            onClick={() => handleTabChange('login')}
          >
            Iniciar Sesión
          </div>
          <div
            className={`auth-tab ${activeTab === 'register' ? 'active' : ''}`}
            onClick={() => handleTabChange('register')}
          >
            Registrarse
          </div>
        </div>
        <div className="auth-content">
          {/* Contenido del formulario de inicio de sesión o registro */}
          {activeTab === 'login' && <LoginForm />}
          {activeTab === 'register' && <RegisterForm />}
        </div>
      </div>
    </div>
  );
};

const LoginForm = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

  const handleUsernameChange = (e) => {
    setUsername(e.target.value);
  };

  const handlePasswordChange = (e) => {
    setPassword(e.target.value);
  };

  const handleLoginSubmit = (e) => {
    e.preventDefault();
    // Aquí puedes realizar la lógica de autenticación con username y password
  };

  return (
    <form onSubmit={handleLoginSubmit}>
      <label>
        Usuario:
        <input type="text" value={username} onChange={handleUsernameChange} />
      </label>
      <label>
        Contraseña:
        <input type="password" value={password} onChange={handlePasswordChange} />
      </label>
      <button type="submit">Iniciar Sesión</button>
    </form>
  );
};

const RegisterForm = () => {
  // Contenido del formulario de registro
  return (
    <form>
      {/* Campos de registro */}
    </form>
  );
};

export default AuthCard;