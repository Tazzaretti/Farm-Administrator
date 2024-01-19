import React, { useState, useEffect } from 'react';
import { useData } from '../context/DataContext';
import PlantingCard from './PlantingCard';

const PlantingsList = ({ plotId }) => {
  const { getPlantingsForPlot } = useData();
  const [plantings, setPlantings] = useState([]);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const plantingsResponse = await getPlantingsForPlot(plotId);
        setPlantings(plantingsResponse);
      } catch (error) {
        console.error('Error al obtener siembras para el lote:', error);
        setError('Error al obtener siembras para el lote');
      }
    };

    fetchData();
  }, [plotId, getPlantingsForPlot]);

  return (
    <div>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      <div className="row">
        {plantings.map((planting) => (
          <div key={planting.idPlanting} className="col-md-4 mb-3">
            <PlantingCard planting={planting} />
          </div>
        ))}
      </div>
    </div>
  );
};

export default PlantingsList;
