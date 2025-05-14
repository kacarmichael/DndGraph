import React, { Component } from 'react'
import PropTypes from "prop-types";

export class ModeSelectorButton extends Component {
    static propTypes = {
        text: PropTypes.string,
        onClick: PropTypes.func,
        isActive: PropTypes.bool
    }

    constructor(props) {
        super(props);
        // this.state = {
        //     isActive: false
        // };
    }

    handleClick = () => {
        this.props.onClick();
        this.setState({"isActive":!this.props.isActive});
    }

    render() {

        const { text, onClick } = this.props;
        const className = this.props.isActive ? 'ModeSelectorButton active' : 'ModeSelectorButton';

        return (
            <div className={className} onClick={this.handleClick}>{text}</div>
        )
    }
}