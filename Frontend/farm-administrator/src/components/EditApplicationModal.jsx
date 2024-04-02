import React, { useState } from 'react';
import { Modal, Button } from 'react-bootstrap';
import EditApplication from './EditApplication';

const EditApplicationModal = ({ show, handleClose, handleEditApplication }) => {
  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Editar Siembra</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        {/* Pasa la función handleEditApplication directamente al componente EditApplication */}
        <EditApplication onSubmit={handleEditApplication} />
      </Modal.Body>
    </Modal>
  );
};

const EditApplicationManagement = () => {
  const [showEditApplicationModal, setShowEditApplicationModal] = useState(false);

  const handleEditApplication = () => {
    // Lógica local después de modificar el Application (si es necesario)
    console.log('Application modificado exitosamente');
    // Cierra el modal después de modificar el Applicationg
    setShowEditApplicationModal(false);
  };

  return (
    <div>
      <Button variant="dark" className='m-2' onClick={() => setShowEditApplicationModal(true)}>
        Editar aplicacion
      </Button>

      <EditApplicationtModal
        show={showEditApplicationModal}
        handleClose={() => setShowEditApplicationModal(false)}
        handleEditApplication={handleEditApplication}
      />
    </div>
  );
};

export default EditApplicationModal;
