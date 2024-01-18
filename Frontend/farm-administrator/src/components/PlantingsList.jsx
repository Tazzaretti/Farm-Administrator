// PlantingsList.js
import React from 'react';

const PlantingsList = ({ plantings }) => {
  return (
    <div>
      <h2>Siembras Relacionadas</h2>
      <ul>
        {plantings.map((planting) => (
          <li key={planting.idPlanting}>
            <strong>Cosecha:</strong> {planting.crop}<br />
            <strong>Temporada:</strong> {planting.season}<br />
            {/* Agrega más campos según sea necesario */}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default PlantingsList;
