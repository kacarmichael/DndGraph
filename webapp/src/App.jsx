import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import {RollTable} from "./components/RollTable.jsx";
import {CharacterConfig} from "./components/CharacterConfig.jsx";
import ResultsChart from "./components/ResultsChart.jsx";
import {LoginMenu} from "./components/LoginMenu.jsx";
import {NewUserForm} from "./components/NewUserForm.jsx";
import {CharacterCreationMenu} from "./components/CharacterCreationMenu.jsx";

function App() {
  console.log('VITE_API_URL:', import.meta.env.VITE_API_URL);
  const [count, setCount] = useState(0);
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [dc, setDc] = useState(0);

  const handleLoginSuccess = () => {
    setIsLoggedIn(true);
  };

  return (
    <>
        <div>
            <h1>You Feeling Lucky?</h1>
            {/*{isLoggedIn ? (<RollTable/>) : (<LoginMenu onLoginSuccess={handleLoginSuccess}/>) }*/}
            {/*{isLoggedIn ? (<CharacterCreationMenu/>) : (<LoginMenu onLoginSuccess={handleLoginSuccess}/>) }*/}
            {/*<CharacterConfig/>*/}
            <RollTable/>
            {/*<LoginMenu/>*/}
            {/*<NewUserForm/>*/}
        </div>
    </>
  )
}

export default App
