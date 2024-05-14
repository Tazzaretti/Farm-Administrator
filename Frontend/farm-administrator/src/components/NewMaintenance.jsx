import React, { useState } from 'react';
import { Button } from 'react-bootstrap';
import axios from 'axios';
import { useData } from '../context/DataContext';
import useNotify from "../hooks/useNotify";
import { useParams } from 'react-router-dom';

const NewMaintenance = () => {
  const { successMessage, errorMessage } = useNotify();
  const { idMachine } = useParams();
  const [maintenanceData, setMaintenanceData] = useState({
    idMachine: idMachine,
    date: "",
    description: "",
    workedHours: "",
    sparePartsUsed: "",
    cost: "",
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setMaintenanceData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };
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

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      // Realiza la llamada al backend para agregar el maintenance utilizando Axios
      console.log(maintenanceData);
      const response = await axios.post('https://localhost:7182/api/Machinery/AddMaintenance', maintenanceData);
      // Llama a onSubmit solo si la llamada al backend fue exitosa
      successMessage("El maintenance se creó con éxito");
    } catch (error) {
        console.log(error);
      errorMessage("Ocurrió un error al crear el maintenance");
    }
  };

  return (
    <form className="row g-3" onSubmit={handleSubmit}>
      <div className="col-md-6">
        <label htmlFor="description" className="form-label">
          Descripción
        </label>
        <input
          type="text"
          className="form-control"
          id="description"
          name="description"
          placeholder='Ingresar descripcion'
          value={maintenanceData.description}
          onChange={handleChange}
        />
      </div>
      <div className="col-md-6">
        <label htmlFor="sparePartsUsed" className="form-label">
          Insumos
        </label>
        <input
          type="text"
          className="form-control"
          id="sparePartsUsed"
          name="sparePartsUsed"
          placeholder='Ingresar insumos'
          value={maintenanceData.sparePartsUsed}
          onChange={handleChange}
        />
      </div>
      <div className="col-md-6">
        <label htmlFor="workedHours" className="form-label">
          Horas de la maquina
        </label>
        <input
          type="number"
          className="form-control"
          id="workedHours"
          name="workedHours"
          value={maintenanceData.workedHours}
          onChange={handleChange}
        />
      </div>
      <div className="col-md-6">
        <label htmlFor="date" className="form-label">
          Fecha
        </label>
        <input
          type="datetime-local"
          className="form-control"
          id="date"
          name="date"
          value={maintenanceData.date}
          onChange={handleChange}
        />
      </div>
      <div className="col-md-6">
        <label htmlFor="cost" className="form-label">
          Costo
        </label>
        <input
          type="number"
          className="form-control"
          id="cost"
          name="cost"
          value={maintenanceData.cost}
          onChange={handleChange}
        />
      </div>
      <div className="col-12">
        <Button variant="outline-success" type="submit">
          Agregar Mantenimiento
        </Button>
      </div>
    </form>
  );
};

export default NewMaintenance;