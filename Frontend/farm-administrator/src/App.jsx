import 'bootstrap/dist/css/bootstrap.min.css';
import NavBar from './components/NavBar';
import { Routes, Route } from 'react-router-dom';
import Home from './pages/Home.jsx';
import Login from './pages/Login.jsx';
import Register from './pages/Register.jsx';
import Plots from './pages/Plots.jsx';
import PlotDetails from './pages/PlotDetails.jsx';

function App() {
  return (
    <div>
      <NavBar showLoginButton={true} showSignupButton={true} showPlotsButton={true} />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route path="/plots" element={<Plots />} />
        <Route path="/plots/:idPlot" element={<PlotDetails />} />
      </Routes>
    </div>
  );
}

export default App;
