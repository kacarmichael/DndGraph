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
  const [count, setCount] = useState(0);
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [dc, setDc] = useState(0);

  const handleLoginSuccess = () => {
    setIsLoggedIn(true);
  };

  const onDCChange = (e) => {
    setDc(parseInt(e.target.value));
  };

  return (
    <>
      <div>
          {/*{isLoggedIn ? (<RollTable/>) : (<LoginMenu onLoginSuccess={handleLoginSuccess}/>) }*/}
          {/*{isLoggedIn ? (<CharacterCreationMenu/>) : (<LoginMenu onLoginSuccess={handleLoginSuccess}/>) }*/}
          {/*<CharacterConfig/>*/}
          <RollTable dc={dc}/>
          <input type="number" id="dcInput" name="dc" onChange={onDCChange}/>
          {/*<LoginMenu/>*/}
          {/*<NewUserForm/>*/}
      </div>
    </>
  )
}

export default App
