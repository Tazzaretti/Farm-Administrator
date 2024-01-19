import React, { useState } from 'react';
import { Card, Button, Modal } from 'react-bootstrap';

const PlantingCard = ({ planting }) => {
  const [showModal, setShowModal] = useState(false);

  const handleShow = () => {
    setShowModal(true);
  };

  const handleClose = () => {
    setShowModal(false);
  };

  return (
    <Card style={{ width: '18rem' }}>
      <Card.Body>
        <Card.Title>{planting.startDate.split('T')[0]}</Card.Title>
        <Card.Subtitle className="mb-2 text-muted">Temporada: {planting.season}</Card.Subtitle>
        <Button variant="primary" onClick={handleShow}>
          Ver Detalles
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
    </Card>
  );
};

export default PlantingCard;
