import React, { useState, useEffect } from 'react';
import { useData } from '../context/DataContext';
import PlotManagement from '../components/AddPlotModal';
import { Button } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';

const Plots = () => {
  const { plots, getPlots, deletePlot } = useData();
  const [newPlotName, setNewPlotName] = useState('');
  const [error, setError] = useState(null);
  const [selectedPlotId, setSelectedPlotId] = useState(null); // Nuevo estado para almacenar el idPlot seleccionado
  const navigate = useNavigate();

  useEffect(() => {
    // Llama a getPlots cuando el componente se monta para obtener los plots del usuario
    getPlots().catch((error) => {
      console.error('Error al obtener plots:', error);
      setError('Error al obtener plots');
    });
  }, []); // El segundo argumento [] asegura que useEffect se ejecute solo una vez al montar el componente

  const handleDelete = async (plotId) => {
    try {
      // Llama a la función deletePlot con el ID del plot a eliminar
      await deletePlot(plotId);
      // Luego, vuelve a obtener los plots actualizados
      getPlots();
    } catch (error) {
      console.error('Error al eliminar plot:', error);
      setError('Error al eliminar plot');
    }
  };

  const handleEdit = (plotId) => {
    // Al hacer clic en "Editar", actualiza el estado selectedPlotId
    setSelectedPlotId(plotId);
    // Además, navega a la página de edición del lote
    navigate(`/plots/${plotId}`);
  };

  const handleNavHarvest = (plotId) => {
    // Al hacer clic en "Editar", actualiza el estado selectedPlotId
    setSelectedPlotId(plotId);
    // Además, navega a la página de edición del lote
    navigate(`/plots/harvests/${plotId}`);
  };

  const handleNavApplications = (plotId) => {
    // Al hacer clic en "Editar", actualiza el estado selectedPlotId
    setSelectedPlotId(plotId);
    // Además, navega a la página de edición del lote
    navigate(`/plots/applications/${plotId}`);
  };

  const handleNavPlantings = (plotId) => {
    // Al hacer clic en "Editar", actualiza el estado selectedPlotId
    setSelectedPlotId(plotId);
    // Además, navega a la página de edición del lote
    navigate(`/plots/plantings/${plotId}`);
  };

  const handleAddPlanting = () => {
    // Al hacer clic en "Agregar Planting", navega a la página de edición del lote
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
          <div key={plot.idPlot} className="col-sm-6 mb-3">
            <div className="card m-2">
              <div className="card-body">
                <h5 className="card-title">{plot.plotName}</h5>
                <p className="card-text">Tamanio: {plot.size}</p>
                <p className="card-text">Tipo de suelo: {plot.groundType}</p>
                <Button
                  type="button"
                  className="btn m-1"
                  variant="dark"
                  onClick={() => handleNavHarvest(plot.idPlot)} // Actualiza el idPlot al hacer clic en "Editar"
                >
                  Cosechas
                </Button>
                <Button
                  type="button"
                  className="btn m-1"
                  variant="dark"
                  onClick={() => handleNavPlantings(plot.idPlot)} // Actualiza el idPlot al hacer clic en "Editar"
                >
                  Siembras
                </Button>
                <Button
                  type="button"
                  className="btn m-1"
                  variant="dark"
                  onClick={() => handleNavApplications(plot.idPlot)} // Actualiza el idPlot al hacer clic en "Editar"
                >
                  Aplicaciones
                </Button>
                <Button
                  type="button"
                  className="btn m-1"
                  variant="dark"
                  onClick={() => handleEdit(plot.idPlot)} // Actualiza el idPlot al hacer clic en "Editar"
                >
                  Editar
                </Button>
                <Button
                  type="button"
                  className="btn btn-danger m-1"
                  onClick={() => handleDelete(plot.idPlot)}
                >
                  Eliminar
                </Button>
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Plots;