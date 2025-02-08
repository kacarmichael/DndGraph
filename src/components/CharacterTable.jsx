import React, { Component } from 'react'
import PropTypes from "prop-types";
import { getClasses } from "../scripts/classes.js";


export class CharacterTable extends Component {



    static propTypes = {
        onChangeClass: PropTypes.func.isRequired
    }

    constructor(props) {
        super(props);
        this.state = {
            classes: [],
            selectedClass: 'Barbarian',
            characterName: '',
            characterLevel: 1,
            characterAC: 10
        };
    }

    componentDidMount() {
        getClasses().then(classes => this.setState({ classes }));
    }

    onClassChange = (e) => {
        this.setState({ selectedClass: e.target.value });
    }

    onNameChange = (e) => {
        this.setState({ characterName: e.target.value });
    }


    render() {

        return (
            <>
            <table>
                <tbody>
                    <tr>
                        <td>Character Name</td>
                        <td>
                            <input type="text"
                                   value={this.state.characterName}
                                   onChange={this.onNameChange} />
                        </td>
                    </tr>
                    <tr>
                        <td>Character Class</td>
                        <td>
                            <select value={this.state.selectedClass} onChange={this.onClassChange}>
                                {this.state.classes.map((c) => (
                                    <option key={c.name} value={c.name}>{c.name}</option>
                                ))}
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td>Character Level</td>
                        <td>
                            <input type="number"
                                   value={this.state.characterLevel}
                                   onChange={(e) => this.setState({ characterLevel: e.target.value })}
                            />
                        </td>
                    </tr>
                    <tr>
                        <td>Character AC</td>
                        <td>
                            <input type="number"
                                   value={this.state.characterAC}
                                   onChange={(e) => this.setState({ characterAC: e.target.value })}
                            />
                        </td>
                    </tr>
                </tbody>
            </table>
            </>
        )
    }
}