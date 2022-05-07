import * as React from "react";
import { Grid } from '@material-ui/core';
import LineChart from '../atoms/LineChart';
import BarChart from '../atoms/BarChart';
import styles from "../../styles/styles";

export default class ChartSelector extends React.Component<Model.IChartSelector> {

    render(): JSX.Element {
        return (
            <div>
                <Grid item className={styles().grid} xs={12}>
                    {this.props.type.isBar
                        ? <BarChart
                            labels={this.props.labels}
                            datasets={this.props.datasets}
                            options={this.props.options} />
                        : <LineChart
                            labels={this.props.labels}
                            datasets={this.props.datasets}
                            options={this.props.options} />}
                </Grid>
            </div>
        );
    }
}