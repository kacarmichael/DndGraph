import React, { Component } from 'react'
import * as d3 from "d3"
import PropTypes, {checkPropTypes} from "prop-types";



export class ResultsChart extends Component {
    constructor(props) {
        super(props);
        this.chartRef = React.createRef();
    }

    componentDidMount() {
        this.renderChart();
    }

    componentDidUpdate(prevProps) {
        if (prevProps.data !== this.props.data) {
            this.renderChart();
        }
    }

    renderChart() {
        const margin = { top: 20, right: 20, bottom: 30, left: 40 };
        const width = 500 - margin.left - margin.right;
        const height = 300 - margin.top - margin.bottom;

        const xScale = d3.scaleBand()
            .domain(this.props.data.map(d => d.value))
            .range([0, width])
            .padding(0.2);

        const yScale = d3.scaleLinear()
            .domain([0, this.props.data.length > 0 ? d3.max(this.props.data, d => d.frequency) : 0])
            .range([height, 0]);

        let svg = d3.select(this.chartRef.current)
            .select("svg")
            .attr("width", width + margin.left + margin.right)
            .attr("height", height + margin.top + margin.bottom)
            // .append("g")
            // .attr("transform", `translate(${margin.left},${margin.top})`);

        if (svg.empty()) {
            svg = d3.select(this.chartRef.current)
                .append("svg")
                .attr("width", width + margin.left + margin.right)
                .attr("height", height + margin.top + margin.bottom)
                // .append("g")
                // .attr("transform", `translate(${margin.left},${margin.top})`);
        }

        svg.selectAll("g")
            .remove();

        // svg.selectAll("rect")
        //     .data(this.props.data)
        //     .enter()
        //     .append("rect")
        //     .attr("x", d => xScale(d.value))
        //     .attr("y", d => yScale(d.frequency))
        //     .attr("width", xScale.bandwidth())
        //     .attr("height", d => {
        //         const heightValue = height - yScale(d.frequency);
        //         return isNaN(heightValue) ? 0 : heightValue;
        //     })

        svg.append("g")
            .attr("transform", 'translate(${margin.left},${margin.top})')
            .selectAll("rect")
            .data(this.props.data)
            .enter()
            .append("rect")
            .attr("x", d => xScale(d.value))
            .attr("y", d => yScale(d.frequency))
            .attr("width", xScale.bandwidth())
            .attr("height", d => {
                const heightValue = height - yScale(d.frequency);
                return isNaN(heightValue) ? 0 : heightValue;
            })

    }

    render() {
        return (
            <div ref={this.chartRef}></div>
        )
    }
}

ResultsChart.propTypes = {
    data: PropTypes.arrayOf(PropTypes.shape({
        value: PropTypes.number,
        frequency: PropTypes.number
    })),
}

export default ResultsChart;