import React, { useState } from 'react';
import { Modal, Button } from 'react-bootstrap';
import EditPlanting from './EditPlanting';

const EditPlantingModal = ({ show, handleClose, handleEditPlanting }) => {
  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Editar Siembra</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        {/* Pasa la función handleEditPlanting directamente al componente EditPlanting */}
        <EditPlanting onSubmit={handleEditPlanting} />
      </Modal.Body>
    </Modal>
  );
};

const EditPlantingManagement = () => {
  const [showEditPlantingModal, setShowEditPlantingModal] = useState(false);

  const handleEditPlanting = () => {
    // Lógica local después de modificar el planting (si es necesario)
    console.log('Planting modificado exitosamente');
    // Cierra el modal después de modificar el planting
    setShowEditPlantingModal(false);
  };

  return (
    <div>
      <Button variant="dark" className='m-2' onClick={() => setShowEditPlantingModal(true)}>
        Editar lote
      </Button>

      <EditPlantingtModal
        show={showEditPlantingModal}
        handleClose={() => setShowEditPlantingModal(false)}
        handleEditPlanting={handleEditPlanting}
      />
    </div>
  );
};

export default EditPlantingModal;
