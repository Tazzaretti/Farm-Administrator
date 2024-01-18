import React, { useState } from 'react';
import { Modal, Button } from 'react-bootstrap';
import NewPlot from './NewPlot';

const AddPlotModal = ({ show, handleClose, handleAddPlot }) => {
  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Agregar Nuevo Plot</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        {/* Pasa la función handleAddPlot directamente al componente NewPlot */}
        <NewPlot onSubmit={handleAddPlot} />
      </Modal.Body>
    </Modal>
  );
};

const PlotManagement = () => {
  const [showAddPlotModal, setShowAddPlotModal] = useState(false);

  const handleAddPlot = () => {
    // Lógica local después de agregar el plot (si es necesario)
    console.log('Plot agregado exitosamente');
    // Cierra el modal después de agregar el plot
    setShowAddPlotModal(false);
  };

  return (
    <div>
      <Button variant="dark" className='mb-2' onClick={() => setShowAddPlotModal(true)}>
        Agregar Plot
      </Button>

      <AddPlotModal
        show={showAddPlotModal}
        handleClose={() => setShowAddPlotModal(false)}
        handleAddPlot={handleAddPlot}
      />
    </div>
  );
};

export default PlotManagement;
