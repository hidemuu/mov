import React from 'react';
import { Bar } from 'react-chartjs-2';

export default class BarChart extends React.Component {
    render() {
        const { labels, datasets, options } = this.props;
        return (
            <Bar
                data={{
                    labels: labels,
                    datasets: datasets,
                }}
                options={options} />
        );
    }
}