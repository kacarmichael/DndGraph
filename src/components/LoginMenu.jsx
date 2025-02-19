import {Component} from "react";

export class LoginMenu extends Component {

    constructor(props) {
        super(props);
        this.state = {
            username: "Username",
            password: ""
        }
    }

    onUsernameChange = (e) => {
        this.setState({username: e.value});
    }

    onPasswordChange = (e) => {
        this.setState({password: e.value});
    }

    onClickSubmit = (e) => {
        const body = {
            username: document.getElementById("UsernameInput").value,
            password: document.getElementById("PasswordInput").value
        }
        fetch(import.meta.env.VITE_AUTH_URL + '/login/', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(body)
            }
        ).then(
            response => {
                console.log(response)
            }
        ).catch(e => console.log(e));
    }

    render() {
        return (
            <>
                <input type="text" id="UsernameInput" value={this.state.username} name="UsernameInput" onChange={this.onUsernameChange}/>
                <input type={"password"} id="PasswordInput" name={"PasswordInput"} onChange={this.onPasswordChange}/>
                <button onClick={this.onClickSubmit} name={"Login"} type={"submit"}></button>
            </>
        )
    }
}