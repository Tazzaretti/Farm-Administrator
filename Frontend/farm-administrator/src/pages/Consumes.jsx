import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Table from 'react-bootstrap/Table';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import { useParams } from 'react-router-dom';

const Consumes = () => {
  const { idMachine } = useParams();
  const [consumes, setConsumes] = useState([]);
  const [litersQuantity, setLitersQuantity] = useState('');

  useEffect(() => {
    const getConsumesForMachine = async () => {
      try {
        const response = await axios.get(`https://localhost:7182/api/Machinery/GetMachineConsumes/${idMachine}`);
        const sortedConsumes = response.data.sort((a, b) => new Date(b.recordDate) - new Date(a.recordDate));
        setConsumes(sortedConsumes);
      } catch (error) {
        console.error('Error al obtener consumos de la maquina:', error);
        throw new Error('Error al obtener consumos de la maquina');
      }
    };

    getConsumesForMachine();
  }, [idMachine]);

  const handleAddConsumption = async () => {
    try {
      const response = await axios.post('https://localhost:7182/api/Machinery/AddFuelConsumption', {
        idMachine,
        recordDate: new Date().toISOString(),
        litersQuantity: parseFloat(litersQuantity)
      });
      setConsumes([response.data, ...consumes]);
      setLitersQuantity('');
    } catch (error) {
      console.error('Error al agregar consumo:', error);
      // Manejar el error según lo necesites
    }
  };

  return (
    <div>
      <Form>
        <Form.Group controlId="litersQuantity">
          <h1 className='text-center m-2'>Consumos</h1>
          <Form.Control
            className="col-md-6 m-1"
            type="number"
            value={litersQuantity}
            onChange={(e) => setLitersQuantity(e.target.value)}
            placeholder="Litros"
          />
        </Form.Group>
        <Button variant="outline-success" className='m-2' onClick={handleAddConsumption}>
          Agregar Consumo
        </Button>
      </Form>
      <Table striped bordered hover>
        <thead>
          <tr className='text-center'>
            <th>Fecha</th>
            <th>Litros</th>
          </tr>
        </thead>
        <tbody>
          {consumes.map((consume, index) => (
            <tr key={index} className='text-center'>
              <td>{new Date(consume.recordDate).toLocaleDateString()}</td>
              <td>{consume.litersQuantity}</td>
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  );
};

export default Consumes;
