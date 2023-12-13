import React, { useState } from 'react';
import '../styles/RegisterForm.css';

const RegisterForm = () => {
 const [email, setEmail] = useState('');
 const [password, setPassword] = useState('');
 const [name, setName] = useState('');
 const [lastName, setLastName] = useState('');
 const [telephone, setTelephone] = useState('');

 const handleSubmit = (e) => {
    e.preventDefault();
    console.log('An email was submitted: ', email);
    console.log('A password was submitted: ', password);
 };

 return (
    <div className="register-container">
      <h2>Register</h2>
      <form onSubmit={handleSubmit}>
        <label>
          Email:
          <input
            type="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
        </label>
        <label>
          Contraseña:
          <input
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
        </label>
        <label>
          Nombre:
          <input
            type="name"
            value={name}
            onChange={(e) => setName(e.target.value)}
            required
          />
        </label>
        <label>
          Apellido:
          <input
            type="lastName"
            value={lastName}
            onChange={(e) => setLastName(e.target.value)}
            required
          />
        </label>
        <label>
          Telefono:
          <input
            type="telephone"
            value={telephone}
            onChange={(e) => setTelephone(e.target.value)}
            required
          />
        </label>
        <button type="submit">Register</button>
      </form>
    </div>
 );
};

export default RegisterForm;