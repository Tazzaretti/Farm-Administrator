import React, { useState } from 'react';
import { Card, Button, Modal } from 'react-bootstrap';

const ApplicationCard = ({ application }) => {
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
        <Card.Title>{application.startDate.split('T')[0]}</Card.Title>
        <Card.Subtitle className="mb-2 text-muted">Temporada: {application.season}</Card.Subtitle>
        <Button variant="primary" onClick={handleShow}>
          Ver Detalles
        </Button>
      </Card.Body>

      <Modal show={showModal} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Detalles de la Cosecha</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <p><strong>Fecha de Inicio:</strong> {application.startDate}</p>
          <p><strong>Fecha de Finalizacion:</strong> {application.endDate}</p>
          <p><strong>Metodo:</strong> {application.method}</p>
          <p><strong>Cultivo:</strong> {application.crop}</p>
          <p><strong>Notas:</strong> {application.notes}</p>
          <p><strong>Costo:</strong> {application.cost}</p>
          <p><strong>ID del Lote:</strong> {application.idPlot}</p>
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

export default ApplicationCard;
