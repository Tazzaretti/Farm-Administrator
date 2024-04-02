import React, { useState } from 'react';
import { Card, Button, Modal } from 'react-bootstrap';
import EditPlanting from './EditPlanting';

const PlantingCard = ({ planting }) => {
  const [showModal, setShowModal] = useState(false);
  const [showEditModal, setShowEditModal] = useState(false);
  const [selectedPlantingData, setSelectedPlantingData] = useState(null);

  const handleShow = () => {
    setShowModal(true);
  };

  const handleClose = () => {
    setShowModal(false);
  };

  const handleEdit = (planting) => {
    console.log(planting);
    setSelectedPlantingData(planting);
    setShowEditModal(true);
    
  };

  return (
    <Card style={{ width: '18rem' }}>
      <Card.Body>
        <Card.Title>{planting.startDate ? planting.startDate.split('T')[0] : "No hay fecha de inicio"}</Card.Title>
        <Card.Subtitle className="mb-2 text-muted">Temporada: {planting.season}</Card.Subtitle>
        <Button variant="primary" onClick={handleShow}>
          Ver Detalles
        </Button>
        <Button
          type="button"
          className="btn m-1"
          variant="dark"
          onClick={() => handleEdit(planting)}
        >
          Editar
        </Button>
      </Card.Body>

      <Modal show={showModal} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Detalles de la Siembra</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <p><strong>Fecha de Inicio:</strong> {planting.startDate}</p>
          <p><strong>Temporada:</strong> {planting.season}</p>
          <p><strong>Profundidad:</strong> {planting.deep}</p>
          <p><strong>Distancia:</strong> {planting.distance}</p>
          <p><strong>Tamaño:</strong> {planting.size}</p>
          <p><strong>Fecha de Fin:</strong> {planting.endDate}</p>
          <p><strong>Costo:</strong> {planting.cost}</p>
          <p><strong>ID del Lote:</strong> {planting.idPlot}</p>
          {/* Agrega más detalles según sea necesario */}
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Cerrar
          </Button>
        </Modal.Footer>
      </Modal>
      {/* Modal de edición dentro de cada tarjeta */}
      <Modal show={showEditModal} onHide={() => setShowEditModal(false)}>
        <Modal.Header closeButton>
          <Modal.Title>Editar Planting</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <EditPlanting planting={selectedPlantingData} onSubmit={() => setShowEditModal(false)} />
        </Modal.Body>
      </Modal>
    </Card>
  );
};

export default PlantingCard;
