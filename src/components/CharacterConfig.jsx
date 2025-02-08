import {CharacterTable} from "./CharacterTable.jsx";
import {Component} from "react";
export class CharacterConfig extends Component {

    onChangeClass = (e) => {
        this.setState({characterClass: e.target.value});
    }

    render() {

        return (
            <>
                <CharacterTable
                    characterLevel="test"
                    characterAC="test"
                    onChangeClass={this.onChangeClass}>
                </CharacterTable>
            </>
        )
    }
}