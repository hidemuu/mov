import React from 'react';
import { Line } from 'react-chartjs-2';

export default class BarChart extends React.Component {
    render() {
        const { labels, datasets, options } = this.props;
        return (
            <Line
                data={{
                    labels: labels,
                    datasets: datasets,
                }}
                options={options} />
        );
    }
}