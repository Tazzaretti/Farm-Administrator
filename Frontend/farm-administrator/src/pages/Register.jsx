import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import { useState } from 'react';
import axios from 'axios';
import useNotify from '../hooks/useNotify';
import { useNavigate } from 'react-router-dom';

const Register = (onSubmit) => {
  const { successMessage, errorMessage } = useNotify(); 
  const [validated, setValidated] = useState(false);
  const navigate = useNavigate();
  const [userData, setUserData] = useState({
    idUser: 0,
    password: '',
    name: '',
    lastName: '',
    userRole: 1,
    userType: 0,
    email: '',
    phone: 0,
    address: '',
    experience: '',
    education: '',
    state: 0,
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setUserData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const RegisterFunction = async () => {
    console.log('dentro de data context')
    console.log(userData);
    try {
      const response = await axios.post('https://localhost:7182/api/Auth/Registro', userData);
      successMessage('El usuario se creó con éxito');
    } catch (error) {
      console.log(error)
      errorMessage('Hubo un error al crear el usuario', error)
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    const form = e.currentTarget;

    if (form.checkValidity() === false) {
      e.stopPropagation();
    } else {
      try {
        await RegisterFunction();
        navigate('/login')
        console.log('después de enviar datos');
      } catch (error) {
        console.error('Error al crear usuario', error);
      }
    }

    setValidated(true);
  };

  return (
    <div className="d-flex align-items-center justify-content-center m-3" style={{ marginTop: '80px' }}>
      <Form noValidate validated={validated} onSubmit={handleSubmit}>
        <Form.Group className="mb-3">
          <Form.Label>Email</Form.Label>
          <Form.Control
            required
            type="text"
            className="form-control"
            id="email"
            name="email"
            placeholder='Ingresar email'
            value={userData.email}
            onChange={handleChange}
          />
          <Form.Control.Feedback type="invalid">Ingrese un Email valido.</Form.Control.Feedback>
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Password</Form.Label>
          <Form.Control
            required
            type="password"
            className="form-control"
            id="password"
            name="password"
            placeholder='Ingrese su clave'
            value={userData.password}
            onChange={handleChange}
          />
          <Form.Control.Feedback type="invalid">Ingrese una clave valida.</Form.Control.Feedback>
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Name</Form.Label>
          <Form.Control
            required
            type="text"
            className="form-control"
            id="name"
            name="name"
            placeholder='Nombre'
            value={userData.name}
            onChange={handleChange}
          />
          <Form.Control.Feedback type="invalid">Ingrese un nombre valido.</Form.Control.Feedback>
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Last Name</Form.Label>
          <Form.Control
            required
            type="text"
            className="form-control"
            id="lastName"
            name="lastName"
            value={userData.lastName}
            onChange={handleChange}
          />
          <Form.Control.Feedback type="invalid">Ingrese un apellido valido.</Form.Control.Feedback>
        </Form.Group>

        <Form.Group className="mb-3" >
          <Form.Label>Phone</Form.Label>
          <Form.Control
            required
            type="number"
            className="form-control"
            id="phone"
            name="phone"
            value={userData.phone}
            onChange={handleChange}
          />
          <Form.Control.Feedback type="invalid">Ingrese un numero de telefono valido.</Form.Control.Feedback>
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Address</Form.Label>
          <Form.Control
            required
            type="text"
            className="form-control"
            id="adress"
            name="adress"
            value={userData.adress}
            onChange={handleChange}
          />
          <Form.Control.Feedback type="invalid">Ingrese una direccion valida.</Form.Control.Feedback>
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Experience</Form.Label>
          <Form.Control
            required
            type="text"
            className="form-control"
            id="experience"
            name="experience"
            value={userData.experience}
            onChange={handleChange}
          />
          <Form.Control.Feedback type="invalid">Ingrese experiencia valida.</Form.Control.Feedback>
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Education</Form.Label>
          <Form.Control
            required
            type="text"
            className="form-control"
            id="education"
            name="education"
            value={userData.education}
            onChange={handleChange}
          />
          <Form.Control.Feedback type="invalid">Ingrese educacion valida.</Form.Control.Feedback>
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>User Type</Form.Label>
          <Form.Select
            required
            id="userType"
            name="userType"
            className="form-select"
            value={userData.userType}
            onChange={handleChange}
          >
            <option value="">Select user type</option>
            <option value="1">Agricultor</option>
            <option value="2">Ingeniero</option>
            <option value="3">Investigador</option>
            <option value="4">Transportista</option>
            <option value="5">Empleado</option>
          </Form.Select>
          <Form.Control.Feedback type="invalid">Ingrese un tipo de usuario.</Form.Control.Feedback>
        </Form.Group>

        <Button variant="outline-success" type="submit">
          Register
        </Button>
      </Form>
    </div>
  );
};

export default Register;
