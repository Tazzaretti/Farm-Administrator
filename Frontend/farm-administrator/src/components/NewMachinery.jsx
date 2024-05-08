import React, { useState } from 'react';
import { Button } from 'react-bootstrap';
import axios from 'axios';
import { useAuth } from '../context/AuthContext';
import useNotify from "../hooks/useNotify"

const NewMachinery = ({ onSubmit }) => {
    const { successMessage, errorMessage } = useNotify();
    const {user} = useAuth();
    const [machineData, setMachineData] = useState({
        idMachine: 0,  // Puedes dejarlo como 0 si el servidor asigna un ID
        name: "",
        brand: "",
        model: "", // Reemplaza con el nombre real del lote
        machineType: "",  // Reemplaza con el tamaño real del lote
        yearManufactured: "",  // Reemplaza con el tipo de suelo real
        workingHours: 0,  // Reemplaza con el propietario real
        idState: 1,
    });

    const handleChange = (e) => {
      const { name, value } = e.target;
      setMachineData((prevData) => ({
        ...prevData,
        [name]: value,
      }));
    };
    
    const handleSubmit = async (e) => {
        e.preventDefault();
      
        try {
          const response = await axios.post(
            `https://localhost:7182/api/Machinery/AddMachinery?userId=${user.idUser}`, // Pasar el ID del usuario como parámetro de consulta
            machineData, // Pasar los datos de la maquinaria como cuerpo de la solicitud
            { headers: { 'Content-Type': 'application/json' } } // Especificar el tipo de medio como JSON
          );
      
          onSubmit();
          successMessage("La maquina se creo con exito");
        } catch (error) {
          errorMessage("Ocurrio un error al crear la maquina");
          console.log(error);
        }
      };

    return (
      <form className="row g-3" onSubmit={handleSubmit}>
        <div className="col-md-6">
          <label htmlFor="name" className="form-label">
            Nombre de la maquina
          </label>
          <input
            type="text"
            className="form-control"
            id="name"
            name="name"
            placeholder='Ingresar nombre'
            value={machineData.name}
            onChange={handleChange}
          />
        </div>
        <div className="col-md-6">
          <label htmlFor="brand" className="form-label">
            Marca
          </label>
          <input
            type="text"
            className="form-control"
            id="brand"
            name="brand"
            placeholder='Ingrese la marca'
            value={machineData.brand}
            onChange={handleChange}
          />
        </div>
        <div className="col-md-6">
          <label htmlFor="model" className="form-label">
            Propietario
          </label>
          <input
            type="text"
            className="form-control"
            id="model"
            name="model"
            placeholder='Ingrese el modelo'
            value={machineData.model}
            onChange={handleChange}
          />
        </div>
        <div className="col-md-6">
          <label htmlFor="machineType" className="form-label">
            Tipo de maquinaria
          </label>
          <input
            type="text"
            className="form-control"
            id="machineType"
            name="machineType"
            placeholder='Ingrese el tipo'
            value={machineData.machineType}
            onChange={handleChange}
          />
        </div>
        <div className="col-md-6">
            <label htmlFor="yearManufactured" className="form-label">
                Fecha de Inicio
            </label>
            <input
            type="datetime-local"
            className="form-control"
            id="yearManufactured"
            name="yearManufactured"
            value={machineData.yearManufactured}
            onChange={handleChange}
        />
      </div>
      <div className="col-md-6">
        <label htmlFor="workingHours" className="form-label">
          Costo
        </label>
        <input
          type="number"
          className="form-control"
          id="workingHours"
          name="workingHours"
          value={machineData.workingHours}
          onChange={handleChange}
        />
      </div>
        <div className="col-12">
          <Button variant="outline-success" type="submit">
            Agregar lote
          </Button>
        </div>
      </form>
    );
};

export default NewMachinery;
