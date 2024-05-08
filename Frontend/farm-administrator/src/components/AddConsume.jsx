import React, { useState } from 'react';
import axios from 'axios';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';

const AddConsumption = ({ idMachine, onAddConsumption }) => {
  const [litersQuantity, setLitersQuantity] = useState('');

  const handleAddConsumption = async () => {
    try {
      const response = await axios.post('https://localhost:7182/api/Machinery/AddFuelConsumption', {
        idMachine,
        recordDate: new Date().toISOString(), // Fecha actual
        litersQuantity: parseFloat(litersQuantity) // Convertir a número
      });
      // Si la solicitud es exitosa, llama a la función onAddConsumption
      // para actualizar los datos de consumos en el componente principal
      onAddConsumption(response.data);
      // Limpia el input después de agregar el consumo
      setLitersQuantity('');
    } catch (error) {
      console.error('Error al agregar consumo:', error);
      // Manejar el error según lo necesites
    }
  };

  return (
    <Form>
      <Form.Group controlId="litersQuantity">
        <Form.Label>Litros</Form.Label>
        <Form.Control
          type="number"
          value={litersQuantity}
          onChange={(e) => setLitersQuantity(e.target.value)}
          placeholder="Litros"
        />
      </Form.Group>
      <Button variant="outline-light" className='' onClick={handleAddConsumption}>
        Agregar Consumo
      </Button>
    </Form>
  );
};

export default AddConsumption;
