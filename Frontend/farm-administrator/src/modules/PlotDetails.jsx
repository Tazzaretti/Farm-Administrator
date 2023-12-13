import React from 'react';
import { useParams } from 'react-router-dom';

const PlotDetail = () => {
  const { id } = useParams();

  // Lógica para obtener y mostrar detalles del plot con el ID proporcionado

  return (
    <div>
      <h2>Detalles del Plot {id}</h2>
      {/* Mostrar detalles del plot según sea necesario */}
    </div>
  );
};

export default PlotDetail;