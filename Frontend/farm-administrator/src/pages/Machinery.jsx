import React, { useState, useEffect } from 'react';
import { useData } from '../context/DataContext';
import PlotManagement from '../components/AddPlotModal';
import { Button, Modal, Card } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';
import EditPlot from '../components/EditPlot';
import { useAuth } from '../context/AuthContext';
import axios from 'axios';
import EditMachine from '../components/EditMachine';
import MachineryManagement from '../components/AddMachineryModal';



const Machinery = () => {
  const { plots, getPlots, deletePlot } = useData();
  const [newMachineName, setNewMachineName] = useState('');
  const [error, setError] = useState(null);
  const [selectedMachineId, setSelectedMachineId] = useState(null);
  const [selectedMachineData, setSelectedMachineData] = useState(null);
  const navigate = useNavigate();
  const [showEditModal, setShowEditModal] = useState(false);
  const [machines, setMachines] = useState([]);
  const { user, isLogin } = useAuth();

  const getMachines = async () => {
    try {
      if (isLogin) {
        const response = await axios.get(
          `https://localhost:7182/api/Machinery/GetByUser/${user.idUser}`,
          {
            headers: {
              Authorization: `Bearer ${user.token}`,
            },
          }
        );
        console.log(response.data);
        setMachines([...response.data]);
      }
    } catch (error) {
      console.error('Error al obtener machines', error);
    }
  };

  const deleteMachine = async (machineId) => {
    try {
      if (isLogin) {
        const response = await axios.delete(
          `https://localhost:7182/api/Machinery/Delete/${machineId}`,
          {
            headers: {
              Authorization: `Bearer ${user.token}`,
            },
          }
        );
        getMachines();
        console.log("Machine succesfully deleted");
        console.log(user.token);
      }
    } catch (error) {
      console.error('An error ocurred while deleting the machine', error);
    }
  };

  useEffect(() => {
    getMachines();
  }, [isLogin, user]);


  const handleEdit = (machine) => {
    console.log(machine);
    setSelectedMachineData(machine);
    setShowEditModal(true);
    
  };

  const handleNavMaintenances = (machineId) => {
    setSelectedMachineId(machineId);
    navigate(`/machinery/maintenances/${machineId}`);
  };

  const handleNavConsumes = (machineId) => {
    setSelectedMachineId(machineId);
    navigate(`/machinery/consumes/${machineId}`);
  };

  return (
    <div>
        <div className='row text-center m-2'>
          <h1>Maquinarias</h1>
        </div>
        <div className='row'>
          <MachineryManagement />
        </div>

      <div className="row">
        {machines.map((machine) => (
          <div key={machine.idMachine} className="col-lg-3 col-md-4 col-sm-6 mb-3">
                <Card className="card m-2 text-center">
                <Card.Header>
                  <Card.Title>{machine.name}</Card.Title>
                </Card.Header>
                  <Card.Body className="card-body">
                    <Card.Text className="card-text">Tipo: {machine.machineType}</Card.Text>
                    <Card.Text className="card-text">Marca: {machine.brand}</Card.Text>
                    <Card.Text className="card-text">Modelo: {machine.model}</Card.Text>
                    <div className='row'>
                      <Button
                        type="button"
                        className="btn m-1 col"
                        variant="outline-light"
                        size='sm'
                        onClick={() => handleNavConsumes(machine.idMachine)}
                      >
                        Consumos
                      </Button>
                      <Button
                        type="button"
                        className="btn m-1 col"
                        variant="outline-light"
                        size='sm'
                        onClick={() => handleNavMaintenances(machine.idMachine)}
                      >
                        Mantenimientos
                      </Button>

                    </div>

                    <div className='row'>
                      <Button
                        type="button"
                        className="col btn m-1"
                        variant="outline-warning"
                        size='sm'
                        onClick={() => handleEdit(machine)}
                      >
                        Editar
                      </Button>
                      <Button
                        type="button"
                        className="col btn m-1"
                        variant='outline-danger'
                        size='sm'
                        onClick={() => deleteMachine(machine.idMachine)}
                      >
                        Eliminar
                      </Button>
                    </div>
                  </Card.Body>
                </Card>
                {/* Modal de edición dentro de cada tarjeta */}
                <Modal show={showEditModal} onHide={() => setShowEditModal(false)}>
                    <Modal.Header closeButton>
                        <Modal.Title>Editar Maquina</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <EditMachine machine={selectedMachineData} onSubmit={() => setShowEditModal(false)} />
                    </Modal.Body>
                </Modal>
            </div>
        ))}
        </div>
    </div>
  );
};

export default Machinery;
