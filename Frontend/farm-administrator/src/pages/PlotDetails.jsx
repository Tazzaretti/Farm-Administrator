import React, { useState, useEffect } from 'react';
import { useData } from '../context/DataContext';
import { Card, ListGroup, ListGroupItem } from 'react-bootstrap'; // Ajusta las importaciones según tus necesidades
import { useParams } from 'react-router-dom';

const PlotDetails = ({ plotId }) => {
  const { getPlantingsForPlot, getPlotById } = useData();
  const [plotDetails, setPlotDetails] = useState({});
  const [plantings, setPlantings] = useState([]);
  const [error, setError] = useState(null);
  const { idPlot } = useParams();

  useEffect(() => {
    const fetchData = async () => {
      try {
        // Obtener siembras para el lote utilizando el idPlot de la URL
        const plantingsResponse = await getPlantingsForPlot(idPlot);
        setPlantings(plantingsResponse);
        const plotData = await getPlotById(idPlot)
        setPlotDetails(plotData)
        
      } catch (error) {
        console.error('Error al obtener detalles del lote:', error);
        setError('Error al obtener detalles del lote');
      }
    };

    fetchData();
  }, [idPlot, getPlantingsForPlot]);

  return (
    <div>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      <h1>Detalles del Lote</h1>
      <Card>
        <Card.Body>
          <Card.Title>{}</Card.Title>
          <Card.Subtitle className="mb-2 text-muted">ID: {idPlot}</Card.Subtitle>
          <ListGroup className="mb-3">
            <ListGroupItem>Tamaño: {plotDetails.size}</ListGroupItem>
            <ListGroupItem>Tipo de Suelo: {plotDetails.groundType}</ListGroupItem>
            {/* Agrega más detalles según sea necesario */}
          </ListGroup>
        </Card.Body>
      </Card>

      <h2>Siembras en el Lote</h2>
      <ul>
        {plantings.map((planting) => (
          <li key={planting.idPlanting}>
            <strong>Cultivo:</strong> {planting.crop}, <strong>Temporada:</strong> {planting.season}, <strong>Fecha de Inicio:</strong> {planting.startDate}
            {/* Agrega más detalles de la siembra según sea necesario */}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default PlotDetails;
