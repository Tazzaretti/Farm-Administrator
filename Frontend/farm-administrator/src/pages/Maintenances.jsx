import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Table from 'react-bootstrap/Table';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import { useParams } from 'react-router-dom';

const Maintenances = () => {
  const { idMachine } = useParams();
  const [maintenances, setMaintenances] = useState([]);

  useEffect(() => {
    const getMaintenancesForMachine = async () => {
      try {
        const response = await axios.get(`https://localhost:7182/api/Machinery/GetMachineMaintenances/${idMachine}`);
        const sortedMaintenances = response.data.sort((a, b) => new Date(b.date) - new Date(a.date));
        setMaintenances(sortedMaintenances);
      } catch (error) {
        console.error('Error al obtener mantenimientos de la maquina:', error);
        throw new Error('Error al obtener mantenimientos de la maquina');
      }
    };

    getMaintenancesForMachine();
  }, [idMachine]);

  return (
    <div>
      <Form>
        <Form.Group controlId="maintenances">
          <h1 className='text-center m-2 align-middle'>Mantenimientos</h1>
        </Form.Group>
      </Form>
      <Table striped bordered hover>
        <thead>
          <tr className='text-center align-middle'>
            <th>Fecha</th>
            <th>Descripcion</th>
            <th>Horas maquina</th>
            <th>Insumos</th>
            <th>Costo</th>
          </tr>
        </thead>
        <tbody>
          {maintenances.map((maintenance, index) => (
            <tr key={index} className='text-center align-middle'>
              <td>{new Date(maintenance.date).toLocaleDateString()}</td>
              <td>{maintenance.description}</td>
              <td>{maintenance.workedHours}</td>
              <td>{maintenance.sparePartsUsed}</td>
              <td>{maintenance.cost}</td>
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  );
};

export default Maintenances;
