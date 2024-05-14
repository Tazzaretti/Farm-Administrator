import React, { useState } from 'react';
import { Modal, Button } from 'react-bootstrap';
import NewMaintenance from './NewMaintenance';

const AddMaintenanceModal = ({ show, handleClose, handleAddMaintenance }) => {
  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Agregar nuevo mantenimiento</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        {/* Pasa la función handleAddMaintenance directamente al componente NewMaintenance */}
        <NewMaintenance onSubmit={handleAddMaintenance} />
      </Modal.Body>
    </Modal>
  );
};

const MaintenanceManagement = () => {
  const [showAddMaintenanceModal, setShowAddMaintenanceModal] = useState(false);

  const handleAddMaintenance = () => {
    // Lógica local después de agregar el Maintenance (si es necesario)
    console.log('Maintenance agregado exitosamente');
    // Cierra el modal después de agregar el Maintenance
    setShowAddMaintenanceModal(false);
  };

  return (
    <div>
      <Button variant="outline-success" className='m-2' onClick={() => setShowAddMaintenanceModal(true)}>
        Agregar Mantenimiento
      </Button>

      <AddMaintenanceModal
        show={showAddMaintenanceModal}
        handleClose={() => setShowAddMaintenanceModal(false)}
        handleAddMaintenancet={handleAddMaintenance}
      />
    </div>
  );
};

export default MaintenanceManagement;