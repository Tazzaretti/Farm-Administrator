import React, { useState } from 'react';
import { Modal, Button } from 'react-bootstrap';
import NewMachinery from './NewMachinery';

const AddMachineryModal = ({ show, handleClose, handleAddMachinery }) => {
  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Agregar nuevo l ote</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        {/* Pasa la función handleAddMachinery directamente al componente NewMachinery */}
        <NewMachinery onSubmit={handleAddMachinery} />
      </Modal.Body>
    </Modal>
  );
};

const MachineryManagement = () => {
  const [showAddMachineryModal, setShowAddMachineryModal] = useState(false);

  const handleAddMachinery = () => {
    // Lógica local después de agregar el machinery (si es necesario)
    console.log('machinery agregado exitosamente');
    // Cierra el modal después de agregar el machinery
    setShowAddMachineryModal(false);
  };

  return (
    <div>
      <Button variant="outline-success" className='m-2' onClick={() => setShowAddMachineryModal(true)}>
        Agregar maquinaria
      </Button>

      <AddMachineryModal
        show={showAddMachineryModal}
        handleClose={() => setShowAddMachineryModal(false)}
        handleAddMachinery={handleAddMachinery}
      />
    </div>
  );
};

export default MachineryManagement;
