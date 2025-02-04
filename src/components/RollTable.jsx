import PropTypes from 'prop-types';

export class RollTable extends Component {

    static propTypes = {
        d4: PropTypes.number,
        d6: PropTypes.number,
        d8: PropTypes.number,
        d10: PropTypes.number,
        d12: PropTypes.number,
        d20: PropTypes.number,
        d100: PropTypes.number
    }

    constructor(props) {
        super();
    }

    onClick_roll = () => {
        this.props.d4 = document.getElementById("d4Input").value;
        this.props.d6 = document.getElementById("d6Input").value;
        this.props.d8 = document.getElementById("d8Input").value;
        this.props.d10 = document.getElementById("d10Input").value;
        this.props.d12 = document.getElementById("d12Input").value;
        this.props.d20 = document.getElementById("d20Input").value;
        this.props.d100 = document.getElementById("d100Input").value;

        fetch(process.env.REACT_APP_API_URL, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                d4: this.props.d4,
                d6: this.props.d6,
                d8: this.props.d8,
                d10: this.props.d10,
                d12: this.props.d12,
                d20: this.props.d20,
                d100: this.props.d100
            })
        })
    }
    render() {
        return (
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
                            <input type="number" id="d4Input" name="d4Input"/>
                        </td>
                    </tr>
                    <tr>
                        <td>D6</td>
                        <td>
                            <input type="number" id="d6Input" name="d6Input"/>
                        </td>
                    </tr>
                    <tr>
                        <td>D8</td>
                        <td>
                            <input type="number" id="d8Input" name="d8Input"/>
                        </td>
                    </tr>
                    <tr>
                        <td>D10</td>
                        <td>
                            <input type="number" id="d10Input" name="d10Input"/>
                        </td>
                    </tr>
                    <tr>
                        <td>D12</td>
                        <td>
                            <input type="number" id="d12Input" name="d12Input"/>
                        </td>
                    </tr>
                    <tr>
                        <td>D20</td>
                        <td>
                            <input type="number" id="d20Input" name="d20Input"/>
                        </td>
                    </tr>
                    <tr>
                        <td>D100</td>
                        <td>
                            <input type="number" id="d100Input" name="d100Input"/>
                        </td>
                    </tr>
                </tbody>
            </table>
            <button onClick={this.onClick_roll}>Roll</button>
        )
    }
}
