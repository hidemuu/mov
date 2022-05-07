import * as React from "react";
import { Line } from 'react-chartjs-2';

export default class BarChart extends React.Component<Model.IChart> {

    render(): JSX.Element {
        return (
            <Line
                data={{
                    labels: this.props.labels,
                    datasets: this.props.datasets,
                }}
                options={this.props.options} />
        );
    }
}