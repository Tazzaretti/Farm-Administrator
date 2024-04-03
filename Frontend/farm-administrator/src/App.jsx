import 'bootstrap/dist/css/bootstrap.min.css';
import NavBar from './components/NavBar';
import AppRouter from './AppRouter.jsx';

function App() {
  return (
    <div>
      <NavBar showLoginButton={true} showSignupButton={true} showPlotsButton={true} />
      <AppRouter/>

    </div>
  );
}

export default App;
