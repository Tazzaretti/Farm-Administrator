import React from 'react';
import PlotCard from '../modules/PlotCard.jsx';

const usersData = [
  { id: 1, name: 'Lote 1', state: 'Sembrado', location: 'Ciudad A' },
  { id: 2, name: 'Lote 2', state: 'Barbicho', location: 'Ciudad B' },
  // Agrega más datos de usuarios según sea necesario
];

const Plots = () => {
  const handleAddPlot = () => {
    // Agrega lógica para manejar la creación de un nuevo lote
    console.log('Agregar nuevo lote');
  };

  return (
    <div>
      <h1>Lotes</h1>
      <button onClick={handleAddPlot}>Agregar Nuevo Lote</button>
      <div className="user-cards">
        {usersData.map((user) => (
          <PlotCard key={user.id} {...user} />
        ))}
      </div>
    </div>
  );
};

export default Plots;