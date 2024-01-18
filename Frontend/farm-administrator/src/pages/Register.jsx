import React from 'react';
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';
import Form from 'react-bootstrap/Form';

const Register = () => {
  return (
    <div className="d-flex align-items-center justify-content-center" style={{ height: '100vh' }}>
      <Card style={{ width: '20rem' }}>
        <Card.Header as="h5">Registrar Nuevo Usuario</Card.Header>
        <Card.Body>
          <Form>
            <Form.Group controlId="Email" className='mb-3'>
              <Form.Label>Email</Form.Label>
              <Form.Control type="email" placeholder="Email" />
              <Form.Text className="text-muted">
                Nunca compartiremos su Email con nadie mas.
              </Form.Text>
            </Form.Group>

            <Form.Group controlId="Password" className="mb-3">
              <Form.Label>Password</Form.Label>
              <Form.Control type="password" placeholder="Contrasenia" />
            </Form.Group>

            <Form.Group controlId="Name" className="mb-3">
              <Form.Label>Nombre</Form.Label>
              <Form.Control type="text-muted" placeholder="Ingrese su nombre" />
            </Form.Group>

            <Form.Group controlId="LastName" className="mb-3">
              <Form.Label>Apellido</Form.Label>
              <Form.Control type="text-muted" placeholder="Ingrese su apellido" />
            </Form.Group>

            <Form.Group controlId="Phone" className="mb-3">
              <Form.Label>Telefono</Form.Label>
              <Form.Control type="text-muted" placeholder="Ingrese su telefono" />
            </Form.Group>

            <Form.Group controlId="Adress" className="mb-3">
              <Form.Label>Direccion</Form.Label>
              <Form.Control type="text-muted" placeholder="Ingrese su direccion" />
            </Form.Group>
            
            <Form.Label>Selecciona una opción</Form.Label>
            <Form.Select custom className="mb-3">
              <option value="Agricultor">Agricultor</option>
              <option value="Ingeniero">Ingeniero</option>
              <option value="Investigador">Investigador</option>
              <option value="Transportista">Transportista</option>
              <option value="Empleado">Empleado</option>
            </Form.Select>
            <Button variant="dark" type="submit">
              Submit
            </Button>
          </Form>
        </Card.Body>
      </Card>
    </div>
  );
};

export default Register;