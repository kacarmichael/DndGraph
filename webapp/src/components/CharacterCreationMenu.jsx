import {Component} from "react";

export class CharacterCreationMenu extends Component {

    constructor(props) {
        super(props);
        this.state = {
            name: '',
            characterClass: ''
        };
    }

    handleNameChange(e) {
        this.setState({name: e.target.value});
    }

    onClassChange = (e) => {
        this.setState({ characterClass: e.target.value });
    }

    onClickSubmit = (e) => {
        e.preventDefault();
        const body = {
            name: this.state.name,
            //characterClass: this.state.characterClass,
            level: 1,
            ac: 10,
            classes: {
                [this.state.characterClass]: 1
            },
            proficiencies: [],
            abilityScores: {
                Strength: 10,
                Dexterity: 10,
                Constitution: 10,
                Intelligence: 10,
                Wisdom: 10,
                Charisma: 10
            },
            skillModifiers: {
                Acrobatics: 0,
                AnimalHandling: 0,
                Arcana: 0,
                Athletics: 0,
                Deception: 0,
                History: 0,
                Insight: 0,
                Intimidation: 0,
                Investigation: 0,
                Medicine: 0,
                Nature: 0,
                Perception: 0,
                Performance: 0,
                Persuasion: 0,
                Religion: 0,
                SleightOfHand: 0,
                Stealth: 0,
                Survival: 0
            }
        };

        fetch(import.meta.env.VITE_API_URL + '/api/characters', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(body)
        }).then(response => response.json())
            .then(data => {
                console.log(data);
            });

    }

    render() {
        return (
            <>
                <form onSubmit={this.onClickSubmit}>
                    <input type="text"
                           id="CharacterNameInput"
                           value={this.state.name}
                           name="username"
                           onChange={e => this.handleNameChange(e)}
                    />
                    <label>Character Class</label>
                    <select id="CharacterClassInput" name="CharacterClassInput" onChange={this.onClassChange}>
                        <option value="Barbarian">Barbarian</option>
                        <option value="Bard">Bard</option>
                        <option value="Cleric">Cleric</option>
                        <option value="Druid">Druid</option>
                        <option value="Paladin">Paladin</option>
                        <option value="Ranger">Ranger</option>
                        <option value="Rogue">Rogue</option>
                        <option value="Sorceror">Sorcerer</option>
                        <option value="Warlock">Warlock</option>
                        <option value="Wizard">Wizard</option>
                    </select>
                    {/*<button onClick={this.onClickSubmit} name={"Login"} type={"submit"}></button>*/}
                    <button type={"submit"}>Submit</button>
                </form>
            </>
        )
    }
}