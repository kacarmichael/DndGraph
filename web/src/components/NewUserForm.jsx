import { Component } from "react";


export class NewUserForm extends Component {

    onClickRegister = () => {

        console.log(import.meta.env.VITE_AUTH_URL + '/register/');

        const body = {
            username: document.getElementById("UsernameInput").value,
            password: document.getElementById("PasswordInput").value,
            email: document.getElementById("EmailInput").value,
            role: "user"
        }

        fetch(import.meta.env.VITE_AUTH_URL + '/register/', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(body)
            }
        ).then(
            response => response.json()
        )
        window.location.href = "/login";
    }

    render() {
        return (
            <>
                <input type={"text"} id={"UsernameInput"} name={"UsernameInput"} placeholder={"Username"}/>
                <input type={"password"} id={"PasswordInput"} name={"PasswordInput"} placeholder={"Password"}/>
                <input type={"email"} id={"EmailInput"} name={"EmailInput"} placeholder={"Email"}/>
                <button type={"submit"} onClick={this.onClickRegister}>Submit</button>
            </>
        )
    }
}