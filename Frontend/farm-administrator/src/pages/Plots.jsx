import React, { useState, useEffect } from 'react';
import { useData } from '../context/DataContext';
import PlotManagement from '../components/AddPlotModal';
import { Button, Modal } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';
import EditPlot from '../components/EditPlot';

const Plots = () => {
  const { plots, getPlots, deletePlot } = useData();
  const [newPlotName, setNewPlotName] = useState('');
  const [error, setError] = useState(null);
  const [selectedPlotId, setSelectedPlotId] = useState(null);
  const [selectedPlotData, setSelectedPlotData] = useState(null);
  const navigate = useNavigate();
  const [showEditModal, setShowEditModal] = useState(false);

  useEffect(() => {
    getPlots().catch((error) => {
      console.error('Error al obtener plots:', error);
      setError('Error al obtener plots');
    });
  }, []);

  const handleDelete = async (plotId) => {
    try {
      await deletePlot(plotId);
      getPlots();
    } catch (error) {
      console.error('Error al eliminar plot:', error);
      setError('Error al eliminar plot');
    }
  };

  const handleEdit = (plot) => {
    console.log(plot);
    setSelectedPlotData(plot);
    setShowEditModal(true);
    
  };

  const handleNavHarvest = (plotId) => {
    setSelectedPlotId(plotId);
    navigate(`/plots/harvests/${plotId}`);
  };

  const handleNavApplications = (plotId) => {
    setSelectedPlotId(plotId);
    navigate(`/plots/applications/${plotId}`);
  };

  const handleNavPlantings = (plotId) => {
    setSelectedPlotId(plotId);
    navigate(`/plots/plantings/${plotId}`);
  };

  const handleAddPlanting = () => {
    navigate(`/plots/${selectedPlotId}/add-planting`);
  };

  return (
    <div>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      <div className='row text-center m-2'>
        <h1>Lotes</h1>
      </div>
      <div className='row'>
        <PlotManagement />
      </div>
      <div className="row">
        {plots.map((plot) => (
          <div key={plot.idPlot} className="col-lg-3 col-md-4 col-sm-6 mb-3">
            <div className="card m-2 text-center">
              <div className="card-body">
                <h5 className="card-title">{plot.plotName}</h5>
                <p className="card-text">Tamaño: {plot.size}</p>
                <p className="card-text">Tipo de suelo: {plot.groundType}</p>
                <div className='row'>
                  <Button
                    type="button"
                    className="btn m-1 col"
                    variant="outline-dark"
                    onClick={() => handleNavHarvest(plot.idPlot)}
                  >
                    Cosechas
                  </Button>
                  <Button
                    type="button"
                    className="btn m-1 col"
                    variant="outline-dark"
                    onClick={() => handleNavPlantings(plot.idPlot)}
                  >
                    Siembras
                  </Button>
                  <Button
                    type="button"
                    className="btn m-1 col"
                    variant="outline-dark"
                    onClick={() => handleNavApplications(plot.idPlot)}
                  >
                    Aplicaciones
                  </Button>
                </div>

                <div className='row'>
                  <Button
                    type="button"
                    className="col btn m-1"
                    variant="outline-warning"
                    onClick={() => handleEdit(plot)}
                  >
                    Editar
                  </Button>
                  <Button
                    type="button"
                    className="col btn m-1"
                    variant='outline-danger'
                    onClick={() => handleDelete(plot.idPlot)}
                  >
                    Eliminar
                  </Button>
                </div>
              </div>
            </div>
            {/* Modal de edición dentro de cada tarjeta */}
            <Modal show={showEditModal} onHide={() => setShowEditModal(false)}>
              <Modal.Header closeButton>
                <Modal.Title>Editar Plot</Modal.Title>
              </Modal.Header>
              <Modal.Body>
                <EditPlot plot={selectedPlotData} onSubmit={() => setShowEditModal(false)} />
              </Modal.Body>
            </Modal>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Plots;
