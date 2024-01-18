import { BrowserRouter as Router, Routes, Route} from 'react-router-dom';
import Home from './pages/Home.jsx';
import Login from './pages/Login.jsx';
import Register from './pages/Register.jsx';
import Plots from './pages/Plots.jsx';


const AppRouter = () => {
  return (
    <Router>
      <Routes>
        <Route path="/home" element={<Home/>} />
        <Route path="/login" element={<Login/>} />
        <Route path="/register" element={<Register/>} />
        <Route path="/plots" element={<Plots/>} />
        {/* Agrega más rutas según sea necesario */}
      </Routes>
    </Router>
  );
};

export default AppRouter;