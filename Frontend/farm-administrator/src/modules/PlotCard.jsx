import React from 'react';
import { Link } from 'react-router-dom';
import "../styles/PlotCard.css"

const PlotCard = ({ id, name, state, location }) => {
  return (
    <Link to={`/plot/${id}`}>
        <div className="plot-card">
          <h3>{name}</h3>
          <p>Estado: {state}</p>
          <p>Ubicación: {location}</p>
        </div>
    </Link>
  );
};

export default PlotCard;