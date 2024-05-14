import React, { useState } from 'react';
import { Card, Button, Modal } from 'react-bootstrap';
import EditHarvest from './EditHarvest';

const HarvestCard = ({ harvest }) => {
  const [showModal, setShowModal] = useState(false);
  const [showEditModal, setShowEditModal] = useState(false);
  const [selectedHarvestData, setSelectedHarvestData] = useState(null);

  const handleShow = () => {
    setShowModal(true);
  };

  const handleClose = () => {
    setShowModal(false);
  };

  const handleEdit = (harvest) => {
    console.log(harvest);
    setSelectedHarvestData(harvest);
    setShowEditModal(true);
    
  };

  return (
    <Card className="card m-2 text-center">
      <Card.Header><Card.Title>Fecha de inicio: {harvest.startDate.split('T')[0]}</Card.Title></Card.Header>
      <Card.Body>
        <Card.Subtitle className="mb-2 text-muted">Cultivo: {harvest.crop}</Card.Subtitle>
        <Card.Subtitle className="mb-2 text-muted">Metodo: {harvest.method}</Card.Subtitle>
        <div className='row'>
          <Button 
            variant="outline-light" 
            size='sm'
            className='col btn m-1'
            onClick={handleShow}>
            Ver Detalles
          </Button>
          <Button
            type="button"
            className="col btn m-1"
            variant="outline-warning"
            size='sm'
            onClick={() => handleEdit(harvest)}
          >
            Editar
          </Button>
        </div>
        
      </Card.Body>

      <Modal show={showModal} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Detalles de la Cosecha</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <p><strong>Fecha de Inicio:</strong> {harvest.startDate}</p>
          <p><strong>Fecha de Finalizacion:</strong> {harvest.endDate}</p>
          <p><strong>Temporada:</strong> {harvest.season}</p>
          <p><strong>Metodo:</strong> {harvest.method}</p>
          <p><strong>Cultivo:</strong> {harvest.crop}</p>
          <p><strong>Madurez:</strong> {harvest.ripeness}</p>
          <p><strong>Rendimiento:</strong> {harvest.yield}</p>
          <p><strong>Notas:</strong> {harvest.notes}</p>
          <p><strong>Tamaño:</strong> {harvest.size}</p>
          <p><strong>Costo:</strong> {harvest.cost}</p>
          {/* Agrega más detalles según sea necesario */}
        </Modal.Body>
        <Modal.Footer>
          <Button variant="outline-warning" onClick={handleClose}>
            Cerrar
          </Button>
        </Modal.Footer>
      </Modal>
      {/* Modal de edición dentro de cada tarjeta */}
      <Modal show={showEditModal} onHide={() => setShowEditModal(false)}>
        <Modal.Header closeButton>
          <Modal.Title>Editar Cosecha</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <EditHarvest harvest={selectedHarvestData} onSubmit={() => setShowEditModal(false)} />
        </Modal.Body>
      </Modal>
    </Card>
  );
};

export default HarvestCard;
