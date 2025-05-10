import React, { Component } from 'react'
import * as d3 from "d3"
import PropTypes from "prop-types";



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
        const width = 1000 - margin.left - margin.right;
        const height = 400 - margin.top - margin.bottom;

        const xScale = d3.scaleBand()
            .domain(this.props.data.map(d => d.value))
            .range([0, width])
            .padding(0.2);

        const yScale = d3.scaleLinear()
            .domain([0, this.props.data.length > 0 ? d3.max(this.props.data, d => d.frequency) : 0])
            .range([height, 0]);

        const numTicks = Math.min(10, this.props.data.length);
        const tickValues = [];
        for (let i = 0; i < numTicks; i++) {
            tickValues.push(this.props.data[Math.floor(i * this.props.data.length / numTicks)].value);
        }

        const xAxis = d3.axisBottom(xScale)
            .tickValues(tickValues)
            .tickFormat(d => d)
            .tickSize(5);


        const yAxis = d3.axisLeft(yScale);


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
            .attr("transform", `translate(${margin.left},${margin.top})`)
            .call(yAxis)

        svg.append("g")
            .attr("transform", `translate(${margin.left},${height + margin.top})`)
            .call(xAxis);

        svg.append("g")
            .attr("transform", `translate(${margin.left},${margin.top})`)
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
            .attr("fill", d => d.value >= this.props.dc ? "#6286B3" : "#F49D01");

        svg.append("g")
            .attr("transform", `translate(${margin.left},${margin.top})`)
            .append("line")
            .attr("x1", xScale(this.props.dc))
            .attr("y1", 0)
            .attr("x2", xScale(this.props.dc))
            .attr("y2", height)
            .attr("stroke", "red")
            .attr("stroke-width", 2);

        svg.selectAll(".tick text")
            .style("font-size", "20px");

    }

    // renderChart() {
    //     const margin = { top: 20, right: 20, bottom: 30, left: 40 };
    //     const width = 500 - margin.left - margin.right;
    //     const height = 500 - margin.top - margin.bottom;
    //
    //     const xScale = d3.scaleLinear()
    //         .domain(this.props.data.map(d => d.value))
    //         .range([0, width])
    //         .padding(0.2);
    //
    //     const yScale = d3.scaleLinear()
    //         .domain([0, this.props.data.length > 0 ? d3.max(this.props.data, d => d.frequency) : 0])
    //         .range([0, height]);
    //
    //     let svg = d3.select(this.chartRef)
    //         .attr("class", "axis axis--x")
    //         .attr("transform", `translate(0,${height - margin.bottom})`)
    //         .call(d3.axisBottom(xScale))
    //         .append("text")
    //         .attr("x", width - margin.right)
    //         .attr("y", -6)
    //         .attr("fill", "orange")
    //         .attr("text-anchor", "end")
    //         .attr("font-weight", "bold")
    //         .text("Text 1 here")
    //
    //     svg.append("g")
    //         .attr("class", "axis axis--y")
    //         .attr("transform", `translate(${margin.left},0)`)
    //         .call(d3.axisLeft(yScale));
    //
    //     var n = this.props.data.length,
    //         bins = d3.histogram().domain(xScale.domain()).thresholds(10)(this.props.data),
    //         density = kernelDensityEstimator(kernelEpanechnikov(7), xScale.ticks(40))(this.props.data)
    //
    //     svg.insert("g", "*")
    //         .attr("fill", "#bbb")
    //         .selectAll("rect")
    //         .data(bins)
    //         .enter().append("rect")
    //         .attr("x", function(d) { return xScale(d.value) + 1; })
    //         .attr("y", function(d) { return yScale(d.frequency / n); })
    //         //.attr("width", function(d) { return xScale})
    // }

    render() {
        return (
            <div style={{width: "100%", height: "100%"}} ref={this.chartRef}></div>
        )
    }
}

// https://gist.github.com/mbostock/4341954
function kernelDensityEstimator(kernel, X) {
    return function(V) {
        return X.map(function(x) {
            return [x, d3.mean(V, function(v) { return kernel(x - v); })];
        });
    };
}

function kernelEpanechnikov(k) {
    return function(v) {
        return Math.abs(v /= k) <= 1 ? 0.75 * (1 - v * v) / k : 0;
    };
}

ResultsChart.propTypes = {
    data: PropTypes.arrayOf(PropTypes.shape({
        value: PropTypes.number,
        frequency: PropTypes.number
    })),
    dc: PropTypes.number
}

export default ResultsChart;