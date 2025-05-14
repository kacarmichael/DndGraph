import React, { Component } from 'react'
import ResultsChart from "./ResultsChart.jsx";

export class RollMenu extends Component {

    constructor(props) {
        super(props);
        this.state = {
            d4: 0,
            d6: 0,
            d8: 0,
            d10: 0,
            d12: 0,
            d20: 0,
            d100: 0,
            modifier: 0,
            rollResult: 0,
        };
    }

    getHeaders = () => {
        //const jwt = localStorage.getItem('jwt');
        var h = {
            //'Authorization': `Bearer ${jwt}`,
            'Content-Type': 'application/json'
        }
        if (process.env.NODE_ENV === 'development') {
            h['CF-Access-Client-Id'] = import.meta.env.VITE_CF_ACCESS_ID;
            h['CF-Access-Client-Secret'] = import.meta.env.VITE_CF_ACCESS_SECRET;
        }
        return h;
    }

    onDiceChange = (e) => {
        const value = e.target.value !== '' ? parseInt(e.target.value) : 0;
        this.setState({[e.target.name]: value});
    }

    onClick_roll = () => {

        console.log(import.meta.env.VITE_API_URL + '/api/roll/dice');

        const diceState = {
            d4: this.state.d4,
            d6: this.state.d6,
            d8: this.state.d8,
            d10: this.state.d10,
            d12: this.state.d12,
            d20: this.state.d20,
            d100: this.state.d100,
            modifier: this.state.modifier
        }

        if (Object.values(diceState).every(value => value !== undefined)) {
            fetch(import.meta.env.VITE_API_URL + '/api/roll/dice', {
                mode: 'cors',
                method: 'POST',
                headers: this.getHeaders(),
                body: JSON.stringify(diceState)
            }).then(
                response => {
                    if (response.ok) {
                        return response.json()
                    } else {
                        const error = new Error(`Error ${response.status}: ${response.statusText} at ${response.url}`);
                        error.response = response;
                        throw error;
                    }
                }
            ).then(
                data => this.setState({rollResult: data.total})
            ).catch((error) => {
                    if (error.response) {
                        console.error(`Error ${error.response.status}: ${error.response.statusText} at ${error.response.url}`);
                    } else {
                        console.error(error)
                    }
                }
            )
        } else {
            console.log('Missing dice');
        }
    }

    render() {
        return (
            <div className={"RollTable"}
                 style={{
                     display: 'flex', flexDirection: 'column',
                     gap: '50px', justifyContent: 'center'
                 }}>
                <table>
                    <thead>
                    <tr>
                        <th>Dice</th>
                        <th>Quantity</th>
                    </tr>
                    </thead>
                    <tbody>
                    <tr>
                        <td>D4</td>
                        <td>
                            <input type="number" id="d4Input" name="d4" onChange={this.onDiceChange}/>
                        </td>
                    </tr>
                    <tr>
                        <td>D6</td>
                        <td>
                            <input type="number" id="d6Input" name="d6" onChange={this.onDiceChange}/>
                        </td>
                    </tr>
                    <tr>
                        <td>D8</td>
                        <td>
                            <input type="number" id="d8Input" name="d8" onChange={this.onDiceChange}/>
                        </td>
                    </tr>
                    <tr>
                        <td>D10</td>
                        <td>
                            <input type="number" id="d10Input" name="d10" onChange={this.onDiceChange}/>
                        </td>
                    </tr>
                    <tr>
                        <td>D12</td>
                        <td>
                            <input type="number" id="d12Input" name="d12" onChange={this.onDiceChange}/>
                        </td>
                    </tr>
                    <tr>
                        <td>D20</td>
                        <td>
                            <input type="number" id="d20Input" name="d20" onChange={this.onDiceChange}/>
                        </td>
                    </tr>
                    <tr>
                        <td>D100</td>
                        <td>
                            <input type="number" id="d100Input" name="d100" onChange={this.onDiceChange}/>
                        </td>
                    </tr>
                    <tr>
                        <td>Modifier</td>
                        <td>
                            <input type="number" id="modifierInput" name="modifier" onChange={this.onDiceChange}/>
                        </td>
                    </tr>
                    <tr>
                        <td>Trials</td>
                        <td>
                            <input type="number" id="trialsInput" name="trials" onChange={this.onDiceChange}/>
                        </td>
                    </tr>
                    </tbody>
                </table>
                <div style={{display: 'flex', flexDirection: 'column', gap: '50px'}}>
                    <div style={{display: 'flex', margin: 'auto', justifyContent: 'space-between', gap: '25px'}}>
                        <button style={{margin: 'auto'}} onClick={this.onClick_roll}>Roll</button>
                        <h3 style={{margin: 'auto'}}>RESULT:</h3>
                        <h2 style={{margin: 'auto'}}>{this.state.rollResult}</h2>
                    </div>
                </div>
            </div>

        )
    }
}
