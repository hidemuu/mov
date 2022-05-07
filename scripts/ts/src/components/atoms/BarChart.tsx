import * as React from "react";
import { Bar } from 'react-chartjs-2';

export default class BarChart extends React.Component<Model.IChart> {

    render(): JSX.Element {
        return (
            <Bar
                data={{
                    labels: this.props.labels,
                    datasets: this.props.datasets,
                }}
                options={this.props.options} />
        );
    }
}