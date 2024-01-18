import React, { useState, useEffect } from 'react';
import { useData } from '../context/DataContext';
import PlotManagement from '../components/AddPlotModal';
import { Button } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';


const Plots = () => {
  const { plots, getPlots, deletePlot } = useData();
  const [newPlotName, setNewPlotName] = useState('');
  const [error, setError] = useState(null);
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

  return (
    <div>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      <h1>Lista de Plots</h1>
      <PlotManagement />
      <div className="row">
        {plots.map((plot) => (
          <div key={plot.idPlot} className="col-sm-6 mb-3">
            <div className="card">
              <div className="card-body">
                <h5 className="card-title">{plot.plotName}</h5>
                <h6 className="card-subtitle mb-2 text-muted">ID: {plot.idPlot}</h6>
                <p className="card-text">Size: {plot.size}</p>
                <p className="card-text">Ground Type: {plot.groundType}</p>
                <Button
                  type="button"
                  className="btn"
                  variant='dark'
                  onClick={() => navigate(`/plots/${plot.idPlot}`)} // Nueva línea para navegar a la página de detalles
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
