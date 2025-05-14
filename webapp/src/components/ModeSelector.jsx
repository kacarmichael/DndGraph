import React, { Component } from 'react'
import PropTypes from "prop-types";
import {ModeSelectorButton} from "./ModeSelectorButton.jsx";

export class ModeSelector extends Component {
    static propTypes = {
        onModeChange: PropTypes.func
    }

    constructor(props) {
        super(props);
        this.state = {
            selected: 'Roll'
        };
    }

    handleClick = (text) => {
        this.setState({selected: text});
        this.props.onModeChange(text);
    }

    render() {

        return (
            <div className={'ModeSelectorBar'}>
                <ModeSelectorButton text={'Roll'} isActive={this.state.selected === 'Roll'} onClick={() => this.handleClick('Roll')}/>
                <ModeSelectorButton text={'Simulate'} isActive={this.state.selected === 'Simulate'} onClick={() => this.handleClick('Simulate')}/>
            </div>
        )
    }
}