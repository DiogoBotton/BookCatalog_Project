import { BrowserRouter as Router } from 'react-router-dom';
import Routes from './routes';
import './styles/global.css'
import { createTheme, ThemeProvider } from '@mui/material/styles';

function App() {
  const darkTheme = createTheme({ palette: { mode: 'dark' } });
  return (
    <Router>
      <ThemeProvider theme={darkTheme}>
        <Routes />
      </ThemeProvider>
    </Router>
  )
}

export default App
