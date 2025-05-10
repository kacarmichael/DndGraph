import {Component} from "react";
import {NewUserForm} from "./NewUserForm.jsx";

export class LoginMenu extends Component {

    constructor(props) {
        super(props);
        this.state = {
            username: "Username",
            password: "",
            showRegister: false
        }
    }

    handleInputChange = (event) => {
        const { name, value } = event.target;
        this.setState({ [name]: value });
    }

    onClickSubmit = (e) => {
        e.preventDefault();
        const {username, password} = this.state;
        const body = {username, password};
        fetch(import.meta.env.VITE_AUTH_URL + '/login/', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(body)
            }
        ).then(
            response => {
                if (response.status === 200) {
                    return response.json()
                }
                else {
                    throw new Error("Invalid username or password");
                }
            }
        ).then(
            response => {
                console.log(response)
                const token = response.token;
                localStorage.setItem('jwt', token);
                this.props.onLoginSuccess();
            }
        ).catch(e => console.log(e));
    }

    render() {
        return (
            <>
                <form onSubmit={this.onClickSubmit}>
                    <input type="text"
                           id="UsernameInput"
                           value={this.state.username}
                           name="username"
                           onChange={e => this.handleInputChange(e)}
                    />
                    <input type={"password"}
                           id="PasswordInput"
                           name="password"
                           onChange={e => this.handleInputChange(e)}
                    />
                    {/*<button onClick={this.onClickSubmit} name={"Login"} type={"submit"}></button>*/}
                    <button type={"submit"}>Login</button>
                </form>
                {this.state.showRegister && <NewUserForm/>}
                <button onClick={() => this.setState({showRegister: true})}>Register</button>
            </>
        )
    }
}