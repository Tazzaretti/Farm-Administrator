import React, { useState } from 'react';
import { Modal, Button } from 'react-bootstrap';
import EditPlot from './EditPlot';

const EditPlotModal = ({ show, handleClose, handleEditPlot }) => {
  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Editar Plot</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        {/* Pasa la función handleEditPlot directamente al componente EditPlot */}
        <EditPlot onSubmit={handleEditPlot} />
      </Modal.Body>
    </Modal>
  );
};

const EditPlotManagement = () => {
  const [showEditPlotModal, setShowEditPlotModal] = useState(false);

  const handleEditPlot = () => {
    // Lógica local después de modificar el plot (si es necesario)
    console.log('Plot modificado exitosamente');
    // Cierra el modal después de modificar el plot
    setShowEditPlotModal(false);
  };

  return (
    <div>
      <Button variant="dark" className='m-2' onClick={() => setShowEditPlotModal(true)}>
        Editar lote
      </Button>

      <EditPlotModal
        show={showEditPlotModal}
        handleClose={() => setShowEditPlotModal(false)}
        handleEditPlot={handleEditPlot}
      />
    </div>
  );
};

export default EditPlotManagement;
