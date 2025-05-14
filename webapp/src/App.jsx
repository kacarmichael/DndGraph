import React, { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import {RollTable} from "./components/RollTable.jsx";
import {CharacterConfig} from "./components/CharacterConfig.jsx";
import ResultsChart from "./components/ResultsChart.jsx";
import {LoginMenu} from "./components/LoginMenu.jsx";
import {NewUserForm} from "./components/NewUserForm.jsx";
import {CharacterCreationMenu} from "./components/CharacterCreationMenu.jsx";
import {ModeSelector} from "./components/ModeSelector.jsx";
import {SimulateMenu} from "./components/SimulateMenu.jsx";
import {RollMenu} from "./components/RollMenu.jsx";

function App() {
  console.log('VITE_API_URL:', import.meta.env.VITE_API_URL);
  const [count, setCount] = useState(0);
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [dc, setDc] = useState(0);
  const [mode, setMode] = useState('Roll');

  const handleLoginSuccess = () => {
    setIsLoggedIn(true);
  };

  const updateSelection = (newSelection) => {
    setMode(newSelection);
  }

  return (
    <>
        <div>
            <h1 className={'Title'}>You Feeling Lucky?</h1>
            {/*{isLoggedIn ? (<RollTable/>) : (<LoginMenu onLoginSuccess={handleLoginSuccess}/>) }*/}
            {/*{isLoggedIn ? (<CharacterCreationMenu/>) : (<LoginMenu onLoginSuccess={handleLoginSuccess}/>) }*/}
            {/*<CharacterConfig/>*/}
            <div style={{display: 'flex', flexDirection: 'column', gap: '50px', justifyContent: 'center'}}>
                <ModeSelector onModeChange={updateSelection}/>
                {mode === 'Roll' && <RollMenu/>}
                {mode === 'Simulate' && <SimulateMenu/>}
            </div>
            {/*<LoginMenu/>*/}
            {/*<NewUserForm/>*/}
        </div>
    </>
  )
}

export default App
